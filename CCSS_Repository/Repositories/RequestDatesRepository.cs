using CCSS_Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Repository.Repositories
{
    public interface IRequestDatesRepository
    {
        Task<List<RequestDate>> GetAllRequestDates();
        Task<RequestDate> GetRequestDateById(string id);
        Task<bool> AddListRequestDates(List<RequestDate> requestDate);
        Task<bool> AddRequestDate(RequestDate requestDate);
        Task<bool> UpdateListRequestDates(List<RequestDate> requestDate);
        Task<List<RequestDate>> GetListRequestDateByRequestCharacterId(string requestCharacterId);    
        Task<bool> UpdateRequestDate(RequestDate requestDate);
        Task<bool> DeleteListRequestDateByRequestCharacterId(string requestCharacterId);
        Task<List<RequestDate>> GetListRequestDateByRequestCharacter(string requestCharacterId);
        Task<bool> CheckValidRequestDate(Account account, DateTime startDate, DateTime endDate);
        Task<bool> CheckValidCharacterRequestDate(string requestCharacterId, DateTime startDate, DateTime endDate);
    }

    public class RequestDatesRepository: IRequestDatesRepository
    {
        private readonly CCSSDbContext _context;

        public RequestDatesRepository(CCSSDbContext context)
        {
            _context = context;
        }


        public async Task<List<RequestDate>> GetAllRequestDates()
        {
            return await _context.RequestDates.ToListAsync();
        }

        public async Task<List<RequestDate>> GetListRequestDateByRequestCharacterId(string requestCharacterId)
        {
            return await _context.RequestDates.Include(rc => rc.RequestCharacter).Where(sc => sc.RequestCharacterId.Equals(requestCharacterId)).ToListAsync();
        }

        public async Task<List<RequestDate>> GetListRequestDateByRequestCharacter(string requestCharacterId)
        {
            return await _context.RequestDates.Where(sc => sc.RequestCharacterId.Equals(requestCharacterId)).ToListAsync();
        }

        public async Task<RequestDate> GetRequestDateById(string id)
        {
            return await _context.RequestDates.FirstOrDefaultAsync(sc => sc.RequestDateId.Equals(id));  
        }
        public async Task<bool> AddListRequestDates(List<RequestDate> requestDate)
        {
            _context.RequestDates.AddRange(requestDate);
           return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRequestDate(RequestDate requestDate)
        {
            _context.RequestDates.Update(requestDate);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateListRequestDates(List<RequestDate> requestDate)
        {
            _context.RequestDates.UpdateRange(requestDate);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteListRequestDateByRequestCharacterId(string requestCharacterId)
        {
            try
            {
                var requestDates = await _context.RequestDates.Where(rd => rd.RequestCharacterId.Equals(requestCharacterId)).ToListAsync();
                if (requestDates == null)
                {
                    throw new Exception("RequestCharacterId does not exist");
                }

                _context.RemoveRange(requestDates);
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AddRequestDate(RequestDate requestDate)
        {
            await _context.RequestDates.AddAsync(requestDate);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> CheckValidRequestDate(Account account, DateTime startDate, DateTime endDate)
        {
            RequestCharacter requestCharacter = await _context.RequestsCharacters
                .Include(rq => rq.RequestDates)
                .Where(rq => rq.CosplayerId == account.AccountId)
                .FirstOrDefaultAsync();

            double totalHourTask = (endDate - startDate).TotalHours;

            if (requestCharacter != null)
            {
                // Lọc những requestDate có cùng ngày với startDate để giảm số vòng lặp
                var sameDayRequests = requestCharacter.RequestDates
                    .Where(rd => rd.StartDate.Date == startDate.Date)
                    .ToList();

                for (int i = 0; i < sameDayRequests.Count; i++)
                {
                    var currentTask = sameDayRequests[i];

                    if (currentTask.EndDate.Hour < startDate.Hour)
                    {
                        if(currentTask.EndDate.AddHours(2) > startDate)
                        {
                            return false;
                        }
                    }

                    if (endDate.Hour < currentTask.StartDate.Hour)
                    {
                        if (endDate.AddHours(2) > currentTask.StartDate)
                        {
                            return false;
                        }
                    }

                    if (currentTask.StartDate.Hour == startDate.Hour)
                    {
                        return false;
                    }

                    if (i > 0)
                    {
                        var previousTask = sameDayRequests[i - 1];

                        if(previousTask.EndDate.Hour < startDate.Hour)
                        {
                            if (previousTask.EndDate.AddHours(2) > startDate)
                            {
                                return false;
                            }
                        }

                        if (endDate.Hour < previousTask.StartDate.Hour)
                        {
                            if (endDate.AddHours(2) > previousTask.EndDate)
                            {
                                return false;
                            }
                        }
                    }


                    if (i < sameDayRequests.Count - 1)
                    {
                        var nextTask = sameDayRequests[i + 1];

                        if (nextTask.StartDate.Hour < startDate.Hour)
                        {
                            if (nextTask.StartDate.AddHours(2) > endDate)
                            {
                                return false; // Task sau chưa chuẩn bị đủ 2 giờ
                            }
                        }

                        if (endDate.Hour < nextTask.StartDate.Hour)
                        {
                            if (endDate.AddHours(2) > nextTask.StartDate)
                            {
                                return false;
                            }
                        }
                    }
                }    
            }

            return true;
        }

        public async Task<bool> CheckValidCharacterRequestDate(string requestCharacterId, DateTime startDate, DateTime endDate)
        {
            List<RequestDate> requestDates = await _context.RequestDates.Where(rd => rd.RequestCharacterId.Equals(requestCharacterId)).ToListAsync();
            foreach (RequestDate requestDate in requestDates)
            {
                if(startDate.Date == requestDate.StartDate.Date)
                {
                    return false;
                }

                if(startDate.Date < requestDate.StartDate.Date && requestDate.StartDate.Date < endDate.Date)
                {
                    return false;
                }

                if(requestDate.StartDate.Date == endDate.Date)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
