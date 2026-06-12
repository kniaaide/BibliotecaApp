namespace BibliotecaApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Para soportar acentos y caracteres especiales en español
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}