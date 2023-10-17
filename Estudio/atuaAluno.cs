using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Estudio
{
    public partial class atuaAluno : Form
    {
        public atuaAluno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(maskCPF.Text, txtNome.Text, txtEnd.Text, txtNumero.Text, txtBairro.Text, txtCompl.Text, maskCEP.Text, txtCidade.Text, txtEstado.Text, maskTel.Text, txtEmail.Text);
            if (aluno.consultarAluno())
            {
                DAO_Conexao.con.Close();
                if (aluno.atualizarAluno())
                {
                    MessageBox.Show("Dados atualizados com Sucesso");
                    txtBairro.Text = " ";
                    maskCEP.Text = " ";
                    txtCidade.Text = "  ";
                    txtCompl.Text = " ";
                    maskCPF.Text = " ";
                    txtEmail.Text = " ";
                    txtEnd.Text = " ";
                    txtEstado.Text = " ";
                    txtNome.Text = " ";
                    txtNumero.Text = " ";
                    maskTel.Text = " ";
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar");
                }
            }
            else
            {
                MessageBox.Show("CPF não encontrado");
            }
        }

        private void maskCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            Aluno aluno = new Aluno(maskCPF.Text);
            if (e.KeyChar == 13)
            {
                int b = aluno.consultarAtivo();
                Console.WriteLine(b);
                if (b == 1)
                {
                    btnAtivo.Enabled = true;
                }
                else
                {
                    btnAtivo.Enabled = false;
                }
                DAO_Conexao.con.Close();

                MySqlDataReader r = aluno.consultarAluno01();
                if (r.Read())
                {
                    txtNome.Text = r["nomeAluno"].ToString();
                    txtEnd.Text = r["ruaAluno"].ToString();
                    txtNumero.Text = r["numeroAluno"].ToString();
                    txtBairro.Text = r["bairroAluno"].ToString();
                    txtCompl.Text = r["complementoAluno"].ToString();
                    maskCEP.Text = r["CEPAluno"].ToString();
                    txtCidade.Text = r["cidadeAluno"].ToString();
                    txtEstado.Text = r["estadoAluno"].ToString();
                    maskTel.Text = r["telefoneAluno"].ToString();
                    txtEmail.Text = r["emailAluno"].ToString();
                }
                else
                {
                    MessageBox.Show("Aluno não cadastrado!");
                }


            }
            DAO_Conexao.con.Close(); //somente fecha depois de retornar
        }

        private void btnAtivo_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(maskCPF.Text);
            MySqlDataReader r = aluno.consultarAluno01();
            if (r.Read())
            {
                DAO_Conexao.con.Close();
                if (aluno.atualizaAtivo())
                {
                    MessageBox.Show("Aluno ativo com Sucesso");
                }
                else
                {
                    MessageBox.Show("Erro ao ativar");
                }
            }
      
        }
    }
}
