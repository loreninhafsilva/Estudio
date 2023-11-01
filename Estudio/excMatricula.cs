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
    public partial class excMatricula : Form
    {
        public excMatricula()
        {
            InitializeComponent();
            Modalidade cad = new Modalidade();
            MySqlDataReader a = cad.consultarTodasModalidade();
            while (a.Read())
                cbModalidade.Items.Add(a["descricaoModalidade"].ToString());
            DAO_Conexao.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cbModalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHora.Items.Clear();
            cbDia.Items.Clear();
            Turma turma = new Turma();
            int modalidade = turma.consultarID(cbModalidade.Text);

            Turma tr = new Turma();
            MySqlDataReader b = tr.consultarTurmaModalidade(modalidade);
            while (b.Read())
                cbDia.Items.Add(b["diasemanaTurma"].ToString());
            DAO_Conexao.con.Close();

            if (cbDia.Items.Count == 0)
            {
                cbDia.Enabled = false;
                cbHora.Enabled = false;
                MessageBox.Show("Turma inexistente. Selecione uma modalidade com turma.");
            }
            else
            {
                cbDia.Enabled = true;
                cbHora.Enabled = true;
            }
        }

        private void cbDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turma tr = new Turma();
            MySqlDataReader b = tr.consultarTurmaDia(cbDia.Text);
            while (b.Read())
                cbHora.Items.Add(b["horaTurma"].ToString());
            DAO_Conexao.con.Close();
        }

        private void cbHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            Matricula tr = new Matricula();
            MySqlDataReader b = tr.consultarAlunosnaTurma();
            while (b.Read())
                cbAlunos.Items.Add(b["nomeAluno"].ToString());
            DAO_Conexao.con.Close();
        }

    }
}
