using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Service;
using App1.Service.Model;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnBuscar.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender,EventArgs args)
        {
            string cepFormat = txtCep.Text.Trim();

            if (IsValid(cepFormat))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCEP(cepFormat);

                    if(end != null)
                    {
                        lblTexto.Text = string.Format("Endereço: {0},{1} {2}", end.Localidade, end.Logradouro, end.Uf);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para este cep:"+cepFormat, "OK");
                    }
                    
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro Crítico", e.Message,"OK");
                    throw;
                }
               
            }
                        
        }


        private bool IsValid(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }
            int novoCep = 0;
            if (!int.TryParse(cep,out novoCep))
            {
                DisplayAlert("ERRO", "CEP inválido! OCEP deve ser composto apenas por números.","OK");
                valido = false;
            }


            return valido;
        }
    }
}
