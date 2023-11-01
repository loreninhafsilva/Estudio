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
    public partial class cadMatricula : Form
    {
        public cadMatricula()
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

            int c = turma.consultarIDTurma02(m, cbHora.Text, cbDia.Text);

            Matricula matricula = new Matricula(maskCPF.Text, c);
            int alunos = matricula.consultarAlunos();
            int alunosMaximo = matricula.consultarMaximo();
            if (alunosMaximo == alunos)
            {
                MessageBox.Show("Turma cheia!");
            }
            else
            {
                if (matricula.cadastrarMatricula())
                {
                    matricula.somarMatricula(alunos);
                    MessageBox.Show("Matricula realizada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao matricular!");
                }
            }
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

        private void maskCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno aluno = new Aluno(maskCPF.Text);
            if (e.KeyChar == 13)
            {
                if (aluno.consultarAluno())
                {
                   DAO_Conexao.con.Close();
                   txtNome.Text = aluno.consultarAluno03(maskCPF.Text);
                   DAO_Conexao.con.Close();
                   txtNome.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Aluno não cadastrado!");
                    DAO_Conexao.con.Close();
                    cadAluno cadAluno = new cadAluno();
                    cadAluno.Show();
                    this.Close();
                }
            }
        }
    }
}
