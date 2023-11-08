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

        public bool excluirMatricula(string CPF, int idTurma)
        {
            bool cad = false;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("DELETE FROM Estudio_Matricula WHERE CPFAluno = '" + CPF + "' and idTurma = "+ idTurma+"", DAO_Conexao.con);
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
            int c = alunos;
            c ++;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("update Estudio_Turma set nalunoscadastradosTurma = " + c + " where idEstudio_Turma  = " + idTurma + "", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                Console.WriteLine("nalunoscadastradosTurma" + c);
                Console.WriteLine("update Estudio_Turma set nalunoscadastradosTurma = " + c + " where = " + idTurma + "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return c;

        }

        public int diminuirMatricula(int alunos, int idTurma)
        {
            MySqlDataReader resultado = null;
            int s = 0;
            int c = alunos;
            s = c--;
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
        public MySqlDataReader consultarAlunosnaTurma(int idTurma)
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select Estudio_Aluno.nomeAluno from Estudio_Aluno inner join Estudio_Matricula on Estudio_Matricula.CPFAluno = Estudio_Aluno.CPFAluno and Estudio_Matricula.idTurma = " + idTurma + " and Estudio_Aluno.ativo = 0", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public string consultarCPF(string nome)
        {
            MySqlDataReader resultado = null;
            string b = "";
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT CPFAluno FROM Estudio_Aluno WHERE nomeAluno = '" + nome + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    b = (resultado["CPFAluno"].ToString());
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

       public MySqlDataReader consultarAlunos(int idTurma)
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select Estudio_Aluno.CPFAluno, Estudio_Aluno.nomeAluno from Estudio_Aluno inner join Estudio_Matricula on Estudio_Matricula.CPFAluno = Estudio_Aluno.CPFAluno and Estudio_Matricula.idTurma = " + idTurma + " and Estudio_Aluno.ativo = 0", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public bool consultarTurmaExistente()
        {
            bool existe = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Matricula WHERE idTurma= " + idTurma + "", DAO_Conexao.con);
                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return existe;
        }

        public bool consultarAlunoExistente(string CPFAluno, int idTurma)
        {
            bool existe = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Matricula WHERE CPFAluno= '" + CPFAluno + "' and idTurma= "+ idTurma + "", DAO_Conexao.con);
                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return existe;
        }

    }
}
