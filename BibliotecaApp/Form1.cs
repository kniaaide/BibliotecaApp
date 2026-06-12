using System.Text;

namespace BibliotecaApp
{
    public partial class Form1 : Form
    {
        // Lista en memoria con los libros que se van agregando desde la interfaz.
        private readonly List<Libro> libros = new();

        // Rutas de los archivos de texto y binario.
        // Se guardan en la carpeta de ejecución del programa.
        private readonly string rutaArchivoTexto =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libros.txt");

        private readonly string rutaArchivoBinario =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libros.dat");

        public Form1()
        {
            InitializeComponent();
        }

        // =====================================================================
        // Utilidades de interfaz
        // =====================================================================

        /// <summary>
        /// Agrega un mensaje con marca de tiempo al cuadro de registro (log).
        /// </summary>
        private void Log(string mensaje)
        {
            string hora = DateTime.Now.ToString("HH:mm:ss");
            txtLog.AppendText($"[{hora}] {mensaje}{Environment.NewLine}");
        }

        /// <summary>
        /// Refresca el contenido del ListBox con los libros que hay en memoria.
        /// </summary>
        private void ActualizarLista()
        {
            lstLibros.Items.Clear();
            foreach (Libro libro in libros)
            {
                lstLibros.Items.Add(libro.ToString());
            }
        }

        /// <summary>
        /// Limpia los campos de entrada de datos.
        /// </summary>
        private void LimpiarCampos()
        {
            txtTitulo.Clear();
            txtAutor.Clear();
            numAnio.Value = 2024;
            chkDisponible.Checked = true;
            txtTitulo.Focus();
        }

        // =====================================================================
        // Botones para administrar la lista en memoria
        // =====================================================================

