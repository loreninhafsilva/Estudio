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
    public partial class atuaTurma : Form
    {
        public atuaTurma()
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
            Turma turma = new Turma();
            int m = turma.consultarID(cbModalidade.Text);

            Turma turma3 = new Turma();
            int c = turma3.consultarIDTurma02(m, cbHora.Text, cbDia.Text);

            Turma turma2 = new Turma();
            MySqlDataReader r = turma2.consultarParaAtualizar(c);
            if (r.Read())
            {
                txtProfessor.Text = r["professorTurma"].ToString();
                txtQtdeAlunos.Text = r["nalunosmatriculadosTurma"].ToString();
                txtProfessor.Enabled = false;
                txtQtdeAlunos.Enabled = false;

            }
            else
            {
                MessageBox.Show("Turma não cadastrada!");
                txtProfessor.Enabled = true;
                txtQtdeAlunos.Enabled = true;
            }
            DAO_Conexao.con.Close();
        }

        private void cbModalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHora.Items.Clear();
            cbDia.Items.Clear();
            Turma turma = new Turma();
            int modalidade = turma.consultarID(cbModalidade.Text);

            Turma tr = new Turma();
            MySqlDataReader b = tr.consultarTurmaModalidade02(modalidade);
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
            MySqlDataReader b = tr.consultarTurmaDia02(cbDia.Text);
            while (b.Read())
                cbHora.Items.Add(b["horaTurma"].ToString());
            DAO_Conexao.con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Turma turma = new Turma();
            int m = turma.consultarID02(cbModalidade.Text);
            int c = turma.consultarIDTurma02(m, cbHora.Text, cbDia.Text);

            if (turma.atualizaAtiva(c) == true)
            {
                MessageBox.Show("Modalidade ativa com Sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao ativar");
            }  
        }
    }
}
