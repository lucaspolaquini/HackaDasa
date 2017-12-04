using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace magnetsAPI.Services
{
    public class SMSSenderService
    {
        public void SendSMS(String telefone, String mensagem)
        {
            AmazonSimpleNotificationServiceClient smsClient =
              new AmazonSimpleNotificationServiceClient("Public Key", "Private Key", Amazon.RegionEndpoint.USEast1);

            PublishRequest publishRequest = new PublishRequest();
            publishRequest.Message = mensagem;
            publishRequest.PhoneNumber = telefone;

            Task<PublishResponse> result = smsClient.PublishAsync(publishRequest);
        }
    }
}