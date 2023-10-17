using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    internal class Turma
    {
        private string professor;
        private string dia_semana;
        private string hora;
        private int modalidade;
        private int qtde_alunos;

        public Turma(int modalidade)
        {
            this.modalidade = modalidade;
        }

        public Turma(int modalidade, string dia_semana)
        {
            this.modalidade = modalidade;
            this.dia_semana = dia_semana;
        }

        public Turma()
        {

        }

        public Turma(string professor, string dia_semana, string hora, int modalidade, int qtde_alunos)
        {
            this.Professor = professor;
            this.Dia_semana = dia_semana;
            this.Hora = hora;
            this.Modalidade = modalidade;
            this.Qtde_alunos = qtde_alunos;
        }
        public string Professor { get => professor; set => professor = value; }
        public string Dia_semana { get => dia_semana; set => dia_semana = value; }
        public string Hora { get => hora; set => hora = value; }
        public int Modalidade { get => modalidade; set => modalidade = value; }
        public int Qtde_alunos { get => qtde_alunos; set => qtde_alunos = value; }

        public bool cadastrarTurma()
        {
            bool cad = false;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Turma (professorTurma, idModalidade, diasemanaTurma, horaTurma, nalunosmatriculadosTurma) values " + "('" + Professor + "'," + Modalidade + ",'" + Dia_semana + "','" + hora + "'," + qtde_alunos + ")", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                cad = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return cad;

        }

        public int consultarID(string Modalidade)
        {
            MySqlDataReader resultado = null;
            int b = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT idEstudio_Modalidade FROM Estudio_Modalidade " + "WHERE descricaoModalidade = '" + Modalidade + "' and ativa = 0", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    b = int.Parse(resultado["idEstudio_Modalidade"].ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return b;

        }

        public MySqlDataReader consultarTodasTurma()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT idEstudio_Modalidade FROM Estudio_Turma where ativa = 0 ", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarTurmaModalidade(int modalidade)
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Turma where idModalidade ='" + modalidade + "' and ativa = 0", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarTurmaDia(string dia)
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Turma where diasemanaTurma ='" + dia + "' and ativa = 0 ", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public bool excluirTurma()
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand excluir = new MySqlCommand("update Estudio_Turma set ativa " + "= 1 where idModalidade ='" + Modalidade + "'", DAO_Conexao.con);
                excluir.ExecuteNonQuery();
                exc = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return exc;
        }

        public MySqlDataReader consultarIdTurma(string Modalidade)
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT idEstudio_Turma FROM Estudio_Turma where ativa = 0 and idModalidade = '" + Modalidade + "' ", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarParaAtualizar(int idTurma)
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select Estudio_Modalidade.descricaoModalidade, Estudio_Turma.professorTurma, Estudio_Turma.diasemanaTurma, Estudio_Turma.horaTurma from Estudio_Modalidade inner join Estudio_Turma on Estudio_Modalidade.idEstudio_Modalidade = Estudio_Turma.idModalidade and Estudio_Turma.ativa = 0 and Estudio_Turma.idEstudio_Turma = '" + idTurma + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }
    }
}
