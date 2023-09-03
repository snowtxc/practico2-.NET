namespace Shared
{
    public class Persona
    {
        public string Nombre { get; set; } = "-- Sin Nombre --";

        private string documento = "";
        public string Documento
        {
            get
            {
                return documento;
            }
            set
            {
                documento = value;
            }
        }

        public void Print()
        {
            Console.WriteLine("-- Persona --");
            Console.WriteLine("Nombre: " + Nombre);

            Console.WriteLine("Documento: " + Documento);
        }

        public void PrintTable()
        {
            Console.WriteLine("| " + Documento + " | " + Nombre + " |");
        }
    }
}