using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Serviço.Modelo;
using App01_ConsultarCEP.Serviço;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender,EventArgs args)
        {
            //TO DO - Validação
            string cep = CEP.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2},{4} /{3} {0},{1}", end.localidade, end.uf, end.logradouro, end.bairro, end.complemento);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o cep informado: " + end.cep, "OK");
                    }
                }
                catch (Exception erro)
                {
                    DisplayAlert("ERRO CRÍTICO", erro.Message, "OK");
                }
                
            }

        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");

                valido = false;
            }
            int NovoCep = 0;
            if (!int.TryParse(cep, out NovoCep))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas por números.", "OK");

                valido = false;
            }
            return valido;
        }
    }
}
