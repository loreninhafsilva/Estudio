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

namespace Estudio
{
    public partial class atuaModalidade : Form
    {
        public atuaModalidade()
        {
            InitializeComponent();
            Modalidade cad = new Modalidade();
            MySqlDataReader a = cad.consultarTodasModalidade02();
            while (a.Read())
                comboBox1.Items.Add(a["descricaoModalidade"].ToString());
            DAO_Conexao.con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskConsultaPreco.Clear();
            txtAlunos.Text = " ";
            txtAulas.Text = " ";
            Modalidade modalidade = new Modalidade(comboBox1.Text);
            MySqlDataReader r = modalidade.consultarModalidade();

            if (r.Read())
            {
                maskConsultaPreco.Text = r["precoModalidade"].ToString();
                txtAlunos.Text = r["qtdeAlunos"].ToString();
                txtAulas.Text = r["qtdeAulas"].ToString();
            }
            else
            {
                MessageBox.Show("Modalidade não cadastrada!");
            }
            DAO_Conexao.con.Close();
            int b = modalidade.consultarAtivo();
            Console.WriteLine(b);
            if (b == 1)
            {
                button1.Enabled = false;
                btnAtivo.Enabled = true;
                maskConsultaPreco.Enabled = false;
                txtAlunos.Enabled = false;
                txtAulas.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                btnAtivo.Enabled = false;
                maskConsultaPreco.Enabled = true;
                txtAlunos.Enabled = true;
                txtAulas.Enabled = true;
            }
        }

        private void btnAtivo_Click(object sender, EventArgs e)
        {
            Modalidade modalidade = new Modalidade(comboBox1.Text);
            MySqlDataReader r = modalidade.consultarModalidade();
            if (r.Read())
            {
                DAO_Conexao.con.Close();

                if (modalidade.atualizaAtiva(comboBox1.Text))
                {
                    MessageBox.Show("Modalidade ativa com Sucesso");
                    button1.Enabled = true;
                    maskConsultaPreco.Enabled = true;
                    txtAlunos.Enabled = true;
                    txtAulas.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Erro ao ativar");
                }
            }
            else
            {
                MessageBox.Show("Modalidade não encontrada");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float preco = float.Parse(maskConsultaPreco.Text);
            int aulas = int.Parse(txtAulas.Text);
            int alunos = int.Parse(txtAlunos.Text);

            Modalidade modalidade = new Modalidade(comboBox1.Text, preco, alunos, aulas);
            MySqlDataReader r = modalidade.consultarModalidade();
            if (r.Read())
            {
                DAO_Conexao.con.Close();
                if (modalidade.atualizarModalidade(comboBox1.Text))
                {
                    MessageBox.Show("Dados atualizados com Sucesso");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar");
                }
            }
            else
            {
                MessageBox.Show("Modalidade não encontrada");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
