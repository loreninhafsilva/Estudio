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
        private void cbModalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbHora.Items.Clear();
            cbDia.Items.Clear();
            Turma turma = new Turma();
            int modalidade = turma.consultarID(cbModalidade.Text);
            DAO_Conexao.con.Close();

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
            cbHora.Items.Clear();
            cbDia.Items.Clear();
            Turma turma = new Turma();
            int m = turma.consultarID02(cbModalidade.Text);
            int c = turma.consultarIDTurma02(m, cbHora.Text, cbDia.Text);

            if (turma.atualizaAtiva(c))
            {
                MessageBox.Show("Modalidade ativa com Sucesso");
                button2.Enabled = false;
                txtProfessor.Enabled = true;
                txtQtdeAlunos.Enabled = true;
            }
            else
            {
                MessageBox.Show("Erro ao ativar");
            }
            DAO_Conexao.con.Close();
        }

        private void cbHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turma turma = new Turma();
            int m = turma.consultarID(cbModalidade.Text);
            int c = turma.consultarIDTurma02(m, cbHora.Text, cbDia.Text);
            MySqlDataReader r = turma.consultarParaAtualizar02(c);
            if (r.Read())
            {
                txtProfessor.Text = r["professorTurma"].ToString();
                txtQtdeAlunos.Text = r["nalunosmatriculadosTurma"].ToString();
                txtProfessor.Enabled = true;
                txtQtdeAlunos.Enabled = true;
                button2.Enabled = false;
            }
            else
            {
                MessageBox.Show("Turma inativa!");
                txtProfessor.Enabled = true;
                txtQtdeAlunos.Enabled = true;
            }
            DAO_Conexao.con.Close();
            if (turma.consultarAtivo(c) == 1)
            {
                button2.Enabled = true;
                txtProfessor.Enabled = false;
                txtQtdeAlunos.Enabled = false;
            }
            DAO_Conexao.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Turma turma = new Turma();
            int c = turma.consultarID(cbModalidade.Text);
            int alunos = int.Parse(txtQtdeAlunos.Text);
            int m = turma.consultarIDTurma02(c, cbHora.Text, cbDia.Text);
            if (turma.atualizarTurma(m, alunos, txtProfessor.Text, cbHora.Text, cbDia.Text))
                {
                    MessageBox.Show("Dados atualizados com Sucesso");
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar");
                }
        }
    }
}
