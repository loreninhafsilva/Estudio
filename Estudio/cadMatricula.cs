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
            DAO_Conexao.con.Close();
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
                Matricula matricula2 = new Matricula();
                if(matricula2.consultarAlunoExistente(maskCPF.Text, c) == false)
                {
                    DAO_Conexao.con.Close();
                    if (matricula.cadastrarMatricula())
                        {
                            matricula.somarMatricula(alunos);
                            MessageBox.Show("Matricula realizada com sucesso!");
                            cbModalidade.Text = "";
                            cbHora.Text = "";
                            cbHora.Items.Clear();
                            cbDia.Text = "";
                            cbDia.Items.Clear();
                            txtNome.Text = "";
                            maskCPF.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Erro ao matricular!");
                        cbModalidade.Text = "";
                        cbHora.Text = "";
                        cbHora.Items.Clear();
                        cbDia.Text = "";
                        cbDia.Items.Clear();
                        txtNome.Text = "";
                        maskCPF.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Aluno já existente na turma");
                    cbModalidade.Text = "";
                    cbHora.Text = "";
                    cbHora.Items.Clear();
                    cbDia.Text = "";
                    cbDia.Items.Clear();
                    txtNome.Text = "";
                    maskCPF.Text = "";
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

            if (cbDia.Items.Count != 0)
            {
                cbDia.Enabled = true;
                cbHora.Enabled = true;
            }
            else
            {
                cbDia.Enabled = false;
                cbHora.Enabled = false;
                MessageBox.Show("Turma inexistente. Selecione uma modalidade com turma.");
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
