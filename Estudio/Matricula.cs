using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    class Matricula
    {
        private string CPFAluno;
        private int idTurma;

        public Matricula(string cPFAluno, int idTurma)
        {
            CPFAluno1 = cPFAluno;
            this.IdTurma = idTurma;
        }

        public string CPFAluno1 { get => CPFAluno; set => CPFAluno = value; }
        public int IdTurma { get => idTurma; set => idTurma = value; }

        public Matricula()
        {

        }

        public Matricula(int idTurma)
        {
            this.idTurma = idTurma;
        }

        public bool cadastrarMatricula()
        {
            bool cad = false;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Matricula (CPFAluno, idTurma) values ('" + CPFAluno1 + "'," + idTurma + ")", DAO_Conexao.con);
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

        public int consultarAlunos()
        {
            MySqlDataReader resultado = null;
            int b = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Turma where idEstudio_Turma = " + idTurma + "", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    b = int.Parse(resultado["nalunoscadastradosTurma"].ToString());
                    Console.WriteLine("nalunoscadastradosTurma " + b);
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
        public int consultarMaximo()
        {
            MySqlDataReader resultado = null;
            int b = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select nAlunosMaximoTurma from Estudio_Turma where idEstudio_Turma = " + idTurma + "", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    b = int.Parse(resultado["nAlunosMaximoTurma"].ToString());
                    Console.WriteLine("nAlunosMaximoTurma" + b);
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
        public int somarMatricula(int alunos)
        {
            MySqlDataReader resultado = null;
            int s = 0;
            int c = alunos;
            s = c + 1;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("update Estudio_Turma set nalunoscadastradosTurma = " + s + " where idEstudio_Turma  = " + idTurma + "", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                Console.WriteLine("nalunoscadastradosTurma" + s);
                Console.WriteLine("update Estudio_Turma set nalunoscadastradosTurma = " + s + " where = " + idTurma + "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return s;

        }
        public MySqlDataReader consultarAlunosnaTurma()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Turma where idTurma =" + idTurma + " and ativa = 0 ", DAO_Conexao.con);
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
