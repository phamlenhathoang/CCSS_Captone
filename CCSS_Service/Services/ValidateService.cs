using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CCSS_Repository.Entities.Task;

namespace CCSS_Service.Services
{
    public interface IValidateService
    {
        Task<bool> UpdateValidate(bool validate);
        Task<bool> GetValidate();
    }
    public class ValidateService : IValidateService
    {
        private readonly ITaskRepository taskRepository;
        private readonly IRequestRepository requestRepository;

        public ValidateService(ITaskRepository taskRepository, IRequestRepository requestRepository)
        {
            this.taskRepository = taskRepository;
            this.requestRepository = requestRepository;
        }

        public async Task<bool> GetValidate()
        {
            try
            {
                List<Task> tasks = await taskRepository.GetAllTask();
                return tasks[0].IsValidate;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateValidate(bool validate)
        {
            try
            {
                List<Task> tasks = await taskRepository.GetAllTask();
                List<Request> requests = await requestRepository.GetAllRequest();   

                foreach (Task task in tasks)
                {
                    task.IsValidate = validate;

                    bool result = await taskRepository.UpdateTask(task);
                    if (!result)
                    {
                        throw new Exception("Can not update task");
                    }
                }

                foreach (Request request in requests)
                {
                    request.IsValidate = validate;
                    await requestRepository.UpdateRequest(request);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
    }
}
