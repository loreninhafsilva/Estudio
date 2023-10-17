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
    public partial class consAluno : Form
    {
        public consAluno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aluno aluno = new Aluno(maskCPF.Text);
            MySqlDataReader r = aluno.consultarAluno02();
            if (r.Read())
            {
                maskCPF.Text = r["CPFAluno"].ToString();
                txtNome.Text = r["nomeAluno"].ToString();
                txtEnd.Text = r["ruaAluno"].ToString();
                maskCEP.Text = r["CEPAluno"].ToString();
                txtNumero.Text = r["numeroAluno"].ToString();
                txtBairro.Text = r["bairroAluno"].ToString();
                maskTel.Text = r["telefoneAluno"].ToString();
                txtEmail.Text = r["emailAluno"].ToString();
                txtCidade.Text = r["cidadeAluno"].ToString();
                txtCompl.Text = r["complementoAluno"].ToString();
                txtEstado.Text = r["estadoAluno"].ToString();
                txtNome.Enabled = false;
                txtEnd.Enabled = false;
                maskCEP.Enabled = false; 
                txtNumero.Enabled = false; 
                txtBairro.Enabled = false;
                maskTel.Enabled = false;
                txtEmail.Enabled = false;
                txtCidade.Enabled = false;
                txtCompl.Enabled = false;
                txtEstado.Enabled = false;
            }
            else
            {
                MessageBox.Show("Aluno não cadastrado ou inativo!");
            }
            DAO_Conexao.con.Close();
        }
    }
}
