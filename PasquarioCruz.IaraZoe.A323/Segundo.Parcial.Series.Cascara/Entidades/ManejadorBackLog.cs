using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoBackLogManejadorBackLog(Serie serie);
    public class ManejadorBackLog
    {
        public event DelegadoBackLogManejadorBackLog NuevaSerieParaVer;

        public void IniciarManejador(List<Serie> series)
        {
            Task.Run(() => MoverSeries(series));
        }

        private void MoverSeries(List<Serie> series)
        {
            
            List<Serie> seriesCopia = new List<Serie>(series);

            foreach (var serie in seriesCopia)
            {
                
                int randomIndex = seriesCopia.GenerarRandom();

                
                AccesoDatos.ActualizarSerie(seriesCopia[randomIndex]);

               
                Task.Delay(1500).Wait();

                NuevaSerieParaVer?.Invoke(seriesCopia[randomIndex]);
            }
        }

    }
}
