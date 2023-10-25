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
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Turma where = " + idTurma + "", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    b = int.Parse(resultado["nalunoscadastradosTurma"].ToString());
                    Console.WriteLine("ConsultarID " + b);
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
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Turma where = " + idTurma + "", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    b = int.Parse(resultado["nAlunosMaximoTurma "].ToString());
                    Console.WriteLine("ConsultarID " + b);
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
            int b = 0;
            int s = 0;
            s = alunos + 1;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("update Estudio_Matricula set nalunoscadastradosTurma = " + s + " from Estudio_Turma where = " + idTurma + "", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
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
    }
}
