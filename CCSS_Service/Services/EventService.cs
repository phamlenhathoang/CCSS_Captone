using AutoMapper;
using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using Microsoft.AspNetCore.Http;
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
        Task<string> AddEvent(CreateEventRequest eventRequest, List<IFormFile> ImageUrl);
        Task<string> UpdateEvent(string eventId, UpdateEventRequest eventRequest);
        Task<bool> DeleteEvent(string id);
    }

    public class EventService : IEventService
    {
        private readonly IEventRepository _repository;
       
        private readonly IMapper _mapper;
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _taskRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly Image _image;
        //private readonly IImageService _imageService;

        public EventService(IEventRepository repository, IMapper mapper, ITaskService taskService, ITaskRepository taskRepository, IAccountRepository accountRepository, ICharacterRepository characterRepository, Image image)
        {
            _repository = repository;
            _mapper = mapper;
            //_imageService = imageService;
            _taskService = taskService;
            _taskRepository = taskRepository;
            _accountRepository = accountRepository;
            _characterRepository = characterRepository;
            _image = image;
        }

        public async Task<List<EventResponse>> GetAllEvents(string searchTerm)
        {
            var events = await _repository.GetAllEvents(searchTerm);

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                events = await _repository.GetAllEvents(null);
            }

            var result = _mapper.Map<List<EventResponse>>(events);
            for (int i = 0; i < result.Count; i++)
            {
                var eventEntity = events[i];
                int totalParticipants = eventEntity.Ticket
                    .SelectMany(t => t.TicketAccounts)
                    .Sum(ta => ta.participantQuantity);

                result[i].participantQuantity = totalParticipants;
            }
            return result;
        }


        public async Task<EventResponse> GetEvent(string id)
        {
            var evt = await _repository.GetEventById(id);

            var response = _mapper.Map<EventResponse>(evt);

            // Tính participantQuantity
            response.participantQuantity = evt.Ticket?
                .SelectMany(t => t.TicketAccounts)
                .Sum(ta => ta.participantQuantity) ?? 0;

            return response;
        }



        public async Task<string> AddEvent(CreateEventRequest eventRequest, List<IFormFile> ImageUrl)
        {
            if (eventRequest == null)
            {
                return "Event is null";
            }

            try
            {
                

                var newEvent = _mapper.Map<Event>(eventRequest);

                newEvent.EventId = Guid.NewGuid().ToString();
                newEvent.CreateDate = DateTime.Now;
                newEvent.IsActive = true;
                newEvent.UpdateDate = null;


                if (eventRequest.Ticket != null && eventRequest.Ticket.Any())
                {
                    var newTickets = _mapper.Map<List<Ticket>>(eventRequest.Ticket);

                    foreach (var ticket in newTickets)
                    {
                        ticket.EventId = newEvent.EventId;
                        ticket.ticketStatus = ticketStatus.available;
                    }

                    newEvent.Ticket = newTickets;
                }

                List<EventCharacter> eventCharacters = new List<EventCharacter>();

                if (eventRequest.EventCharacterRequest != null && eventRequest.EventCharacterRequest.Any())
                {
                    foreach (var ec in eventRequest.EventCharacterRequest)
                    {
                        Account cosplayer = await _accountRepository.GetAccountByAccountId(ec.CosplayerId);
                        bool checkTaskIsValid = await _taskRepository.CheckTaskIsValid(cosplayer, eventRequest.StartDate, eventRequest.EndDate);
                        if (!checkTaskIsValid) 
                        {
                            return "Cosplayer "+ cosplayer.Name + " không phù hợp với thời gian sự kiện";
                        }
                        Character character = await _characterRepository.GetCharacter(ec.CharacterId);
                        if (character.Quantity <= 0)
                        {
                            return "Nhân vật " + character.CharacterName + " đã hết số lượng khả dụng";
                        }
                        if (cosplayer.Height < character.MinHeight || cosplayer.Height > character.MaxHeight || cosplayer.Weight < character.MinWeight || cosplayer.Weight > character.MaxHeight)
                        {
                            return "Cosplayer " + cosplayer.Name + " không phù hợp với nhân vật " + character.CharacterName;
                        }
                        eventCharacters.Add(new EventCharacter
                        {
                            EventCharacterId = Guid.NewGuid().ToString(),
                            EventId = newEvent.EventId,
                            CharacterId = ec.CharacterId,
                            CreateDate = DateTime.Now,
                            UpdateDate = null,
                            Description = ec.Description,
                            IsAssign = false
                        });
                    }

                    newEvent.EventCharacters = eventCharacters;
                }

                if (eventRequest.EventActivityRequests != null && eventRequest.EventActivityRequests.Any())
                {
                    var eventActivities = eventRequest.EventActivityRequests.Select(ea => new EventActivity
                    {
                        EventActivityId = Guid.NewGuid().ToString(), 
                        EventId = newEvent.EventId, 
                        ActivityId = ea.ActivityId, 
                        CreateBy = ea.CreateBy, 
                        CreateDate = DateTime.Now, 
                        
                    }).ToList();
                    newEvent.EventActivities = eventActivities;
                }

                if (ImageUrl != null )
                {
                    var imageTasks = ImageUrl.Select(async file => new EventImage
                    {
                        ImageId = Guid.NewGuid().ToString(),
                        ImageUrl = await _image.UploadImageToFirebase(file),
                        CreateDate = DateTime.Now,
                        EventId = newEvent.EventId,

                    }).ToList();
                    var images = await System.Threading.Tasks.Task.WhenAll(imageTasks);
                    newEvent.EventImages = images.ToList();
                }
          
                bool isAdded = await _repository.AddEvent(newEvent);

                if (eventRequest.EventCharacterRequest != null && eventRequest.EventCharacterRequest.Any())
                {
                    var taskEventRequests = eventRequest.EventCharacterRequest.Select((ec, index) => new AddTaskEventRequest
                    {
                        AccountId = ec.CosplayerId, 
                        EventCharacterId = eventCharacters[index].EventCharacterId 
                    }).ToList();

                    await _taskService.AddTask(taskEventRequests, null);
                }
                if (!isAdded)
                {
                    return "Failed to add event to database";
                }
                foreach (var ec in eventRequest.EventCharacterRequest)
                {
                    Character character = await _characterRepository.GetCharacter(ec.CharacterId);
                    character.Quantity -= 1;
                    await _characterRepository.UpdateCharacter(character);
                }

                //ImageRequest image = new ImageRequest();
                //image.ImageUrl = eventRequest.ImageUrl;
                //image.EventId = newEvent.EventId.ToString();
                //await _imageService.AddImage(image);

                return "Add Success";
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

                existingEvent.EventName = eventRequest.EventName ?? existingEvent.EventName;
                existingEvent.Description = eventRequest.Description ?? existingEvent.Description;
                existingEvent.Location = eventRequest.Location ?? existingEvent.Location;
                //existingEvent.IsActive = eventRequest.IsActive ?? existingEvent.IsActive;
                existingEvent.StartDate = eventRequest.StartDate != default ? eventRequest.StartDate : existingEvent.StartDate;
                existingEvent.EndDate = eventRequest.EndDate != default ? eventRequest.EndDate : existingEvent.EndDate;
                existingEvent.UpdateDate = DateTime.Now;

                
                if (eventRequest.Ticket != null && eventRequest.Ticket.Any())
                {
                    await _repository.DeleteTicketsByEventId(existingEvent.EventId);

                    foreach (var ticketRequest in eventRequest.Ticket)
                    {
                        if (ticketRequest.Quantity > 0 && ticketRequest.Price > 0)
                        {
                            var newTicket = new Ticket
                            {
                                EventId = existingEvent.EventId,
                                Quantity = ticketRequest.Quantity,
                                Price = ticketRequest.Price,
                                Description = ticketRequest.Description,
                                ticketStatus = ticketStatus.available,
                            };

                            existingEvent.Ticket.Add(newTicket);
                        }
                    }
                }



                if (eventRequest.EventCharacterRequests != null)
                {
                   
                    await _repository.DeleteEventCharactersByEventId(existingEvent.EventId);

                   
                    var newEventCharacters = eventRequest.EventCharacterRequests.Select(ec => new EventCharacter
                    {
                        EventCharacterId = Guid.NewGuid().ToString(),
                        EventId = existingEvent.EventId,
                        CharacterId = ec.CharacterId
                    }).ToList();

                    existingEvent.EventCharacters = newEventCharacters;
                }
                if (eventRequest.EventActivityRequests != null)
                {
                    var createDate = existingEvent.EventActivities.FirstOrDefault()?.CreateDate;

                    await _repository.DeleteEventActivityByEventId(existingEvent.EventId);

                    var newEventActivity = eventRequest.EventActivityRequests.Select(ec => new EventActivity
                    {
                        EventActivityId = Guid.NewGuid().ToString(),
                        EventId = existingEvent.EventId, 
                        ActivityId = ec.ActivityId,
                        CreateDate = createDate,
                        UpdateDate = DateTime.UtcNow,
                        Description = ec.Description,
                        CreateBy = ec.CreateBy
                    }).ToList();

                    existingEvent.EventActivities = newEventActivity;
                }

                if (eventRequest.ImagesDeleted != null && eventRequest.ImagesDeleted.Any())
                {
                    foreach (var imageDeletedId in eventRequest.ImagesDeleted)
                    {
                        var imageToDelete = existingEvent.EventImages.FirstOrDefault(i => i.ImageId == imageDeletedId.ImageId);
                        if (imageToDelete != null)
                        {
                            _repository.DeleteEventImageById(imageToDelete.ImageId); 
                        }
                    }
                }
                if (eventRequest.Images != null && eventRequest.Images.Any())
                {
                    var imageTasks = eventRequest.Images.Select(async I => new EventImage
                    {
                        ImageId = Guid.NewGuid().ToString(),
                        ImageUrl = await _image.UploadImageToFirebase(I.ImageUrl),
                        CreateDate = DateTime.Now,
                        EventId = existingEvent.EventId,

                    }).ToList();
                    var images = await System.Threading.Tasks.Task.WhenAll(imageTasks);
                    existingEvent.EventImages = images.ToList();
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
