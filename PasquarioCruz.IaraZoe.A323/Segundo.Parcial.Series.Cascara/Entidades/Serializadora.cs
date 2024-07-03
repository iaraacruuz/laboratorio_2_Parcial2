using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Serialization;

namespace Entidades
{
    public class Serializadora : IGuardar<List<Serie>>
    {
      
        void IGuardar<List<Serie>>.Guardar(List<Serie> lista, string ruta)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Serie>));
                string filePath = Path.Combine(ruta, "BacklogSeries.xml");
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, lista);
                }
            }
            catch (IOException ioEx)
            {
                Logger.Log($"Error de E/S al guardar el backlog de series en formato XML: {ioEx.Message}");
                throw new BackLogException("Error de E/S al guardar el backlog de series en formato XML.", ioEx);
            }
            catch (UnauthorizedAccessException authEx)
            {
                Logger.Log($"No se tiene acceso para guardar el backlog de series en formato XML: {authEx.Message}");
                throw new BackLogException("No se tiene acceso para guardar el backlog de series en formato XML.", authEx);
            }
            catch (Exception ex)
            {
                Logger.Log($"Error general al guardar el backlog de series en formato XML: {ex.Message}");
                throw new BackLogException("Error al guardar el backlog de series en formato XML.", ex);
            }
        }

        public void Guardar(List<Serie> lista, string ruta)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string jsonString = JsonSerializer.Serialize(lista, options);
                string filePath = Path.Combine(ruta, "SeriesParaVer.json");

                
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                File.WriteAllText(filePath, jsonString);
            }
            catch (IOException ioEx)
            {
                Logger.Log($"Error de E/S al guardar las series para ver en formato JSON: {ioEx.Message}");
                throw new BackLogException("Error de E/S al guardar las series para ver en formato JSON", ioEx);
            }
            catch (UnauthorizedAccessException authEx)
            {
                Logger.Log($"No se tiene acceso para guardar las series para ver en formato JSON: {authEx.Message}");
                throw new BackLogException("No se tiene acceso para guardar las series para ver en formato JSON", authEx);
            }
            catch (Exception ex)
            {
                Logger.Log($"Error general al guardar las series para ver en formato JSON: {ex.Message}");
                throw new BackLogException("Error al guardar las series para ver en formato JSON", ex);
            }
        }

    }
}
