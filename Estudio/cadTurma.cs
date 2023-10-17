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
    public partial class cadTurma : Form
    {
        public cadTurma()
        {
            InitializeComponent();
            Modalidade con_mod = new Modalidade();
            MySqlDataReader r = con_mod.consultarTodasModalidade();
            while (r.Read())
                dataGridView1.Rows.Add(r["descricaoModalidade"].ToString());
            DAO_Conexao.con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow linha = dataGridView1.Rows[e.RowIndex];
            txtModalidade.Text = linha.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Turma turma = new Turma();
            int modalidade = turma.consultarID(txtModalidade.Text);
            if (modalidade == 0)
            {
                MessageBox.Show("Selecione uma modalidade ativa.");
                txtModalidade.Text = " ";
                txtDia.Text = " ";
                txtProfessor.Text = " ";
                txtQtdeAlunos.Text = " ";
                maskHora.Text = " ";
            }
            else
            {
                int qtde_alunos = int.Parse(txtQtdeAlunos.Text);
                Turma turma3 = new Turma();
                modalidade = turma3.consultarID(txtModalidade.Text);
                Turma turma2 = new Turma(txtProfessor.Text, txtDia.Text, maskHora.Text, modalidade, qtde_alunos);
                if (turma2.cadastrarTurma())
                {
                    MessageBox.Show("Cadastro realizado com sucesso!");
                    txtDia.Text = " ";
                    txtProfessor.Text = " ";
                    txtQtdeAlunos.Text = " ";
                    maskHora.Text = " ";
                }
                   
                else
                    MessageBox.Show("Erro no cadastro!");
            }
        }
    }
}
