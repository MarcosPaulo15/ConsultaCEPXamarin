using Api_CEP.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Api_CEP.Services
{
    public class ViaCepServico
    {
        public static string enderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string novoEndURL = string.Format(enderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEndURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            return end;
        }
    }
}
