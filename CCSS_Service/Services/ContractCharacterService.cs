using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IContractCharacterService
    {
        Task<bool> AddListContractCharacter(Contract contract); 
        Task<List<ContractCharacterResponse>> GetContractCharactersByContractId(string contractId);
    }
    public class ContractCharacterService : IContractCharacterService
    {
        private readonly IContractCharacterRepository _contractCharacterRepository;
        private readonly IRequestRepository _requestRepository;
        private readonly ITaskService _taskService;
        private readonly IRequestDatesRepository _requestDatesRepository;
        private readonly IContractRespository contractRespository;

        public ContractCharacterService(ITaskService _taskService, IRequestRepository _requestRepository, IContractCharacterRepository _contractCharacterRepository, IRequestDatesRepository requestDatesRepository, IContractRespository contractRespository)
        {
            this._contractCharacterRepository = _contractCharacterRepository;
            this._requestRepository = _requestRepository;
            this._taskService = _taskService;
            this._requestDatesRepository = requestDatesRepository;
            this.contractRespository = contractRespository;
        }
        public async Task<bool> AddListContractCharacter(Contract contract)
        {
            try
            {
                List<ContractCharacter> contractCharacters = new List<ContractCharacter>();

                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }

                if (contract.Request == null)
                {
                    throw new Exception("Request does not exist");
                }

                if (!contract.Request.RequestCharacters.Any())
                {
                    throw new Exception("RequestCharacter does not exist");
                }

                foreach (var requestCharacter in contract.Request.RequestCharacters)
                {
                    ContractCharacter character = new ContractCharacter()
                    {
                        CharacterId = requestCharacter.CharacterId,
                        ContractId = contract.ContractId,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        ContractCharacterId = Guid.NewGuid().ToString(),
                        Description = requestCharacter.Description,
                        TotalPrice = requestCharacter.TotalPrice,   
                        UpdateDate = null,
                        CosplayerId = requestCharacter.CosplayerId,
                        Quantity = requestCharacter.Quantity,
                    };
                     
                    bool checkAdd = await _contractCharacterRepository.AddContractCharacter(character);
                    contractCharacters.Add(character);

                    if (!checkAdd)
                    {
                        throw new Exception("Can not add ContractCharacter");
                    }

                    List<RequestDate> requestDates = await _requestDatesRepository.GetListRequestDateByRequestCharacterId(requestCharacter.RequestCharacterId);

                    foreach(var requestDate in requestDates)
                    {
                        requestDate.ContractCharacterId = character.ContractCharacterId;

                        bool checkUpdate = await _requestDatesRepository.UpdateRequestDate(requestDate);
                        if (!checkUpdate)
                        {
                            throw new Exception("Can not update RequestDate");
                        }
                    }
                }

                List<ContractCharacter> contractCharacters2 = new List<ContractCharacter>();

                foreach (var character in contractCharacters)
                {
                    if(character.CosplayerId != null)
                    {
                        contractCharacters2.Add(character);
                    }
                }

                if (contractCharacters2.Count > 0)
                {
                    string result = await _taskService.AddTask(null, contractCharacters2);

                    if (result != "Successfully")
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ContractCharacterResponse>> GetContractCharactersByContractId(string contractId)
        {
            try
            {
                Contract contract = await contractRespository.GetContractById(contractId);
                List<ContractCharacterResponse> contractCharacters = new List<ContractCharacterResponse>();
                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }

                foreach (var character in contract.ContractCharacters)
                {
                    var contractCharacter = new ContractCharacterResponse()
                    {
                        CharacterId = character.CharacterId,
                        ContractCharacterId = character.ContractCharacterId,
                        ContractId = contractId,
                        CosplayerId = character.CosplayerId,
                        CreateDate = character.CreateDate?.ToString("dd/MM/yyyy") ?? null,
                        Description = character.Description,
                        Quantity = character.Quantity,
                        UpdateDate = character.UpdateDate?.ToString("dd/MM/yyyy") ?? null,
                    };
                    contractCharacters.Add(contractCharacter);
                }
                return contractCharacters;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }
    }
}
