namespace BibliotecaApp
{
    
    public class Libro
    {
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int Anio { get; set; }
        public bool Disponible { get; set; }

        public Libro() { }

        public Libro(string titulo, string autor, int anio, bool disponible)
        {
            Titulo = titulo;
            Autor = autor;
            Anio = anio;
            Disponible = disponible;
        }

        
        public string ToTextLine()
        {
            string disponibleTexto = Disponible ? "Si" : "No";
            return $"{Titulo}|{Autor}|{Anio}|{disponibleTexto}";
        }

        public static Libro FromTextLine(string linea)
        {
            string[] partes = linea.Split('|');

            if (partes.Length != 4)
            {
                throw new FormatException(
                    $"La línea no tiene el formato esperado (4 campos separados por '|'): \"{linea}\"");
            }

            string titulo = partes[0];
            string autor = partes[1];

            if (!int.TryParse(partes[2], out int anio))
            {
                throw new FormatException(
                    $"El año \"{partes[2]}\" no es un número válido en la línea: \"{linea}\"");
            }

            bool disponible = partes[3].Trim().Equals("Si", StringComparison.OrdinalIgnoreCase);

            return new Libro(titulo, autor, anio, disponible);
        }

       
        public void EscribirBinario(BinaryWriter writer)
        {
            writer.Write(Titulo);
            writer.Write(Autor);
            writer.Write(Anio);
            writer.Write(Disponible);
        }

        public static Libro LeerBinario(BinaryReader reader)
        {
            string titulo = reader.ReadString();
            string autor = reader.ReadString();
            int anio = reader.ReadInt32();
            bool disponible = reader.ReadBoolean();

            return new Libro(titulo, autor, anio, disponible);
        }

        public override string ToString()
        {
            string disponibleTexto = Disponible ? "Disponible" : "Prestado";
            return $"{Titulo} - {Autor} ({Anio}) [{disponibleTexto}]";
        }
    }
}