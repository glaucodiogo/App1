using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1.Service.Model;
using Newtonsoft.Json;

namespace App1.Service
{
    public class ViaCepServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if(end.Cep == null)
            {
                return null;
            }
            else
            {
                return end;

            }

        }
    }
}
