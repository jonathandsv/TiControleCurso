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

                string inserir = @"INSERT INTO AULAS (NOME, STATUS, ID_USUARIO, UIA, MATERIA) VALUES (@NOME, @STATUS, @ID_USUARIO, @UIA, @MATERIA)";

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
    }
}