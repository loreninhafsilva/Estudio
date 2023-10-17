using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public partial class cadAluno : Form
    {
        public cadAluno()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(maskCPF.Text, txtNome.Text, txtEnd.Text, txtNumero.Text, txtBairro.Text, txtCompl.Text, maskCEP.Text, txtCidade.Text, txtEstado.Text, maskTel.Text, txtEmail.Text);

            if (aluno.cadastrarAluno())
                MessageBox.Show("Cadastro realizado com sucesso!");
            else
                MessageBox.Show("Erro no cadastro!");
        }

        private void maskCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno aluno = new Aluno(maskCPF.Text);
            if (e.KeyChar == 13)
            {
                if (aluno.consultarAluno())
                {
                    MessageBox.Show("Aluno já cadastrado!");
                    txtNome.Enabled = false;
                    txtEnd.Enabled = false;
                    txtNumero.Enabled = false;
                    txtBairro.Enabled = false;
                    txtCompl.Enabled = false;
                    maskCEP.Enabled = false;
                    txtCidade.Enabled = false;
                    txtEstado.Enabled = false;
                    maskTel.Enabled = false;
                    txtEmail.Enabled = false;

                }
                else
                {
                    txtNome.Focus();
                    txtNome.Enabled = true;
                    txtEnd.Enabled = true;
                    txtNumero.Enabled = true;
                    txtBairro.Enabled = true;
                    txtCompl.Enabled = true;
                    maskCEP.Enabled = true;
                    txtCidade.Enabled = true;
                    txtEstado.Enabled = true;
                    maskTel.Enabled = true;
                    txtEmail.Enabled = true;
                }
            }
            else
            {
                txtNome.Focus();
            }
            DAO_Conexao.con.Close(); //somente fecha depois de retornar
        }
    }
}
