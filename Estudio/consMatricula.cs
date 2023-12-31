﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estudio
{
    public partial class consMatricula : Form
    {
        public consMatricula()
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
            dataGridView1.Rows.Clear();
            cbHora.Items.Clear();
            cbDia.Items.Clear();
            cbDia.Text = " ";
            cbHora.Text = " ";
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
                cbHora.Items.Clear();
                cbDia.Items.Clear();
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
            MySqlDataReader b = tr.consultarTurmaDia(cbDia.Text,modalidade);
            while (b.Read())
                cbHora.Items.Add(b["horaTurma"].ToString());
            DAO_Conexao.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Turma turma = new Turma();
            int m = turma.consultarID(cbModalidade.Text);

            int c = turma.consultarIDTurma02(m, cbHora.Text, cbDia.Text);

            Matricula con_mod = new Matricula();
            if(con_mod.consultarTurmaExistente() == false)
            {
                DAO_Conexao.con.Close();
                MySqlDataReader r = con_mod.consultarAlunos(c);
                while (r.Read())
                    dataGridView1.Rows.Add(r["CPFAluno"].ToString(), r["nomeAluno"].ToString());
                DAO_Conexao.con.Close();
                cbHora.Items.Clear();
                cbDia.Items.Clear();
                cbDia.Text = "";
                cbHora.Text = "";
                cbModalidade.Text = "";
            }
            else
            {
                DAO_Conexao.con.Close();
                MessageBox.Show("Não existe nenhum aluno cadastrado nessa turma.");
            }
        }

    }
}
