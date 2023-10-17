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
    public partial class excModalidade : Form
    {
        public excModalidade()
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
            modalidade.consultarTodasModalidade();
            DAO_Conexao.con.Close();
            if (modalidade.excluirModalidade())
            {
                /*if(modalidade.encerrarTurma())*/
                //{
                    MessageBox.Show("Modalidade Excluída!");
                //} 
            }
               else
                {
                    MessageBox.Show("Deu erro ruim!");
                } 
        }
    }
}
