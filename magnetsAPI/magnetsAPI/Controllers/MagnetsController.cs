using magnets.repository;
using magnetsAPI.Models;
using magnetsAPI.Services;
using magnetsEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace magnetsAPI.Controllers
{
    /// <summary>
    /// API Principal
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MagnetsController : ApiController
    {
        //[Route("ReceiverRating")]
        /// <summary>
        /// API recebe o modelo da avaliacao
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ReceiverRating", Name = "ReceiverRating")]
        public HttpResponseMessage ReceiverRating(NPSApiModel model)
        {
            try
            {
                NPSRepository repository = new NPSRepository();

                NPSModel newNPS = new NPSModel();

                newNPS.FAP = model.FAP.Replace(".","");
                newNPS.Celular = model.Celular;
                newNPS.AtendimentoNota = model.AtendimentoNota.Replace(".",",");
                newNPS.InstalacaoNota = model.InstalacaoNota.Replace(".", ",");
                newNPS.RecomendacaoNota = model.RecomendacaoNota.Replace(".", ",");
                newNPS.Observacao = model.Observacao;
                newNPS.DataAvaliacao = Convert.ToDateTime(DateTime.Now);
                newNPS.IDLab = 1;

                repository.Add(newNPS);

                if ((Convert.ToDecimal(newNPS.AtendimentoNota) <= 2) ||
                    (Convert.ToDecimal(newNPS.InstalacaoNota) <= 2) ||
                    (Convert.ToDecimal(newNPS.RecomendacaoNota) <= 2))
                {
                    sendEmail(model);
                }

                var mensagem = "Obrigado! Você receberá um SMS quando seus exames ficarem prontos.";
                SMSSenderService senderService = new SMSSenderService();
                senderService.SendSMS(String.Format(String.Format("55{0}", newNPS.Celular)), mensagem);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /// <summary>
        /// API Envia msg quando tudo estiver pronto
        /// </summary>
        /// <param name="telefone"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SendFinalSMS", Name = "SendFinalSMS")]
        public HttpResponseMessage SendFinalSMS(string telefone)
        {
            try
            {
                SMSSenderService senderService = new SMSSenderService();
                senderService.SendSMS(String.Format("55{0}", telefone), "Seus resultados estão prontos! Acesso o site http://www.delboniauriemo.com.br");
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Parâmetros insuficientes");
            }
        }

        /// <summary>
        /// API Teste
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("testarRota", Name = "testarRota")]
        public string Testar()
        {
            return "Deu Certo";
        }

        private void sendEmail(NPSApiModel model)
        {
            try
            {
                var _enviarEmail = new EmailSender();
                var pasta = HttpContext.Current.Server.MapPath("~/") + "Content/";
                var strMail = "";
                using (StreamReader objReader = new StreamReader(pasta + "email.html"))
                {
                    // Lê todo o arquivo e o joga em uma variável
                    strMail = objReader.ReadToEnd();
                }
                strMail = strMail.Replace("#DATA", DateTime.Now.ToLongDateString().ToString());
                strMail = strMail.Replace("#FAP", model.FAP);
                strMail = strMail.Replace("#CELULAR",model.Celular);
                strMail = strMail.Replace("#ATENDIMENTO", model.AtendimentoNota);
                strMail = strMail.Replace("#INSTALACAO", model.InstalacaoNota);
                strMail = strMail.Replace("#RECOMENDACAO", model.RecomendacaoNota);
                strMail = strMail.Replace("#OBS", model.Observacao);
                _enviarEmail.SendEmail(strMail, "cmte.lucas@hotmail.com");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
