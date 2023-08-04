using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14___Sistema_de_cadastro
{
    public partial class Cadastro : Form
    {
        List<Pessoa>ListaCadastros;
        
        public Cadastro()
        {
            InitializeComponent();

            ListaCadastros = new List<Pessoa>();

            // Opções para Estado Civil
            comboEC.Items.Add("Solteiro");
            comboEC.Items.Add("Casado");
            comboEC.Items.Add("Marital");
            comboEC.Items.Add("Separado");

            comboEC.SelectedIndex = 0;
        }

        private void buttonCadastAlt_Click(object sender, EventArgs e)
        {
         
            // Validação para verificar se o nome é repetido
            int validacao = -1; 
            
            foreach (Pessoa pessoa in ListaCadastros)
            {
                if(pessoa.Nome == txtNome.Text)
                {
                    validacao = ListaCadastros.IndexOf(pessoa);

                }
            }

            // Validação para verificar se o nome está vazio
            if (txtNome.Text == "")
            {
                MessageBox.Show("Preencha o campo nome");
                txtNome.Focus();
                return;
            }
            
            // Validação para verificar se o telefone está vazio
            if (txtTelefone.Text == "(  )      -")
            {
                MessageBox.Show("Preencha o campo telefone");
                txtTelefone.Focus();
                return;
            }


            // Definição do sexo em caracter

            char sexo; 
            
            if (radioM.Checked)
            {
                sexo = 'M';
            }
            else if (radioF.Checked)
            {
                sexo = 'F';
            }
            else
            {
                sexo = 'O';
            }

            
            // Vínculo dos atributos da classe Pessoa com as formas 
            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.DataNascimento = txtData.Text;
            p.EstadoCivil = comboEC.SelectedItem.ToString();
            p.Telefone = txtTelefone.Text;
            p.CasaPropria = checkCasa.Checked;
            p.Veículo = checkVeiculo.Checked;
            p.Sexo = sexo;

            //Verificar se é um novo cadastro ou se é alteração de cadastro já existente
            if (validacao < 0)
            {
                ListaCadastros.Add(p);
            }
            else
            {
                ListaCadastros[validacao] = p;
            }

            buttonLimpar_Click(buttonLimpar, EventArgs.Empty);

            Listar();



        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            // Remover a linha selecionada na lista
            int indice = Lista.SelectedIndex;
            ListaCadastros.RemoveAt(indice);
            Listar();

        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtData.Text = "";
            comboEC.SelectedIndex = 0;
            txtTelefone.Text = "";
            checkCasa.Checked = false;
            checkVeiculo.Checked = false;
            radioM.Checked = true;
            radioF.Checked = false;
            radioO.Checked = false;
            txtNome.Focus();

        }

        private void Listar()
        {
            Lista.Items.Clear();

            foreach (Pessoa p in ListaCadastros)
            {
                Lista.Items.Add(p.Nome);
            }
        }

        private void Lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = Lista.SelectedIndex;
            Pessoa p = ListaCadastros[indice];

            txtNome.Text = p.Nome;
            txtData.Text = p.DataNascimento;
            comboEC.SelectedItem = p.EstadoCivil;
            txtTelefone.Text = p.Telefone;
            checkCasa.Checked = p.CasaPropria;
            checkVeiculo.Checked = p.Veículo;
            
            switch (p.Sexo)
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                default:
                    radioO.Checked = true;
                    break;
            }


        }
    }
}
