using CCSS_Repository.Entities;
using CCSS_Repository.Repositories;
using CCSS_Service.Libraries;
using CCSS_Service.Model.Requests;
using CCSS_Service.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Services
{
    public interface IContractImageService
    {
        Task<List<ContractImgeResponse>>  GetContractImageByContractIdAndStatus(string contractId, string status);
        Task<ContractImgeResponse>  GetContractImageByContractImageId(string contractImageId);
        Task<bool>  UpdateContractImage(string contractImageId, ContractImageRequest contractImageRequest);
    }
    public class ContractImageService : IContractImageService
    {
        private readonly IContractImageRepository contractImageRepository;
        private readonly IContractRespository contractRespository;

        public ContractImageService(IContractImageRepository contractImageRepository, IContractRespository contractRespository)
        {
            this.contractImageRepository = contractImageRepository;
            this.contractRespository = contractRespository;
        }
        public async Task<List<ContractImgeResponse>> GetContractImageByContractIdAndStatus(string contractId, string status)
        {
            try
            {
                List<ContractImgeResponse> contractImgeResponses = new List<ContractImgeResponse>();
                Contract contract = await contractRespository.GetContractById(contractId);
                if (contract == null)
                {
                    throw new Exception("Contract does not exist");
                }

                if(contract.ContractImages.Count > 0)
                {
                    foreach(var contractImage in contract.ContractImages)
                    {
                        if (contractImage.Status.ToString().ToLower().Equals(status.ToLower()))
                        {
                            var contractImageResponse = new ContractImgeResponse()
                            {
                                ContractId = contractImage.ContractId,
                                ContractImageId = contractImage.ContractImageId,
                                CreateDate = contractImage.CreateDate.ToString("dd/MM/yyyy"),
                                UpdateDate = contractImage.UpdateDate?.ToString("dd/MM/yyyy"),
                                Status = contractImage.Status.ToString(),
                                UrlImage = contractImage.UrlImage,
                            };

                            contractImgeResponses.Add(contractImageResponse);
                        }
                    }
                }

                return contractImgeResponses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ContractImgeResponse> GetContractImageByContractImageId(string contractImageId)
        {
            try
            {
                ContractImage contractImage = await contractImageRepository.GetContractImageByContractImageId(contractImageId);
                if(contractImage == null)
                {
                    throw new Exception("ContractImage does not exist");
                }
                ContractImgeResponse contractImgeResponse = new ContractImgeResponse()
                {
                    ContractId = contractImage.ContractId,
                    ContractImageId = contractImage.ContractImageId,
                    CreateDate = contractImage.CreateDate.ToString("dd/MM/yyyy"),
                    UpdateDate = contractImage.UpdateDate?.ToString("dd/MM/yyyy"),
                    Status = contractImage.Status.ToString(),
                    UrlImage = contractImage.UrlImage
                };

                return contractImgeResponse;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateContractImage(string contractImageId, ContractImageRequest contractImageRequest)
        {
            try
            {
                Image image = new Image();
                ContractImage contractImage = await contractImageRepository.GetContractImageByContractImageId(contractImageId);
                if (contractImage == null)
                {
                    throw new Exception("ContractImage does not esxist");
                }
                if (contractImageRequest.ContractId != null)
                {
                    Contract contract = await contractRespository.GetContractById(contractImageRequest.ContractId);
                    if (contract == null)
                    {
                        throw new Exception("Contract does not exist");
                    }

                    contractImage.ContractId = contract.ContractId;
                }

                contractImage.UrlImage = await image.UploadImageToFirebase(contractImageRequest.UrlImage);
                contractImage.UpdateDate = DateTime.Now;

                if (contractImageRequest.Status != null)
                {
                    if(contractImageRequest.Status.ToLower().Equals(ContractImageStatus.Refund.ToString().ToLower()) || contractImageRequest.Status.ToLower().Equals(ContractImageStatus.Received.ToString().ToLower()) || contractImageRequest.Status.ToLower().Equals(ContractImageStatus.Delivering.ToString().ToLower()))
                    {
                        throw new Exception("Status wrong");
                    }

                    if (contractImageRequest.Status.ToLower().Equals(ContractImageStatus.Refund.ToString().ToLower())){
                        contractImage.Status = ContractImageStatus.Refund;
                    }
                    if (contractImageRequest.Status.ToLower().Equals(ContractImageStatus.Received.ToString().ToLower())){
                        contractImage.Status = ContractImageStatus.Received;
                    }
                    if (contractImageRequest.Status.ToLower().Equals(ContractImageStatus.Delivering.ToString().ToLower())){
                        contractImage.Status = ContractImageStatus.Delivering;
                    }
                }

                bool result = await contractImageRepository.UpdateContractImage(contractImage);
                if (!result) 
                {
                    throw new Exception("Can not update ContractImage");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