        /// <summary>
        /// Valida los datos del formulario y agrega un nuevo libro a la lista
        /// en memoria. Aquí se manejan excepciones de validación de datos
        /// (no de archivos), pero siguiendo el mismo patrón try/catch.
        /// </summary>
        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            try
            {
                string titulo = txtTitulo.Text.Trim();
                string autor = txtAutor.Text.Trim();

                if (string.IsNullOrWhiteSpace(titulo))
                {
                    throw new ArgumentException("El título no puede estar vacío.");
                }

                if (string.IsNullOrWhiteSpace(autor))
                {
                    throw new ArgumentException("El autor no puede estar vacío.");
                }

                // El '|' se usa como separador en el archivo de texto,
                // por lo que no se permite dentro de los campos.
                if (titulo.Contains('|') || autor.Contains('|'))
                {
                    throw new ArgumentException(
                        "El título y el autor no pueden contener el carácter '|'.");
                }

                int anio = (int)numAnio.Value;
                bool disponible = chkDisponible.Checked;

                Libro nuevoLibro = new(titulo, autor, anio, disponible);
                libros.Add(nuevoLibro);
                ActualizarLista();

                Log($"Libro agregado a la lista en memoria: {nuevoLibro}");
                LimpiarCampos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Datos inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Elimina de la lista en memoria el libro seleccionado en el ListBox.
        /// </summary>
        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                int indice = lstLibros.SelectedIndex;

                if (indice < 0)
                {
                    throw new InvalidOperationException(
                        "Selecciona un libro de la lista para eliminarlo.");
                }

                Libro libroEliminado = libros[indice];
                libros.RemoveAt(indice);
                ActualizarLista();

                Log($"Libro eliminado de la lista en memoria: {libroEliminado}");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Limpia toda la lista de libros en memoria (no afecta archivos
        /// hasta que se guarde de nuevo).
        /// </summary>
        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            if (libros.Count == 0)
            {
                Log("La lista ya está vacía, no hay nada que limpiar.");
                return;
            }

            DialogResult resultado = MessageBox.Show(
                "¿Seguro que deseas limpiar toda la lista en memoria?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                libros.Clear();
                ActualizarLista();
                Log("Se limpió la lista de libros en memoria.");
            }
        }

        // =====================================================================
        // 6.2 Operaciones básicas en ARCHIVO DE TEXTO
        // 6.3 Manejo de excepciones en archivos
        // =====================================================================

        /// <summary>
        /// Guarda la lista de libros en un archivo de TEXTO plano (libros.txt).
        /// Cada libro se escribe en una línea, con sus campos separados por '|'.
        /// Usa StreamWriter dentro de un bloque try/catch/finally para
        /// garantizar el cierre del archivo incluso si ocurre un error.
        /// </summary>
        private void btnGuardarTexto_Click(object? sender, EventArgs e)
        {
            if (libros.Count == 0)
            {
                MessageBox.Show("No hay libros en la lista para guardar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StreamWriter? escritor = null;

            try
            {
                // 'false' indica que se sobrescribe el archivo si ya existe.
                escritor = new StreamWriter(rutaArchivoTexto, false, Encoding.UTF8);

                foreach (Libro libro in libros)
                {
                    escritor.WriteLine(libro.ToTextLine());
                }

                Log($"Se guardaron {libros.Count} libro(s) en el archivo de texto: {rutaArchivoTexto}");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(
                    $"No se tienen permisos para escribir el archivo de texto.\n\nDetalle: {ex.Message}",
                    "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(
                    $"La carpeta destino no existe.\n\nDetalle: {ex.Message}",
                    "Error de ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error de entrada/salida al guardar el archivo de texto.\n\nDetalle: {ex.Message}",
                    "Error de E/S", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error inesperado al guardar el archivo de texto.\n\nDetalle: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Se cierra el archivo sin importar si hubo error o no.
                escritor?.Close();
            }
        }

        /// <summary>
        /// Carga libros desde el archivo de TEXTO (libros.txt) y los agrega
        /// a la lista en memoria. Usa StreamReader y maneja:
        ///  - FileNotFoundException: si el archivo no existe.
        ///  - FormatException: si alguna línea no tiene el formato esperado
        ///    (se reporta pero no detiene la carga de las demás líneas).
        /// </summary>
        private void btnCargarTexto_Click(object? sender, EventArgs e)
        {
            StreamReader? lector = null;

            try
            {
                if (!File.Exists(rutaArchivoTexto))
                {
                    throw new FileNotFoundException(
                        "El archivo de texto no existe todavía. Primero guarda libros en texto.",
                        rutaArchivoTexto);
                }

                lector = new StreamReader(rutaArchivoTexto, Encoding.UTF8);

                int lineasLeidas = 0;
                int lineasConError = 0;
                string? linea;

                while ((linea = lector.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(linea))
                    {
                        continue; // Se ignoran líneas vacías.
                    }

                    try
                    {
                        Libro libro = Libro.FromTextLine(linea);
                        libros.Add(libro);
                        lineasLeidas++;
                    }
                    catch (FormatException ex)
                    {
                        // Se registra el error de formato de la línea, pero se
                        // continúa con la lectura del resto del archivo.
                        lineasConError++;
                        Log($"Línea con formato inválido y fue ignorada: {ex.Message}");
                    }
                }

                ActualizarLista();
                Log($"Carga desde texto finalizada: {lineasLeidas} libro(s) cargados, " +
                    $"{lineasConError} línea(s) con error.");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Archivo no encontrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(
                    $"No se tienen permisos para leer el archivo de texto.\n\nDetalle: {ex.Message}",
                    "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error de entrada/salida al leer el archivo de texto.\n\nDetalle: {ex.Message}",
                    "Error de E/S", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error inesperado al leer el archivo de texto.\n\nDetalle: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lector?.Close();
            }
        }

        // =====================================================================
        // 6.2 Operaciones básicas en ARCHIVO BINARIO
        // 6.3 Manejo de excepciones en archivos
        // =====================================================================

        /// <summary>
        /// Guarda la lista de libros en un archivo BINARIO (libros.dat).
        ///
        /// Formato del archivo:
        ///   - Un entero (Int32) al inicio que indica cuántos libros hay.
        ///   - Por cada libro: Titulo (string), Autor (string),
        ///     Anio (Int32), Disponible (bool).
        ///
        /// Usa FileStream + BinaryWriter, ambos dentro de bloques 'using'
        /// para garantizar su cierre automático, además de try/catch para
        /// manejar errores de E/S.
        /// </summary>
        private void btnGuardarBinario_Click(object? sender, EventArgs e)
        {
            if (libros.Count == 0)
            {
                MessageBox.Show("No hay libros en la lista para guardar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using FileStream flujoArchivo = new(rutaArchivoBinario, FileMode.Create, FileAccess.Write);
                using BinaryWriter escritor = new(flujoArchivo);

                // Primero se escribe la cantidad de libros, para poder
                // saber cuántos registros leer después.
                escritor.Write(libros.Count);

                foreach (Libro libro in libros)
                {
                    libro.EscribirBinario(escritor);
                }

                Log($"Se guardaron {libros.Count} libro(s) en el archivo binario: {rutaArchivoBinario}");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(
                    $"No se tienen permisos para escribir el archivo binario.\n\nDetalle: {ex.Message}",
                    "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(
                    $"La carpeta destino no existe.\n\nDetalle: {ex.Message}",
                    "Error de ruta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error de entrada/salida al guardar el archivo binario.\n\nDetalle: {ex.Message}",
                    "Error de E/S", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error inesperado al guardar el archivo binario.\n\nDetalle: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga libros desde el archivo BINARIO (libros.dat) y los agrega
        /// a la lista en memoria.
        ///
        /// Maneja específicamente:
        ///  - FileNotFoundException: si el archivo no existe.
        ///  - EndOfStreamException: si el archivo está incompleto o dañado
        ///    (por ejemplo, el contador de libros no coincide con los datos
        ///    realmente almacenados).
        /// </summary>
        private void btnCargarBinario_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(rutaArchivoBinario))
                {
                    throw new FileNotFoundException(
                        "El archivo binario no existe todavía. Primero guarda libros en binario.",
                        rutaArchivoBinario);
                }

                using FileStream flujoArchivo = new(rutaArchivoBinario, FileMode.Open, FileAccess.Read);
                using BinaryReader lector = new(flujoArchivo);

                int cantidadLibros = lector.ReadInt32();
                int leidosCorrectamente = 0;

                for (int i = 0; i < cantidadLibros; i++)
                {
                    Libro libro = Libro.LeerBinario(lector);
                    libros.Add(libro);
                    leidosCorrectamente++;
                }

                ActualizarLista();
                Log($"Carga desde binario finalizada: {leidosCorrectamente} de {cantidadLibros} libro(s) cargados.");
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Archivo no encontrado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (EndOfStreamException ex)
            {
                // Esto ocurre si el archivo está corrupto o incompleto:
                // se intentó leer más datos de los que realmente existen.
                MessageBox.Show(
                    "El archivo binario parece estar incompleto o dañado " +
                    "(se intentó leer más datos de los disponibles).\n\n" +
                    $"Detalle técnico: {ex.Message}",
                    "Archivo binario dañado", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ActualizarLista();
                Log("Error: el archivo binario está incompleto o dañado.");
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(
                    $"No se tienen permisos para leer el archivo binario.\n\nDetalle: {ex.Message}",
                    "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error de entrada/salida al leer el archivo binario.\n\nDetalle: {ex.Message}",
                    "Error de E/S", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrió un error inesperado al leer el archivo binario.\n\nDetalle: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}