using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace RoboEsaj.Database.Models
{
    public class SqliteDataAccess
    {
        public static List<DecisaoModel> LoadDecisao()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = conn.Query<DecisaoModel>("SELECT * FROM Decisao", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveDecisao(DecisaoModel decisao)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("INSERT INTO Decisao (Processo, Classe, Assunto, Magistrado, Comarca, Foro, Vara, Data, Resultado) " +
                            "VALUES (@Processo, @Classe, @Assunto, @Magistrado, @Comarca, @Foro, @Vara, @Data, @Resultado)", decisao);
            }
        }

        public static void SaveDecisaoWithoutOpeningDb(DecisaoModel decisao, IDbConnection conn)
        {
           
             conn.Execute("INSERT INTO Decisao (Processo, Classe, Assunto, Magistrado, Comarca, Foro, Vara, Data, Resultado) " +
                        "VALUES (@Processo, @Classe, @Assunto, @Magistrado, @Comarca, @Foro, @Vara, @Data, @Resultado)", decisao);
           
        }

        public static List<DecisaoModel> SearchDecisao(string searchText)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = "SELECT Processo, Classe, Assunto," +
                               "Magistrado, Comarca, Foro, Vara, Data, Resultado " +
                               "FROM Decisao " +
                              $"WHERE Processo LIKE '%{searchText}%' OR " +
                              $"Classe LIKE '%{searchText}%' OR " +
                              $"Assunto LIKE '%{searchText}%' OR " +
                              $"Magistrado LIKE '%{searchText}%' OR " +
                              $"Comarca LIKE '%{searchText}%' OR " +
                              $"Foro LIKE '%{searchText}%' OR " +
                              $"Vara LIKE '%{searchText}%' OR " +
                              $"Data LIKE '%{searchText}%' OR " +
                              $"Resultado LIKE '%{searchText}%'";

                return conn.Query<DecisaoModel>(query, new DynamicParameters()).ToList();
            }
        }

        public static void ClearDatabase()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("DELETE FROM Decisao");
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
