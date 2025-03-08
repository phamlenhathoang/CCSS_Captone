using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IEventService
    {
        Task<List<EventResponse>> GetAllEvents(string searchTerm);
        Task<EventResponse> GetEvent(string id);
        Task<string> AddEvent(CreateEventRequest eventRequest);
        Task<string> UpdateEvent(string eventId, UpdateEventRequest eventRequest);
        Task<bool> DeleteEvent(string id);
    }

    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public EventService(IEventRepository repository, IMapper mapper, IImageService imageService)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<List<EventResponse>> GetAllEvents(string searchTerm)
        {
            var events = await _repository.GetAllEvents(searchTerm);

            // Nếu searchTerm là null hoặc rỗng, lấy tất cả sự kiện
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                events = await _repository.GetAllEvents(null);
            }

            return _mapper.Map<List<EventResponse>>(events);
        }


        public async Task<EventResponse> GetEvent(string id)
        {
            var evt = await _repository.GetEventById(id);
            return _mapper.Map<EventResponse>(evt);
        }


        public async Task<string> AddEvent(CreateEventRequest eventRequest)
        {
            if (eventRequest == null)
            {
                return "Event is null";
            }

            try
            {
                // Sử dụng AutoMapper để map từ CreateEventRequest sang Event
                var newEvent = _mapper.Map<Event>(eventRequest);

                // Gán ID và thời gian tạo
                newEvent.EventId = Guid.NewGuid().ToString();
                newEvent.CreateDate = DateTime.Now;
                newEvent.IsActive = true;
                newEvent.UpdateDate = null;

                // Nếu có thông tin Ticket trong request, sử dụng AutoMapper để map TicketRequest -> Ticket
                if (eventRequest.Ticket != null)
                {
                    var newTicket = _mapper.Map<Ticket>(eventRequest.Ticket);
                    newTicket.TicketId = Guid.NewGuid().ToString(); // Tạo ID mới cho Ticket
                    newTicket.EventId = newEvent.EventId; // Gán EventId để liên kết Ticket với Event

                    // Gán Ticket vào Event
                    newEvent.Ticket = newTicket;

                }
                if (eventRequest.EventCharacterRequest != null && eventRequest.EventCharacterRequest.Any())
                {
                    // Duyệt qua danh sách EventCharacterRequest và tạo danh sách EventCharacter
                    var eventCharacters = eventRequest.EventCharacterRequest.Select(ec => new EventCharacter
                    {
                        EventCharacterId = Guid.NewGuid().ToString(),
                        EventId = newEvent.EventId,
                        CharacterId = ec.CharacterId
                    }).ToList();

                    // Gán danh sách vào Event
                    newEvent.EventCharacters = eventCharacters;
                }

                // Lưu vào database
                bool isAdded = await _repository.AddEvent(newEvent);

                // Kiểm tra kết quả lưu database
                if (!isAdded)
                {
                    return "Failed to add event to database";
                }
                ImageRequest image = new ImageRequest();
                //image.ImageUrl = eventRequest.ImageUrl;
                image.EventId = newEvent.EventId.ToString();
                await _imageService.AddImage(image);

                return "Add Success";
            }
            catch (DbUpdateException dbEx)
            {
                // Bắt lỗi khi lưu vào database (Ví dụ: lỗi ràng buộc khóa ngoại, lỗi Unique Key,...)
                return $"Database error: {dbEx.Message}";
            }
            catch (ArgumentNullException argEx)
            {
                return $"Invalid input: {argEx.Message}";
            }
            catch (Exception ex)
            {
                // Bắt lỗi chung
                return $"An unexpected error occurred: {ex.Message}";
            }
        }



        public async Task<string> UpdateEvent(string eventId, UpdateEventRequest eventRequest)
        {
            if (eventRequest == null)
            {
                return "Invalid request: EventRequest is null";
            }

            try
            {
                var existingEvent = await _repository.GetEventById(eventId);
                if (existingEvent == null)
                {
                    return "Event not found";
                }

                // ✅ Cập nhật các trường của Event (không ảnh hưởng Ticket hoặc EventCharacter)
                existingEvent.EventName = eventRequest.EventName ?? existingEvent.EventName;
                existingEvent.Description = eventRequest.Description ?? existingEvent.Description;
                existingEvent.Location = eventRequest.Location ?? existingEvent.Location;
                //existingEvent.IsActive = eventRequest.IsActive ?? existingEvent.IsActive;
                existingEvent.StartDate = eventRequest.StartDate != default ? eventRequest.StartDate : existingEvent.StartDate;
                existingEvent.EndDate = eventRequest.EndDate != default ? eventRequest.EndDate : existingEvent.EndDate;
                existingEvent.UpdateDate = DateTime.Now;

                // ✅ Xử lý Ticket (nếu có)
                if (eventRequest.Ticket != null)
                {
                    if (existingEvent.Ticket == null)
                    {
                        if (eventRequest.Ticket.Quantity > 0 && eventRequest.Ticket.Price > 0)
                        {
                            existingEvent.Ticket = new Ticket
                            {
                                TicketId = Guid.NewGuid().ToString(),
                                EventId = existingEvent.EventId,
                                Quantity = eventRequest.Ticket.Quantity,
                                Price = eventRequest.Ticket.Price
                            };
                        }
                    }
                    else
                    {
                        if (eventRequest.Ticket.Quantity > 0)
                        {
                            existingEvent.Ticket.Quantity = eventRequest.Ticket.Quantity;
                        }

                        if (eventRequest.Ticket.Price > 0)
                        {
                            existingEvent.Ticket.Price = eventRequest.Ticket.Price;
                        }
                    }
                }

                // ✅ Xử lý danh sách EventCharacter (nếu có)
                if (eventRequest.EventCharacterRequests != null)
                {
                    // 🔥 Xóa toàn bộ EventCharacter cũ
                    await _repository.DeleteEventCharactersByEventId(existingEvent.EventId);

                    // 🔥 Thêm EventCharacter mới từ danh sách request
                    var newEventCharacters = eventRequest.EventCharacterRequests.Select(ec => new EventCharacter
                    {
                        EventCharacterId = Guid.NewGuid().ToString(),
                        EventId = existingEvent.EventId, // ✅ Đảm bảo EventId không null
                        CharacterId = ec.CharacterId
                    }).ToList();

                    existingEvent.EventCharacters = newEventCharacters;
                }

                await _repository.UpdateEvent(existingEvent);
                return "Update Success";
            }
            catch (DbUpdateException dbEx)
            {
                return $"Database error: {dbEx.Message}";
            }
            catch (ArgumentNullException argEx)
            {
                return $"Invalid input: {argEx.Message}";
            }
            catch (Exception ex)
            {
                return $"An unexpected error occurred: {ex.Message}";
            }
        }









        public async Task<bool> DeleteEvent(string id)
        {
            //await _repository.DeleteTicketByEventId(id);
            await _repository.DeleteEventCharactersByEventId(id);
            return await _repository.DeleteEvent(id);
        }

    }
}
