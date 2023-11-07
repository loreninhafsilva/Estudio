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
            byte[] foto = ConverterFotoParaByteArray();
            Aluno aluno = new Aluno(maskCPF.Text, txtNome.Text, txtEnd.Text, txtNumero.Text, txtBairro.Text, txtCompl.Text, maskCEP.Text, txtCidade.Text, txtEstado.Text, maskTel.Text, txtEmail.Text, foto);

            if (aluno.cadastrarAluno())
            {
                MessageBox.Show("Cadastro realizado com sucesso!");
                maskCPF.Clear();
                txtNome.Text = "" ;
                txtEnd.Text = "";
                txtNumero.Text = "";
                txtBairro.Text = "";
                txtCompl.Text = "";
                maskCEP.Text = "";
                txtCidade.Text = "";
                txtEstado.Text = "";
                maskTel.Text = "";
                txtEmail.Text = "";
                pictureBox1.Image = null;
            }
                
            else
                MessageBox.Show("Erro no cadastro!");
        }

        private void maskCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Aluno aluno = new Aluno(maskCPF.Text);
                if (aluno.verificaCPF() == true)
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
                    MessageBox.Show("CPF inválido!");
                    maskCPF.Clear();
                }
            }
            DAO_Conexao.con.Close(); //somente fecha depois de retornar
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Abrir foto";
            dialog.Filter = "JPG(*.jpg)|*.jpg" + "|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(dialog.OpenFile());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel carregar a foto" + ex.Message);
                }
            }
            dialog.Dispose();
        }

        private byte[] ConverterFotoParaByteArray()
        {
            using (var stream = new System.IO.MemoryStream())
            {
                pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                byte[] bArray = new byte[stream.Length];
                stream.Read(bArray, 0, System.Convert.ToInt32(stream.Length));
                return bArray;
            }
        }
    }
}
