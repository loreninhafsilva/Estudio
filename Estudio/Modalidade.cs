using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Estudio
{
    internal class Modalidade
    {
        private string Descricao;
        private float Preco;
        private int qtde_alunos, qtde_aulas;


        public int Qtde_aulas { get => qtde_aulas; set => qtde_aulas = value; }
        public int Qtde_alunos { get => qtde_alunos; set => qtde_alunos = value; }
        public string Descricao1 { get => Descricao; set => Descricao = value; }
        public float Preco1 { get => Preco; set => Preco = value; }

        public Modalidade(string Descricao, float Preco, int qtde_alunos, int qtde_aulas)
        {
            this.Descricao = Descricao;
            this.Preco = Preco;
            this.qtde_alunos = qtde_alunos;
            this.qtde_aulas = qtde_aulas;

        }

        public Modalidade(string descricao)
        {
            this.Descricao = descricao;
        }

        public Modalidade()
        {

        }

        public bool cadastrarModalidade()
        {
            bool cad = false;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Modalidade (descricaoModalidade, precoModalidade, qtdeAlunos, qtdeAulas) values " + "('" + Descricao1 + "','" + Preco1 + "'," + qtde_alunos + "," + qtde_aulas + ")", DAO_Conexao.con);
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

        public bool excluirModalidade()
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand excluir = new MySqlCommand("update Estudio_Modalidade set ativa " + "= 1 where descricaoModalidade ='" + Descricao + "'", DAO_Conexao.con);
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

        /*public bool encerrarTurma()
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand excluir = new MySqlCommand("UPDATE Estudio_Turma SET Estudio_Turma.ativa = 1 FROM Estudio_Turma AS Estudio_Modalidade inner join Estudio_Turma on Estudio_Modalidade.idEstudio_Modalidade = Estudio_Turma.idModalidade and Estudio_Turma.ativa = 0", DAO_Conexao.con);
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
        }*/

        public MySqlDataReader consultarTodasModalidade()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Modalidade where ativa = 0", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarTodasModalidade02()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Modalidade", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarModalidade()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Modalidade " + "WHERE descricaoModalidade = '" + Descricao + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public int consultaExiste()
        {
            int ver = 2;
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM Estudio_Modalidade " + "WHERE descricaoModalidade = '" + Descricao + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    ver = Convert.ToInt32(resultado["ativa"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ver;
        }

        public bool atualizarModalidade(string Descricao)
        {
            bool result = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand comando = new MySqlCommand("update Estudio_Modalidade set descricaoModalidade = '" + Descricao1 + "', precoModalidade = '" + Preco + "', qtdeAlunos = '" + qtde_alunos + "', qtdeAulas = '" + qtde_aulas + "'" + "WHERE descricaoModalidade = '" + Descricao + "'", DAO_Conexao.con);
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

        public int consultarAtivo()
        {
            MySqlDataReader resultado = null;
            int b = 0;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT ativa FROM Estudio_Modalidade " + "WHERE descricaoModalidade = '" + Descricao + "'", DAO_Conexao.con);
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

        public bool atualizaAtiva(string Descricao)
        {
            bool atl = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualizar = new MySqlCommand("update Estudio_Modalidade set ativa " + "= 0 where descricaoModalidade ='" + Descricao + "'", DAO_Conexao.con);
                atualizar.ExecuteNonQuery();
                atl = true;
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

    
    }
}
