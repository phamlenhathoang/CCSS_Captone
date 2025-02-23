using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract = CCSS_Repository.Entities.Contract;
using Task = System.Threading.Tasks.Task;

namespace CCSS_Service.Services
{
    public interface IContractServices
    {
        Task<List<Contract>> GetAllContract(string searchterm);
        Task<Contract> GetContract(string id);
        Task<string> AddContract(ContractRequest contractRequest);
        Task<string> UpdateContract(string contractId, ContractResponse contractResponse);
        Task<string> DeleteContract(string id);
        Task<string> UpdateStatusContract(string contracId, ContractStatus newStatus);

    }
    public class ContractServices : IContractServices
    {
        private readonly IContractRespository _respository;
        private readonly IContractCharacterRepository _contractCharacterRepository;
        private readonly ICharacterRepository _characterRepository;


        public ContractServices(IContractRespository respository, IContractCharacterRepository contractCharacterRepository, ICharacterRepository characterRepository)
        {
            _respository = respository;
            _contractCharacterRepository = contractCharacterRepository;
            _characterRepository = characterRepository;

        }
        private string GenerateCode(int length = 6)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            string code = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return code;
        }

        public async Task<List<Contract>> GetAllContract(string? searchterm)
        {
            return await _respository.GetAllContract(searchterm);
        }

        public async Task<Contract> GetContract(string id)
        {
            return await _respository.GetContractById(id);
        }

        public async Task<string> DeleteContract(string contractId)
        {
            var contract = await _respository.GetContractById(contractId);
            if (contract == null)
            {
                return "This Contract is not found";
            }
            else
            {
                var result = await _respository.DeleteContract(contract);
                return result ? "Delete Success" : "Delete Failed";
            }
        }

        public async Task<string> AddContract(ContractRequest contractRequest)
        {
            string Code = GenerateCode();
            DateTime StartDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;
            if (!string.IsNullOrEmpty(contractRequest.StartDate) || !string.IsNullOrEmpty(contractRequest.EndDate))
            {
                string[] dateFormats = { "dd/MM/yyyy", "d/MM/yyyy", "dd/M/yyyy", "d/M/yyyy" };

                bool isValidDate = DateTime.TryParseExact(contractRequest.StartDate, dateFormats,
                                                          System.Globalization.CultureInfo.InvariantCulture,
                                                          System.Globalization.DateTimeStyles.None,
                                                          out StartDate);


                bool isValidEndDate = DateTime.TryParseExact(contractRequest.EndDate, dateFormats,
                                                          System.Globalization.CultureInfo.InvariantCulture,
                                                          System.Globalization.DateTimeStyles.None,
                                                          out EndDate);
                if (!isValidDate || !isValidEndDate)
                {
                    return "Date format is incorrect. Please enter the date in the format dd/MM/yyyy, d/MM/yyyy, dd/M/yyyy, d/M/yyyy.";
                }
                if (StartDate < DateTime.Now.Date)
                {
                    return "Start date cannot be in the past.";
                }

                if (EndDate < DateTime.Now.Date)
                {
                    return "End date cannot be in the past.";
                }

                if (StartDate > EndDate)
                {
                    return "End date must be greater than event date.";
                }
            }
            if (contractRequest == null)
            {
                return "contract is null";
            }
            var newContract = new Contract()
            {
                ContractId = Guid.NewGuid().ToString(),
                AccountId = contractRequest.AccountId,
                PackageId = contractRequest.PackageId,
                ContractName = contractRequest.ContractName,
                ContractCode = Code,
                Description = contractRequest.Description,
                Price = contractRequest.Price,
                Amount = contractRequest.Amount,
                Location = contractRequest.Location,
                Signature = false,
                Deposit = contractRequest.Deposit,
                Status = ContractStatus.Pending,
                StartDate = StartDate,
                EndDate = EndDate,
            };
            var result = await _respository.AddContract(newContract);
            if (!result)
            {
                return "Add Contract Failed";
            }

            if (contractRequest.contractCharacterRequests != null && contractRequest.contractCharacterRequests.Any())
            {
                var characterInContract = contractRequest.contractCharacterRequests.Select(c => new ContractCharacter
                {
                    ContractCharacterId = Guid.NewGuid().ToString(),
                    ContracId = newContract.ContractId,
                    CharacterId = c.CharacterId,
                    Quantity = c.Quantity,
                }).ToList();

                var charactersAdded = await _contractCharacterRepository.AddListCharacterInContract(characterInContract);
                if (!charactersAdded)
                    return "Failed to add characters.";

                newContract.CharacterQuantity = await _contractCharacterRepository.CountCharactersInContractAsync(newContract.ContractId);
                await _respository.UpdateContract(newContract);
            }

            return "Contract and Characters added successfully.";
        }

        public async Task<string> UpdateContract(string contractId, ContractResponse contractResponse)
        {
            var contractExicting = await _respository.GetContractById(contractId);
            if (contractExicting == null)
            {
                return "Contract is not found";
            }
            contractExicting.PackageId = contractResponse.PackageId;
            contractExicting.ContractName = contractResponse.ContractName;
            contractExicting.Description = contractResponse.Description;
            contractExicting.Price = contractResponse.Price;
            contractExicting.Amount = contractResponse.Amount;
            contractExicting.Signature = contractResponse.Signature;
            contractExicting.Deposit = contractResponse.Deposit;
            contractExicting.Status = contractResponse.Status;
            contractExicting.EndDate = DateTime.Now;

            var result = await _respository.UpdateContract(contractExicting);
            return result ? "Update Success" : "Update Failed";
        }

        public async Task<string> UpdateStatusContract(string contracId, ContractStatus newStatus)
        {
            var contract = await _respository.GetContractById(contracId);
            if (contract == null)
            {
                return "Contract is not found";
            }
            switch (contract.Status)
            {
                case ContractStatus.Pending:
                        
                    if (newStatus != ContractStatus.Browsed && newStatus != ContractStatus.Cancel)
                    {
                        return "Pending contracts can only be changed to Browsed or Canceled.";
                    }
                    contract.Status = newStatus;
                    await _respository.UpdateContract(contract);
                    break;
                case ContractStatus.Browsed:
                    if (newStatus != ContractStatus.Progressing && newStatus != ContractStatus.Cancel)
                    {
                        return "Browsed contracts can only be changed to Progressing or Canceled.";
                    }
                    contract.Status = newStatus;
                    await _respository.UpdateContract(contract);
                    break;
                case ContractStatus.Progressing:
                    if (newStatus != ContractStatus.Completed & newStatus != ContractStatus.Cancel)
                    {
                        return "Progressing contracts can only be changed to Completed or Canceled.";
                    }
                    contract.Status = newStatus;
                    await _respository.UpdateContract(contract);
                    break;
                default:
                    break;
            }

            return $"Update status {newStatus} of contract is completed";
        }
    }
}
