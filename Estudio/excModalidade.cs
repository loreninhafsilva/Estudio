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
            Turma turma = new Turma();
            int modalidade = turma.consultarID(comboBox1.Text);
            Turma turma2 = new Turma(modalidade);
            turma2.consultarTodasTurma();
            DAO_Conexao.con.Close();

            Modalidade modalidade2 = new Modalidade(comboBox1.Text);
            modalidade2.consultarTodasModalidade();
            DAO_Conexao.con.Close();

            if (modalidade2.excluirModalidade())
            {
                if(turma2.excluirTurma())
                {
                    MessageBox.Show("Modalidade Excluída!");
                } 
            }
            else
            {
                MessageBox.Show("Deu erro ruim!");
            } 
        }
    }
}
