using Api_CEP.Model;
using Api_CEP.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Api_CEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            botao.Clicked += botao_Clicked;
        }

        private void botao_Clicked(object sender, EventArgs e)
        {
            string id = cep.Text.Trim();

            if (IsValidCep(cep.Text))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(id);

                    resultado.Text = String.Format("Endereço : {0}, {1} {2}", end.localidade, end.uf, end.logradouro);
                }
                catch(Exception exc)
                {
                    DisplayAlert("ERRO", exc.Message, "OK");
                }
            }
        }

        public bool IsValidCep(string cep)
        {
            bool valido = true;
            /*if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "Cep Inválido! O Cep deve conter 8 caracteres", "OK");
                valido = false;
            }*/
            int novoCep = 0;
            if (!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("ERRO", "Cep Inválido! O Cep deve conter apenas numeros", "OK");

                valido = false;
            }

            return valido;
        }
    }
}
