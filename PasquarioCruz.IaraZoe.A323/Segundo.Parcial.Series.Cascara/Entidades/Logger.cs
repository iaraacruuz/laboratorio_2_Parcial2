using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Logger
    {
        private static string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string logFilePath = Path.Combine(desktopPath, "log.txt");

        public static void Log(string mensaje)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    string logMessage = $"{DateTime.Now} - {mensaje}";
                    sw.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el log: {ex.Message}");
            }
        }

        public static void Log(Exception ex)
        {
            string mensaje = $"Excepcionn: {ex.Message}\nStack Trace: {ex.StackTrace}";
            Log(mensaje);
        }
    }
}
