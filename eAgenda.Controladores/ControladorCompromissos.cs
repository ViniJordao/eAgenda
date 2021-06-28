using eAgenda.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Controladores
{
    public class ControladorCompromissos
    {
        public void InserirNovoCompromisso(Compromissos compromissos)
        {
            SqlConnection con = AbrirConexao();

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = con;

            string sqlInsercao =
                 @"INSERTO INTO TBCOMPROMISSO
                (
                    [ASSUNTO],
                    [LOCAL],
                    [DATACOMPROMISSO],
                    [HORAINICO],
                    [HORATERMINO]
                )
                VALUES
                (
                 @ASSUNTO,   
                 @LOCAL,  
                 @DATACOMPROMISSO, 
                 @HORAINICIO,  
                 @HORATERMINO,
                );";

            sqlInsercao += @"SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("ASSUNTO", compromissos.assunto);
            comandoInsercao.Parameters.AddWithValue("LOCAL", compromissos.local);
            comandoInsercao.Parameters.AddWithValue("DATACOMPROMISSO", compromissos.dataCompromisso);
            comandoInsercao.Parameters.AddWithValue("HORAINICO", compromissos.horaInicio);
            comandoInsercao.Parameters.AddWithValue("HORATERMINO", compromissos.horaTermino);

            object id = comandoInsercao.ExecuteScalar();

            compromissos.Id = Convert.ToInt32(id);

            con.Close();
        }

        public void AtualizarCompromisso(Compromissos compromissos)
        {

            SqlConnection con = AbrirConexao();

            SqlCommand comandoAtualizacao = new SqlCommand();
            comandoAtualizacao.Connection = con;

            string sqlAtualizacao =
                @"UPDATE TBCOMPROMISSO
                    SET
                     [ASSUNTO] = @ASSUNTO,
                     [LOCAL] = @LOCAL,
                     [DATACOMPROMISSO] = @DATACOMPROMISSO,
                     [HORAINICO] = @HORAINICO,
                     [HORATERMINO] = @HORATERMINO
                WHERE   
                    [ID] = @ID";

            comandoAtualizacao.CommandText = sqlAtualizacao;

            comandoAtualizacao.Parameters.AddWithValue("ID", compromissos.Id);
            comandoAtualizacao.Parameters.AddWithValue("ASSUNTO", compromissos.assunto);
            comandoAtualizacao.Parameters.AddWithValue("LOCAL", compromissos.local);
            comandoAtualizacao.Parameters.AddWithValue("DATACOMPROMISSO", compromissos.dataCompromisso);
            comandoAtualizacao.Parameters.AddWithValue("HORAINICO", compromissos.horaInicio);
            comandoAtualizacao.Parameters.AddWithValue("HORATERMINO", compromissos.horaTermino);

            comandoAtualizacao.ExecuteNonQuery();

            con.Close();

        }

        public void ExcluirCompromisso(Compromissos compromissos)
        {
            SqlConnection con = AbrirConexao();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = con;

            string sqlExclusao =
                @"DELETE FROM TBCOMPROMISSO	                
	                WHERE 
		                [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", compromissos.Id);

            comandoExclusao.ExecuteNonQuery();

            con.Close();
        }
        public Compromissos SelecionarCompromissoPorId(int IdPesquisado)
        {
            SqlConnection con = AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT
                        [ASSUNTO],
                        [LOCAL],
                        [DATACOMPROMISSO],
                        [HORAINICO],
                        [HORATERMINO]
                    FROM
                        TBCOMPROMISSO
                    WHERE
                        ID=@ID";

            comandoSelecao.CommandText = sqlSelecao;
            comandoSelecao.Parameters.AddWithValue("ID", IdPesquisado);


            SqlDataReader leitorcompromisso = comandoSelecao.ExecuteReader();

            if (leitorcompromisso.Read() == false)
                return null;

            int id = Convert.ToInt32(leitorcompromisso["ID"]);

            string assunto = Convert.ToString(leitorcompromisso["ASSUNTO"]);

            string local = Convert.ToString(leitorcompromisso["LOCAL"]);

            DateTime dataCompromisso = Convert.ToDateTime(leitorcompromisso["DATACOMPROMISSO"]);

            DateTime horaInicio = Convert.ToDateTime(leitorcompromisso["TELEFONE"]);

            DateTime horaTermino = Convert.ToDateTime(leitorcompromisso["HORAINICO"]);

            Compromissos compromisso = new Compromissos(assunto, local, dataCompromisso, horaInicio, horaTermino);
            compromisso.Id = id;

            con.Close();

            return compromisso;
        }

        public List<Compromissos> SelecionarTodosOsCompromissos()
        {
            SqlConnection con = AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ASSUNTO],
                        [LOCAL],
                        [DATACOMPROMISSO],
                        [HORAINICO],
                        [HORATERMINO]
                      
                    FROM 
                        TBCOMPROMISSO
                    ORDER BY 
                        [PRIORIDADE] ASC";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorCompromissos = comandoSelecao.ExecuteReader();

            List<Compromissos> compromissos = new List<Compromissos>();

            while (leitorCompromissos.Read())
            {
                int id = Convert.ToInt32(leitorCompromissos["ID"]);

                string assunto = Convert.ToString(leitorCompromissos["ASSUNTO"]);

                string local = Convert.ToString(leitorCompromissos["LOCAL"]);

                DateTime dataCompromisso = Convert.ToDateTime(leitorCompromissos["DATACOMPROMISSO"]);

                DateTime horaInicio = Convert.ToDateTime(leitorCompromissos["TELEFONE"]);

                DateTime horaTermino = Convert.ToDateTime(leitorCompromissos["HORAINICO"]);

                Compromissos compromisso = new Compromissos(assunto, local, dataCompromisso, horaInicio, horaTermino);
                compromisso.Id = id;

                compromissos.Add(compromisso);
            }

            con.Close();

            return compromissos;
        }
        public static SqlConnection AbrirConexao()
        {
            string enderecoDBeAgenda =
                  @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBeAgenda;Integrated Security=True;Pooling=False";
            SqlConnection conexaoComBanco = new SqlConnection();
            conexaoComBanco.ConnectionString = enderecoDBeAgenda;
            conexaoComBanco.Open();
            return conexaoComBanco;
        }
    }
}
