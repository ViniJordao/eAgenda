using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using eAgenda.Dominio;


namespace eAgenda.Controladores
{
    public class ControladorTarefas
    {
        public void InserirNovaLista(Tarefas tarefa)
        {
            SqlConnection con = AbrirConexao();

            SqlCommand comandoInsercao = new SqlCommand();
            comandoInsercao.Connection = con;

            string sqlInsercao =
                @"INSERT INTO TBLISTA
                    (
                        [TITULO],
                        [DATACRIACAO],
                        [PRIORIDADE]
                    )
                    VALUES
                    (
                        @TITULO,
                        @DATACRIACAO,
                        @PRIORIDADE
                    );";

            sqlInsercao += @"SELECT SCOPE_IDENTITY();";

            comandoInsercao.CommandText = sqlInsercao;

            comandoInsercao.Parameters.AddWithValue("TITULO", tarefa.Titulo);
            comandoInsercao.Parameters.AddWithValue("DATACRIACAO", tarefa.DataCriacao);
            comandoInsercao.Parameters.AddWithValue("PRIORIDADE", tarefa.Prioridade);

            object id = comandoInsercao.ExecuteScalar();

            tarefa.Id = Convert.ToInt32(id);

            con.Close();
        }

        public void AtualizarTarefa(Tarefas tarefa)
        {

            SqlConnection con = AbrirConexao();

            SqlCommand comandoAtualizacao = new SqlCommand();
            comandoAtualizacao.Connection = con;

            string sqlAtualizacao =
                @"UPDATE TBLISTA
                    SET
                        [TITULO] = @TITULO,
                        [DATACONCLUSAO] = @DATACONCLUSAO,
                        [PRIORIDADE] = @PRIORIDADE
                    WHERE
                        [ID] = @ID";

            comandoAtualizacao.CommandText = sqlAtualizacao;

            comandoAtualizacao.Parameters.AddWithValue("ID", tarefa.Id);
            comandoAtualizacao.Parameters.AddWithValue("TITULO", tarefa.Titulo);
            comandoAtualizacao.Parameters.AddWithValue("DATACONCLUSAO", tarefa.DataConclusao);
            comandoAtualizacao.Parameters.AddWithValue("PRIORIDADE", tarefa.Prioridade);

            comandoAtualizacao.ExecuteNonQuery();

            con.Close();
        }

        public void ExcluirTarefa(Tarefas tarefas)
        {
            SqlConnection con = AbrirConexao();

            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = con;

            string sqlExclusao =
                @"DELETE FROM TBLISTA	                
	                WHERE 
		                [ID] = @ID";

            comandoExclusao.CommandText = sqlExclusao;

            comandoExclusao.Parameters.AddWithValue("ID", tarefas.Id);

            comandoExclusao.ExecuteNonQuery();

            con.Close();
        }

        public Tarefas SelecionarTarefaPorId(int idPesquisado)
        {
            SqlConnection con = AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO],
                        [DATACONCLUSAO],
                        [PRIORIDADE]
                    FROM 
                        TBTAREFA
                    WHERE 
                        ID = @ID";

            comandoSelecao.CommandText = sqlSelecao;
            comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            if (leitorTarefas.Read() == false)
                return null;

            int id = Convert.ToInt32(leitorTarefas["ID"]);

            string titulo = Convert.ToString(leitorTarefas["TITULO"]);

            DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);

            DateTime dataConclusao = DateTime.MinValue;

            if (leitorTarefas["DATACONCLUSAO"] != DBNull.Value)
                dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);

            int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

            Tarefas tarefas = new Tarefas(titulo, dataCriacao, dataConclusao, prioridade);
            tarefas.Id = id;

            con.Close();

            return tarefas;
        }

        public List<Tarefas> SelecionarTodasAsTarefas()
        {
            SqlConnection con = AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO], 
                        [PRIORIDADE] 
                    FROM 
                        TBTAREFA
                    ORDER BY 
                        [PRIORIDADE] ASC";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<Tarefas> tarefas = new List<Tarefas>();

            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);

                string titulo = Convert.ToString(leitorTarefas["TITULO"]);

                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);

                int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                Tarefas tarefa = new Tarefas(titulo, dataCriacao, prioridade);

                tarefa.Id = id;

                tarefas.Add(tarefa);
            }

            con.Close();

            return tarefas;
        }

        public List<Tarefas> SelecionarTodasAsTarefasEmAberto()
        {
            SqlConnection con = AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO], 
                        [PRIORIDADE] 
                    FROM 
                        TBTAREFA
                    WHERE
                        [PERCENTUAL] != '100%'
                    ORDER BY
                        [PRIORIDADE] ASC, [DATACRIACAO]";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<Tarefas> tarefas = new List<Tarefas>();

            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);

                string titulo = Convert.ToString(leitorTarefas["TITULO"]);

                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);

                int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                Tarefas tarefa = new Tarefas(titulo, dataCriacao, prioridade);

                tarefa.Id = id;

                tarefas.Add(tarefa);
            }

            con.Close();

            return tarefas;
        }

        public List<Tarefas> SelecionarTodasAsTarefasConcluidas()
        {
            SqlConnection con = AbrirConexao();

            SqlCommand comandoSelecao = new SqlCommand();
            comandoSelecao.Connection = con;

            string sqlSelecao =
                @"SELECT 
                        [ID], 
                        [TITULO], 
                        [DATACRIACAO],
                        [DATACONCLUSAO],
                        [PRIORIDADE] 
                    FROM 
                        TBTAREFA
                    WHERE
                        PERCENTUAL = '100%'
                    ORDER BY
                        [PRIORIDADE] ASC, [DATACRIACAO]";

            comandoSelecao.CommandText = sqlSelecao;

            SqlDataReader leitorTarefas = comandoSelecao.ExecuteReader();

            List<Tarefas> tarefasConcluidas = new List<Tarefas>();

            while (leitorTarefas.Read())
            {
                int id = Convert.ToInt32(leitorTarefas["ID"]);

                string titulo = Convert.ToString(leitorTarefas["TITULO"]);

                DateTime dataCriacao = Convert.ToDateTime(leitorTarefas["DATACRIACAO"]);

                DateTime dataConclusao = Convert.ToDateTime(leitorTarefas["DATACONCLUSAO"]);

                int prioridade = Convert.ToInt32(leitorTarefas["PRIORIDADE"]);

                Tarefas lista = new Tarefas(titulo, dataCriacao, dataConclusao, prioridade);
                lista.Id = id;

                tarefasConcluidas.Add(lista);
            }

            con.Close();

            return tarefasConcluidas;
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

