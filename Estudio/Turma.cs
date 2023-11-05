using MySql.Data.MySqlClient;
using System;

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
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Turma (professorTurma, idModalidade, diasemanaTurma, horaTurma, nAlunosMaximoTurma) values ('" + Professor + "'," + Modalidade + ",'" + Dia_semana + "','" + hora + "'," + qtde_alunos + ")", DAO_Conexao.con);
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
                MySqlCommand consulta = new MySqlCommand("SELECT idEstudio_Modalidade FROM Estudio_Modalidade WHERE descricaoModalidade = '" + Modalidade + "' and ativa = 0", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    b = int.Parse(resultado["idEstudio_Modalidade"].ToString());
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

        public MySqlDataReader consultarTurmaDia(string dia, int idModalidade)
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Turma where diasemanaTurma ='" + dia + "' and ativa = 0 and idModalidade = '"+ idModalidade + "'", DAO_Conexao.con);
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
                MySqlCommand excluir = new MySqlCommand("update Estudio_Turma set ativa = 1 where idModalidade ='" + Modalidade + "'", DAO_Conexao.con);
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
                MySqlCommand consulta = new MySqlCommand("select Estudio_Turma.nAlunosMaximoTurma, Estudio_Turma.professorTurma, Estudio_Turma.diasemanaTurma, Estudio_Turma.horaTurma from Estudio_Turma inner join Estudio_Modalidade on Estudio_Modalidade.idEstudio_Modalidade = Estudio_Turma.idModalidade and Estudio_Turma.ativa = 0 and Estudio_Turma.idEstudio_Turma = '" + idTurma + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarTodasTurma02()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Turma where ativa = 0 ", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public int consultarIDTurma02(int Modalidade, string hora, string dia_semana)
        {
            MySqlDataReader resultado = null;
            int b = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT idEstudio_Turma FROM Estudio_Turma WHERE idModalidade = " + Modalidade + " and horaTurma = '" + hora + "' and diasemanaTurma = '" + dia_semana +"'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    b = int.Parse(resultado["idEstudio_Turma"].ToString());
                    Console.WriteLine("ConsultarIDTurma02 " + b);
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
        public MySqlDataReader consultarTurmaModalidade02(int modalidade)
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Turma where idModalidade ='" + modalidade + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public bool atualizaAtiva(int id)
        {
            bool atl = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualizar = new MySqlCommand("update Estudio_Turma set ativa = 0 where idEstudio_Turma =" + id, DAO_Conexao.con);
                atualizar.ExecuteNonQuery();
                atl = true;
                Console.WriteLine("AtualizaAtiva: " + id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return atl;
        }

        public bool atualizaAtiva02(int id)
        {
            bool atl = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualizar = new MySqlCommand("update Estudio_Turma set ativa = 0 where idModalidade =" + id, DAO_Conexao.con);
                atualizar.ExecuteNonQuery();
                atl = true;
                Console.WriteLine("AtualizaAtiva: " + id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return atl;
        }

        public MySqlDataReader consultarTurmaDia02(string dia)
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Turma where diasemanaTurma ='" + dia + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public int consultarID02(string Modalidade)
        {
            MySqlDataReader resultado = null;
            int b = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT idEstudio_Modalidade FROM Estudio_Modalidade WHERE descricaoModalidade = '" + Modalidade + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    b = int.Parse(resultado["idEstudio_Modalidade"].ToString());
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

        public MySqlDataReader consultarParaAtualizar02(int idTurma)
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select Estudio_Turma.nAlunosMaximoTurma, Estudio_Turma.professorTurma, Estudio_Turma.diasemanaTurma, Estudio_Turma.horaTurma from Estudio_Turma inner join Estudio_Modalidade on Estudio_Modalidade.idEstudio_Modalidade = Estudio_Turma.idModalidade and Estudio_Turma.idEstudio_Turma = " + idTurma + "", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public int consultarAtivo(int id)
        {
            MySqlDataReader resultado = null;
            int b = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT ativa FROM Estudio_Turma WHERE idEstudio_Turma = " + id + "", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    b = int.Parse(resultado["ativa"].ToString());
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

        public bool atualizarTurma(int m, int alunos, string professor, string hora, string dia)
        {
            bool result = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand comando = new MySqlCommand("update Estudio_Turma set nAlunosMaximoTurma = " + alunos + ", professorTurma = '" + professor + "', diasemanaTurma = '" + dia + "' WHERE idEstudio_Turma = " + m + "", DAO_Conexao.con);
                comando.ExecuteNonQuery();
                result = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return result;
        }
    }
}
