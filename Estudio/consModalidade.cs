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
    public partial class consModalidade : Form
    {
        public consModalidade()
        {
            InitializeComponent();
            Modalidade cad = new Modalidade();
            MySqlDataReader a = cad.consultarTodasModalidade();
            while (a.Read())
                comboBox1.Items.Add(a["descricaoModalidade"].ToString());
            DAO_Conexao.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modalidade modalidade = new Modalidade(comboBox1.Text);
            MySqlDataReader r = modalidade.consultarModalidade();
            if (r.Read())
            {
                maskConsultaPreco.Text = r["precoModalidade"].ToString();
                txtAlunos.Text = r["qtdeAlunos"].ToString();
                txtAulas.Text = r["qtdeAulas"].ToString();
                maskConsultaPreco.Enabled = false;
                txtAlunos.Enabled = false;
                txtAulas.Enabled = false;

            }
            else
            {
                MessageBox.Show("Modalidade não cadastrada!");
                maskConsultaPreco.Enabled = true;
                txtAlunos.Enabled = true;
                txtAulas.Enabled = true;
            }
            DAO_Conexao.con.Close();
        }
    }
}
