using System;
using System.Collections.Generic;
using System.Text;
//// adicionadas
using System.Net;
using App01_ConsultarCEP.Serviço.Modelo;
using Newtonsoft.Json;


namespace App01_ConsultarCEP.Serviço
{
    public class ViaCEPServico
    {
        //endereco sem parametro declarado
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        //metodo de busca de endereco
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            //passa o parametro e retorna o novo endereco URL
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            //conecta com a internet
            WebClient wc = new WebClient();
            
            //faz o download do texto
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            //passa os valores para as classe
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            //retorna o endereco E TESTA SE É NULO
            if (end.cep == null) return null;
            return end;
        }
    }
}
