using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace Persistencia
{
    public class EscuelaConfig
    {
        public enum DestinoTipo { SQLServerEscuela, PostgresEscuela, MemoryEscuela };
        const string KeyPersistenciaDestino = "PersistenciaDestino";
        static DestinoTipo PersistenciaDestino;
        static string StringConnection;

        static EscuelaConfig()
        {
            if (String.IsNullOrEmpty(StringConnection))
            {
                // Lectura de los parámetros del sistema
                PersistenciaDestino = (DestinoTipo)Enum.Parse(typeof(DestinoTipo), ConfigurationManager.AppSettings[KeyPersistenciaDestino].ToString());
                StringConnection = ConfigurationManager.ConnectionStrings[PersistenciaDestino.ToString()].ToString();
                // Debug
                Console.WriteLine(PersistenciaDestino + " --> " + StringConnection);
            }            
        }

        static public void ContextOptions(DbContextOptionsBuilder optionsBuilder)
        {
            switch (PersistenciaDestino)
            {
                case DestinoTipo.SQLServerEscuela:
                    optionsBuilder.UseSqlServer(StringConnection);
                    break;
                case DestinoTipo.PostgresEscuela:
                    optionsBuilder.UseNpgsql(StringConnection);
                    break;
                case DestinoTipo.MemoryEscuela:
                    optionsBuilder.UseInMemoryDatabase(StringConnection);
                    break;
                default:
                    break;
            }
        }
                
    }
}
