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

            
        }

        private void BuscarCep(object sender,EventArgs args)
        {
            //logica
            string cep = txtCep.Text.Trim();
            //validacao
            Endereco end = ViaCepServico.BuscarEnderecoViaCEP(cep);

            lblTexto.Text = string.Format("Endereço: {0},{1} {2}", end.Localidade, end.Logradouro, end.Uf);
        }
    }
}
