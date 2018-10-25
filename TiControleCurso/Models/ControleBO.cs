using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TiControleCurso.Models
{
    public class ControleBO
    {
        private string ConexaoBanco()
        {
            return (WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        public List<Aula> InserirAulas(List<Aula> aulas)
        {
            try
            {
                string conexao = ConexaoBanco();

                string inserir = @"INSERT INTO AULAS (NOME, STATUS, ID_USUARIO, UIA, MATERIA, CONSTRUCAO) VALUES (@NOME, @STATUS, @ID_USUARIO, @UIA, @MATERIA, @CONSTRUCAO)";

                using (var sqlConn = new SqlConnection(conexao))
                {
                    using (SqlCommand comm = new SqlCommand(inserir, sqlConn))
                    {
                        sqlConn.Open();

                        for (int i = 0; i < aulas.Count; i++)
                        {
                            comm.Parameters.Add("@NOME", SqlDbType.VarChar, 50).Value = aulas[i].NomeAula;
                            comm.Parameters.Add("@STATUS", SqlDbType.VarChar, 50).Value = aulas[i].Status;
                            comm.Parameters.Add("@ID_USUARIO", SqlDbType.Int).Value = aulas[i].IdUsuario;
                            comm.Parameters.Add("@UIA", SqlDbType.VarChar, 50).Value = aulas[i].Uia;
                            comm.Parameters.Add("@MATERIA", SqlDbType.VarChar, 50).Value = aulas[i].Materia;
                            comm.Parameters.Add("@CONTRUCAO", SqlDbType.Int).Value = aulas[i].Construcao;

                            comm.ExecuteNonQuery();
                        }

                        sqlConn.Close();
                    }
                }
                return (null);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Aula> BuscarAula(List<int> construcao)
        {
            try
            {
                string conexao = ConexaoBanco();

                string stringBuscar = @"SELECT * FROM AULAS WHERE CONSTRUCAO = @CONSTRUCAO";

                SqlConnection sqlConn = new SqlConnection(conexao);

                List<Aula> listaDeAulas = new List<Aula>();

                for (int i = 0; i < construcao.Count; i++)
                {
                    using (SqlCommand leitor = new SqlCommand(stringBuscar, sqlConn))
                    {
                        leitor.Parameters.Add("@CONSTRUCAO", SqlDbType.Int).Value = construcao[i];
                        sqlConn.Open();
                        SqlDataReader dr = leitor.ExecuteReader();

                        while (dr.Read())
                        {
                            Aula aula = new Aula();
                            aula.NomeAula = dr["NOME"].ToString();
                            aula.Status = dr["STATUS"].ToString();
                            aula.IdUsuario = Convert.ToInt32(dr["ID_USUARIO"]);
                            aula.Uia = dr["UIA"].ToString();
                            aula.Materia = dr["MATERIA"].ToString();
                            aula.Construcao = Convert.ToInt32(dr["MATERIA"]);

                            listaDeAulas.Add(aula);
                        }
                        sqlConn.Close();
                    }
                }
                return (listaDeAulas);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}