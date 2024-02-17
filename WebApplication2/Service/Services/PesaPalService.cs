using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication2.DTOs;
using WebApplication2.Service.IService;
using WebApplication2.Repository.IRepository;

namespace WebApplication2.Service.Services
{
    public class PesaPalService : IPesaPalService
    {
        private readonly IPesaPalRepository _Repository;

        public PesaPalService(IPesaPalRepository Repository)
        {
            _Repository = Repository ?? throw new ArgumentNullException(nameof(Repository));

        }

        public async Task<PesapalAuthResponse> RequestTokenAsync(string consumerKey, string consumerSecret)
        {
            var request = new PesapalAuthRequest
            {
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
            };

            return await _Repository.RequestTokenAsync(request);
        }

        public async Task<RegisterIPNResponseDTO> RegisterIPNUrlAsync(string url, string ipnNotificationType, string accessToken)
        {
            var request = new RegisterIPNRequestDTO
            {
                Url = url,
                IpnNotificationType = ipnNotificationType
            };

            return await _Repository.RegisterIPNUrlAsync(request);
        }

        public async Task<List<GetIPNListResponseDTO>> GetIPNListAsync(string accessToken)
        {
            return await _Repository.GetIPNListAsync(accessToken);
        }

        public async Task<SubmitOrderResponseDTO> SubmitOrderRequestAsync(string accessToken, SubmitOrderRequestDTO request)
        {
            return await _Repository.SubmitOrderRequestAsync(accessToken, request);
        }

        public async Task<TransactionStatusDTO> GetTransactionStatusAsync(string accessToken, string orderTrackingId)
        {
            return await _Repository.GetTransactionStatusAsync(accessToken, orderTrackingId);
        }
    }
}