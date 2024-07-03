namespace Entidades
{
    public class Serie
    {
        private string nombre;
        private string genero;
       

        public string Nombre { get => nombre; set => nombre = value; }
        public string Genero { get => genero; set => genero = value; }
        

        public Serie(string nombre, string genero)
        {
            this.nombre = nombre;
            this.genero = genero;
            
        }

        public Serie() { }

        public override string ToString()
        {
            return $"{Nombre} - {Genero}";
        }
    }
}
