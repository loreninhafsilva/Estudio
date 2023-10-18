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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            menuStrip1.Enabled = false;

            if (DAO_Conexao.getConexao("143.106.241.3", "cl202243", "cl202243", "Lorena25"))
                Console.WriteLine("Conectado");
            else
                Console.WriteLine("Erro de conexão");
        }

        private void cadastrarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadAluno form3 = new cadAluno();
            form3.MdiParent = this;
            form3.Show();
            groupBox1.Visible = false;
        }

        private void cadastrarLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadLogin form2 = new cadLogin();
            form2.MdiParent = this;
            form2.Show();
            groupBox1.Visible = false;
        }

        private void consultarTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consTurma consTurma = new consTurma();
            consTurma.MdiParent = this;
            consTurma.Show();
            groupBox1.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int ver = DAO_Conexao.verificaLogin(textBox1.Text, textBox2.Text);
            if (ver == 0)
            {
                MessageBox.Show("Usuário/Senha Inválido!");
            }
            if (ver == 1)
            {
                MessageBox.Show("Usuário Administrador");
                menuStrip1.Enabled = true;
                groupBox1.Visible = false;
            }
            if (ver == 2)
            {
                MessageBox.Show("Usuário Restrito!");
                menuStrip1.Enabled = true;
                groupBox1.Visible = false;
                cadastrarLoginToolStripMenuItem.Enabled = false;
                cadastrarAlunoToolStripMenuItem.Enabled = false;
                cadastrarModalidadeToolStripMenuItem.Enabled = false;
                cadastrarTurmaToolStripMenuItem.Enabled = false;
                excluirAlunoToolStripMenuItem.Enabled = false;
                excluirModalidadeToolStripMenuItem.Enabled = false;
                excluirTurmaToolStripMenuItem.Enabled = false;
                atualizarAlunoToolStripMenuItem.Enabled = false;
                atualizarModalidadeToolStripMenuItem.Enabled = false;
                atualizarTurmaToolStripMenuItem.Enabled = false;
            }
        }

        private void cadastrarAlunoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cadAluno cadAluno = new cadAluno();
            cadAluno.MdiParent = this;
            cadAluno.Show();
            groupBox1.Visible = false;
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void consultarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consAluno form4 = new consAluno();
            form4.MdiParent = this;
            form4.Show();
            groupBox1.Visible = false;
        }

        private void atualizarAlunoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            atuaAluno form5 = new atuaAluno();
            form5.MdiParent = this;
            form5.Show();
            groupBox1.Visible = false;

        }

        private void excluirAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            excAluno form5 = new excAluno();
            form5.MdiParent = this;
            form5.Show();
            groupBox1.Visible = false;
        }

        private void cadastrarModalidadeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cadModalidade form6 = new cadModalidade();
            form6.MdiParent = this;
            form6.Show();
            groupBox1.Visible = false;
        }

        private void consultarModalidadeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            consModalidade form7 = new consModalidade();
            form7.MdiParent = this;
            form7.Show();
            groupBox1.Visible = false;
        }

        private void atualizarModalidadeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            atuaModalidade atualizarModalidade = new atuaModalidade();
            atualizarModalidade.MdiParent = this;
            atualizarModalidade.Show();
            groupBox1.Visible = false;
        }

        private void excluirModalidadeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            excModalidade form8 = new excModalidade();
            form8.MdiParent = this;
            form8.Show();
            groupBox1.Visible = false;
        }

        private void cadastrarTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadTurma form9 = new cadTurma();
            form9.MdiParent = this;
            form9.Show();
            groupBox1.Visible = false;
        }

        private void consultarTurmaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            consTurma consTurma = new consTurma();
            consTurma.MdiParent = this;
            consTurma.Show();
            groupBox1.Visible = false;
        }

        private void excluirTurmaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            excTurma excTurma = new excTurma();
            excTurma.MdiParent = this;
            excTurma.Show();
            groupBox1.Visible = false;
        }

        private void atualizarTurmaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            atuaTurma atuaTurma = new atuaTurma();
            atuaTurma.MdiParent = this;
            atuaTurma.Show();
            groupBox1.Visible = false;
        }
    }
}
