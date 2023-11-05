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
            int modalidade = tr.consultarID(cbModalidade.Text);
            MySqlDataReader b = tr.consultarTurmaDia(cbDia.Text, modalidade);
            while (b.Read())
                cbHora.Items.Add(b["horaTurma"].ToString());
            DAO_Conexao.con.Close();
        }

        private void cbHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            Turma turma = new Turma();
            int m = turma.consultarID(cbModalidade.Text);

            int c = turma.consultarIDTurma02(m, cbHora.Text, cbDia.Text);

            Matricula tr = new Matricula();
            MySqlDataReader b = tr.consultarAlunosnaTurma(c);
            while (b.Read())
                cbAlunos.Items.Add(b["nomeAluno"].ToString());
            DAO_Conexao.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Turma turma = new Turma();
            int m = turma.consultarID(cbModalidade.Text);

            int c = turma.consultarIDTurma02(m, cbHora.Text, cbDia.Text);

            Matricula matricula = new Matricula();
            string b = matricula.consultarCPF(cbAlunos.Text);

                if (matricula.excluirMatricula(b, c))
                {
                     int alunos = matricula.consultarAlunos();
                     matricula.diminuirMatricula(alunos,c);
                     MessageBox.Show("Exclusão realizada com sucesso!");
                cbHora.Items.Clear();
                cbDia.Items.Clear();
                cbAlunos.Items.Clear();
                cbDia.Text = "";
                cbHora.Text = "";
                cbAlunos.Text = "";
                cbModalidade.Text = "";

            }
                else
                {
                    MessageBox.Show("Erro ao excluir!");
                }
        }

    }
    
}
