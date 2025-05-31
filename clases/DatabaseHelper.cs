using System;
using System.Data.SqlClient;

namespace IA_AlertaDesaparecidos_MaterialSkin
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void GuardarAnalisis(string prompt, string respuesta)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Alerta (Prompt, Respuesta) VALUES (@prompt, @respuesta)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@prompt", prompt);
                    cmd.Parameters.AddWithValue("@respuesta", respuesta);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
