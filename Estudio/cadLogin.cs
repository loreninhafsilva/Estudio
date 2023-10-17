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
    public partial class cadLogin : Form
    {
        public cadLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tipo = 0;
                if (comboBox1.SelectedIndex == 0)
                    tipo = 1; //adm
                else if (comboBox1.SelectedIndex == 1)
                    tipo = 2; //restrito
                if (DAO_Conexao.CadLogin(textBox1.Text, textBox2.Text, tipo))
                    MessageBox.Show("Cadastro realizado com sucesso!");
                else
                    MessageBox.Show("Usuário existente");
        }
    }
}
