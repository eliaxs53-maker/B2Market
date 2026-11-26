using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace B2Market
{
    public partial class Form1 : Form
    {
        // COLORES
        private readonly Color morado = Color.FromArgb(105, 75, 210);
        private readonly Color fondo = Color.FromArgb(247, 245, 255);
        private readonly Color texto = Color.FromArgb(55, 45, 85);

        // LISTA DE LIBROS
        private readonly List<Libro> libros = new List<Libro>();

        private FlowLayoutPanel panelLibros;
        private Panel contenido;
        private string rutaImagen = "";

        // CLASE LIBRO
        public class Libro
        {
            public string Nombre { get; set; }
            public string Nivel { get; set; }
            public string Descripcion { get; set; }
            public decimal Precio { get; set; }
            public string Propietario { get; set; }
            public string Estado { get; set; }
            public string Imagen { get; set; }
            public string CodigoPago { get; set; }
            public string MetodoPago { get; set; }
            public DateTime? FechaReserva { get; set; }
        }

        // CONSTRUCTOR
        public Form1()
        {
            InitializeComponent();

            CargarLibrosIniciales();
            CrearInterfaz();
            MostrarInicio();
        }

        private void CargarLibrosIniciales()
        {
            libros.Add(new Libro
            {
                Nombre = "English for Beginners",
                Nivel = "Beginner",
                Descripcion = "Libro para aprender inglés desde cero.",
                Precio = 8.00m,
                Propietario = "Estudiante CEC",
                Estado = "Disponible",
                Imagen = ""
            });

            libros.Add(new Libro
            {
                Nombre = "Basic English 1",
                Nivel = "Basic 1",
                Descripcion = "Material de apoyo para el nivel Basic 1.",
                Precio = 12.00m,
                Propietario = "Estudiante CEC",
                Estado = "Disponible",
                Imagen = ""
            });

            libros.Add(new Libro
            {
                Nombre = "Basic English 2",
                Nivel = "Basic 2",
                Descripcion = "Libro de estudio para el nivel Basic 2.",
                Precio = 15.00m,
                Propietario = "Estudiante CEC",
                Estado = "Disponible",
                Imagen = ""
            });
        }


        private void CrearInterfaz()
        {
            this.Text = "B2Market";
            this.Size = new Size(1080, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = fondo;
            this.MinimumSize = new Size(920, 620);


            contenido = new Panel();
            contenido.Dock = DockStyle.Fill;
            contenido.BackColor = fondo;
            contenido.AutoScroll = true;
            this.Controls.Add(contenido);


            Panel menu = new Panel();
            menu.Dock = DockStyle.Left;
            menu.Width = 190;
            menu.BackColor = Color.White;
            menu.Padding = new Padding(15, 25, 15, 15);
            this.Controls.Add(menu);

            Button btnInicio = CrearBotonMenu("Inicio");
            btnInicio.Location = new Point(20, 25);
            btnInicio.Click += (s, e) => MostrarInicio();
            menu.Controls.Add(btnInicio);

            Button btnVender = CrearBotonMenu("Vender");
            btnVender.Location = new Point(20, 85);
            btnVender.Click += (s, e) => MostrarVender();
            menu.Controls.Add(btnVender);


            Panel encabezado = new Panel();
            encabezado.Dock = DockStyle.Top;
            encabezado.Height = 75;
            encabezado.BackColor = morado;
            this.Controls.Add(encabezado);

            Label logo = new Label();
            logo.Text = "B2Market";
            logo.Font = new Font("Arial", 22, FontStyle.Bold);
            logo.ForeColor = Color.White;
            logo.AutoSize = true;
            logo.Location = new Point(25, 18);
            encabezado.Controls.Add(logo);

            Label subtitulo = new Label();
            subtitulo.Text = "Compra y vende tus libros en el CEC";
            subtitulo.Font = new Font("Arial", 10);
            subtitulo.ForeColor = Color.FromArgb(235, 230, 255);
            subtitulo.AutoSize = true;
            subtitulo.Location = new Point(215, 31);
            encabezado.Controls.Add(subtitulo);
        }


        private Button CrearBotonMenu(string nombre)
        {
            Button boton = new Button();
            boton.Text = nombre;
            boton.Size = new Size(150, 45);
            boton.BackColor = morado;
            boton.ForeColor = Color.White;
            boton.Font = new Font("Arial", 11, FontStyle.Bold);
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Cursor = Cursors.Hand;
            return boton;
        }


        private void MostrarInicio()
        {
            contenido.Controls.Clear();

            Label titulo = new Label();
            titulo.Text = "¡Encuentra tu próximo libro!";
            titulo.Font = new Font("Arial", 22, FontStyle.Bold);
            titulo.ForeColor = texto;
            titulo.AutoSize = true;
            titulo.Location = new Point(25, 20);
            contenido.Controls.Add(titulo);

            Label descripcion = new Label();
            descripcion.Text = "Explora los libros disponibles para tus cursos en la biblioteca del CEC.";
            descripcion.Font = new Font("Arial", 10);
            descripcion.ForeColor = Color.Gray;
            descripcion.AutoSize = true;
            descripcion.Location = new Point(27, 62);
            contenido.Controls.Add(descripcion);

            panelLibros = new FlowLayoutPanel();
            panelLibros.Location = new Point(25, 95);
            panelLibros.Size = new Size(820, 470);
            panelLibros.AutoScroll = true;
            panelLibros.BackColor = fondo;
            panelLibros.WrapContents = true;
            panelLibros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            contenido.Controls.Add(panelLibros);

            ActualizarTarjetas();
        }


        private void ActualizarTarjetas()
        {
            if (panelLibros == null)
                return;

            panelLibros.Controls.Clear();

            foreach (Libro libro in libros)
            {
                Panel tarjeta = new Panel();
                tarjeta.Size = new Size(235, 330);
                tarjeta.BackColor = Color.White;
                tarjeta.Margin = new Padding(10);
                tarjeta.BorderStyle = BorderStyle.FixedSingle;

                // CONTENEDOR DE IMAGEN / PORTADA SIN SUPERPOSICIÓN
                Panel cajaImagen = new Panel();
                cajaImagen.Location = new Point(12, 12);
                cajaImagen.Size = new Size(209, 105);
                cajaImagen.BackColor = Color.FromArgb(240, 235, 255);
                tarjeta.Controls.Add(cajaImagen);

                if (!string.IsNullOrEmpty(libro.Imagen) && File.Exists(libro.Imagen))
                {
                    PictureBox imagen = new PictureBox();
                    imagen.Dock = DockStyle.Fill;
                    imagen.SizeMode = PictureBoxSizeMode.Zoom;
                    byte[] bytes = File.ReadAllBytes(libro.Imagen);
                    using (var ms = new MemoryStream(bytes))
                    {
                        imagen.Image = Image.FromStream(ms);
                    }
                    cajaImagen.Controls.Add(imagen);
                }
                else
                {
                    Label icono = new Label();
                    icono.Text = "📚";
                    icono.Font = new Font("Arial", 32);
                    icono.ForeColor = morado;
                    icono.Dock = DockStyle.Fill;
                    icono.TextAlign = ContentAlignment.MiddleCenter;
                    cajaImagen.Controls.Add(icono);
                }

                // NOMBRE
                Label nombre = new Label();
                nombre.Text = libro.Nombre;
                nombre.Font = new Font("Arial", 11, FontStyle.Bold);
                nombre.ForeColor = texto;
                nombre.Location = new Point(12, 125);
                nombre.Size = new Size(209, 24);
                nombre.AutoEllipsis = true;
                tarjeta.Controls.Add(nombre);

                // NIVEL
                Label nivel = new Label();
                nivel.Text = "Nivel: " + libro.Nivel;
                nivel.Font = new Font("Arial", 9);
                nivel.ForeColor = Color.Gray;
                nivel.Location = new Point(12, 152);
                nivel.Size = new Size(209, 20);
                nivel.AutoEllipsis = true;
                tarjeta.Controls.Add(nivel);

                // DESCRIPCIÓN
                Label detalle = new Label();
                detalle.Text = libro.Descripcion;
                detalle.Font = new Font("Arial", 8.5f);
                detalle.ForeColor = Color.Gray;
                detalle.Location = new Point(12, 175);
                detalle.Size = new Size(209, 36);
                detalle.AutoEllipsis = true;
                tarjeta.Controls.Add(detalle);

                // PRECIO
                Label precio = new Label();
                precio.Text = "$" + libro.Precio.ToString("0.00");
                precio.Font = new Font("Arial", 13, FontStyle.Bold);
                precio.ForeColor = morado;
                precio.Location = new Point(12, 222);
                precio.Size = new Size(105, 25);
                tarjeta.Controls.Add(precio);

                // ESTADO
                Label estado = new Label();
                estado.Text = libro.Estado;
                estado.Font = new Font("Arial", 9, FontStyle.Bold);
                estado.Location = new Point(120, 226);
                estado.Size = new Size(101, 20);
                estado.TextAlign = ContentAlignment.MiddleRight;
                ActualizarColorEstado(estado, libro.Estado);
                tarjeta.Controls.Add(estado);

                // BOTÓN COMPRAR
                Button comprar = new Button();
                comprar.Text = libro.Estado == "Disponible" ? "Comprar" : libro.Estado;
                comprar.Location = new Point(12, 268);
                comprar.Size = new Size(209, 40);
                comprar.BackColor = morado;
                comprar.ForeColor = Color.White;
                comprar.FlatStyle = FlatStyle.Flat;
                comprar.FlatAppearance.BorderSize = 0;
                comprar.Font = new Font("Arial", 10, FontStyle.Bold);
                comprar.Cursor = libro.Estado == "Disponible" ? Cursors.Hand : Cursors.Default;

                if (libro.Estado != "Disponible")
                {
                    comprar.Enabled = false;
                    comprar.BackColor = Color.LightGray;
                    comprar.ForeColor = Color.DarkGray;
                }

                comprar.Click += (s, e) =>
                {
                    if (libro.Estado != "Disponible")
                    {
                        MessageBox.Show("Este libro ya no está disponible.");
                        return;
                    }

                    MostrarOpcionesPago(
                        libro,
                        () =>
                        {
                            // PAGO FÍSICO: queda Pendiente por 24 horas
                            libro.Estado = "Pendiente";
                            libro.MetodoPago = "Pago físico";
                            libro.FechaReserva = DateTime.Now;
                            ActualizarTarjetas();
                        },
                        () =>
                        {
                            // PAGO DIGITAL: queda Vendido tras confirmación
                            libro.Estado = "Vendido";
                            libro.MetodoPago = "Pago digital";
                            libro.FechaReserva = DateTime.Now;
                            ActualizarTarjetas();
                        }
                    );
                };

                tarjeta.Controls.Add(comprar);
                panelLibros.Controls.Add(tarjeta);
            }
        }


        private void ActualizarColorEstado(Label etiqueta, string estado)
        {
            if (estado == "Disponible")
                etiqueta.ForeColor = Color.Green;
            else if (estado == "Pendiente")
                etiqueta.ForeColor = Color.DarkOrange;
            else if (estado == "Vendido")
                etiqueta.ForeColor = Color.Red;
        }


        private void MostrarOpcionesPago(
            Libro libro,
            Action confirmarFisico,
            Action confirmarDigital)
        {
            Form pago = new Form();
            pago.Text = "Método de pago — B2Market";
            pago.Size = new Size(430, 265);
            pago.StartPosition = FormStartPosition.CenterParent;
            pago.BackColor = Color.White;
            pago.FormBorderStyle = FormBorderStyle.FixedDialog;
            pago.MaximizeBox = false;
            pago.MinimizeBox = false;

            Label titulo = new Label();
            titulo.Text = "¿Cómo deseas pagar?";
            titulo.Font = new Font("Arial", 16, FontStyle.Bold);
            titulo.ForeColor = morado;
            titulo.AutoSize = true;
            titulo.Location = new Point(95, 22);
            pago.Controls.Add(titulo);

            Label nombreLibro = new Label();
            nombreLibro.Text = libro.Nombre + " (" + libro.Nivel + ")";
            nombreLibro.Font = new Font("Arial", 11, FontStyle.Bold);
            nombreLibro.ForeColor = texto;
            nombreLibro.AutoSize = true;
            nombreLibro.Location = new Point(30, 72);
            pago.Controls.Add(nombreLibro);

            Label precio = new Label();
            precio.Text = "Precio base: $" + libro.Precio.ToString("0.00");
            precio.Font = new Font("Arial", 10);
            precio.ForeColor = Color.Gray;
            precio.AutoSize = true;
            precio.Location = new Point(30, 102);
            pago.Controls.Add(precio);

            Button fisico = new Button();
            fisico.Text = "Pago físico (+10%)";
            fisico.Size = new Size(160, 45);
            fisico.Location = new Point(30, 155);
            fisico.BackColor = morado;
            fisico.ForeColor = Color.White;
            fisico.FlatStyle = FlatStyle.Flat;
            fisico.FlatAppearance.BorderSize = 0;

            Button digital = new Button();
            digital.Text = "Pago digital (0%)";
            digital.Size = new Size(160, 45);
            digital.Location = new Point(220, 155);
            digital.BackColor = Color.FromArgb(90, 165, 220);
            digital.ForeColor = Color.White;
            digital.FlatStyle = FlatStyle.Flat;
            digital.FlatAppearance.BorderSize = 0;

            // PAGO FÍSICO
            fisico.Click += (s, e) =>
            {
                decimal recargo = Math.Round(libro.Precio * 0.10m, 2);
                decimal total = libro.Precio + recargo;

                DialogResult respuesta = MessageBox.Show(
                    "El pago físico tiene un recargo del 10% para la bibliotecaria.\n\n" +
                    "Precio base: $" + libro.Precio.ToString("0.00") +
                    "\nRecargo (10%): $" + recargo.ToString("0.00") +
                    "\nTotal a pagar: $" + total.ToString("0.00") +
                    "\n\n¿Deseas continuar?",
                    "Confirmar pago físico",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (respuesta == DialogResult.Yes)
                {
                    string codigo = GenerarCodigo();
                    libro.CodigoPago = codigo;
                    confirmarFisico();

                    MessageBox.Show(
                        "¡Reserva registrada!\n\n" +
                        "Libro: " + libro.Nombre +
                        "\nCódigo de pago: " + codigo +
                        "\nTotal: $" + total.ToString("0.00") +
                        "\n\nTienes 24 horas para realizar el pago " +
                        "y presentar tu código a la bibliotecaria.\n" +
                        "El libro permanecerá en estado Pendiente.",
                        "Pago pendiente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    pago.Close();
                }
            };

            // PAGO DIGITAL
            digital.Click += (s, e) =>
            {
                Form qr = new Form();
                qr.Text = "Pago digital — B2Market";
                qr.Size = new Size(360, 350);
                qr.StartPosition = FormStartPosition.CenterParent;
                qr.BackColor = Color.White;
                qr.FormBorderStyle = FormBorderStyle.FixedDialog;
                qr.MaximizeBox = false;

                Label mensaje = new Label();
                mensaje.Text =
                    "Realiza tu transferencia.\n\n" +
                    "[ QR DE EJEMPLO ]\n\n" +
                    "Valor a pagar: $" + libro.Precio.ToString("0.00") +
                    "\n\n¿Realizaste la transferencia?";
                mensaje.Font = new Font("Arial", 11.5f);
                mensaje.ForeColor = texto;
                mensaje.TextAlign = ContentAlignment.MiddleCenter;
                mensaje.Size = new Size(310, 175);
                mensaje.Location = new Point(20, 20);
                qr.Controls.Add(mensaje);

                Button si = new Button();
                si.Text = "Sí";
                si.Size = new Size(115, 40);
                si.Location = new Point(45, 220);
                si.BackColor = morado;
                si.ForeColor = Color.White;
                si.FlatStyle = FlatStyle.Flat;
                si.FlatAppearance.BorderSize = 0;

                Button no = new Button();
                no.Text = "No";
                no.Size = new Size(115, 40);
                no.Location = new Point(185, 220);
                no.BackColor = Color.LightGray;
                no.FlatStyle = FlatStyle.Flat;
                no.FlatAppearance.BorderSize = 0;

                si.Click += (a, b) =>
                {
                    string codigo = GenerarCodigo();
                    libro.CodigoPago = codigo;
                    confirmarDigital();

                    MessageBox.Show(
                        "¡Pago confirmado!\n\n" +
                        "Libro: " + libro.Nombre +
                        "\nCódigo de retiro: " + codigo +
                        "\n\nTu compra está confirmada. " +
                        "Presenta este código a la bibliotecaria " +
                        "para retirar tu libro.",
                        "Compra realizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    qr.Close();
                    pago.Close();
                };

                no.Click += (a, b) =>
                {
                    MessageBox.Show(
                        "La compra no ha sido confirmada.",
                        "Pago no realizado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    qr.Close();
                };

                qr.Controls.Add(si);
                qr.Controls.Add(no);
                qr.ShowDialog(pago);
            };

            pago.Controls.Add(fisico);
            pago.Controls.Add(digital);
            pago.ShowDialog(this);
        }

        // GENERAR CÓDIGO
        private string GenerarCodigo()
        {
            return Guid.NewGuid()
                .ToString("N")
                .Substring(0, 6)
                .ToUpper();
        }

        // PÁGINA PARA VENDER
        private void MostrarVender()
        {
            contenido.Controls.Clear();

            Label titulo = new Label();
            titulo.Text = "Publica tu libro en B2Market";
            titulo.Font = new Font("Arial", 22, FontStyle.Bold);
            titulo.ForeColor = texto;
            titulo.AutoSize = true;
            titulo.Location = new Point(25, 20);
            contenido.Controls.Add(titulo);

            Label descripcion = new Label();
            descripcion.Text = "Completa los datos para ofrecer tu libro en la biblioteca del CEC.";
            descripcion.Font = new Font("Arial", 10);
            descripcion.ForeColor = Color.Gray;
            descripcion.AutoSize = true;
            descripcion.Location = new Point(27, 62);
            contenido.Controls.Add(descripcion);

            // NOMBRE
            AgregarEtiqueta("Nombre del libro:", 30, 110);
            TextBox txtNombre = new TextBox();
            txtNombre.Location = new Point(30, 135);
            txtNombre.Size = new Size(360, 30);
            contenido.Controls.Add(txtNombre);

            // NIVEL
            AgregarEtiqueta("Nivel del curso:", 30, 180);
            ComboBox cmbNivel = new ComboBox();
            cmbNivel.Location = new Point(30, 205);
            cmbNivel.Size = new Size(360, 30);
            cmbNivel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNivel.Items.AddRange(new string[]
            {
                "Beginner",
                "Basic 1",
                "Basic 2",
                "Basic 3",
                "Intermediate",
                "Advanced"
            });
            contenido.Controls.Add(cmbNivel);

            // PRECIO
            AgregarEtiqueta("Precio ($):", 30, 250);
            TextBox txtPrecio = new TextBox();
            txtPrecio.Location = new Point(30, 275);
            txtPrecio.Size = new Size(360, 30);
            contenido.Controls.Add(txtPrecio);

            // DESCRIPCIÓN
            AgregarEtiqueta("Descripción:", 30, 320);
            TextBox txtDescripcion = new TextBox();
            txtDescripcion.Location = new Point(30, 345);
            txtDescripcion.Size = new Size(360, 65);
            txtDescripcion.Multiline = true;
            contenido.Controls.Add(txtDescripcion);

            // PROPIETARIO
            AgregarEtiqueta("Nombre del propietario:", 30, 425);
            TextBox txtPropietario = new TextBox();
            txtPropietario.Location = new Point(30, 450);
            txtPropietario.Size = new Size(360, 30);
            contenido.Controls.Add(txtPropietario);

            // IMAGEN
            Button btnImagen = new Button();
            btnImagen.Text = "Seleccionar fotografía";
            btnImagen.Location = new Point(30, 500);
            btnImagen.Size = new Size(180, 35);
            btnImagen.BackColor = Color.White;
            btnImagen.ForeColor = morado;
            btnImagen.FlatStyle = FlatStyle.Flat;
            contenido.Controls.Add(btnImagen);

            Label lblImagen = new Label();
            lblImagen.Text = "Ninguna imagen seleccionada";
            lblImagen.Location = new Point(220, 509);
            lblImagen.AutoSize = true;
            contenido.Controls.Add(lblImagen);

            btnImagen.Click += (s, e) =>
            {
                OpenFileDialog archivo = new OpenFileDialog();
                archivo.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    rutaImagen = archivo.FileName;
                    lblImagen.Text = Path.GetFileName(rutaImagen);
                }
            };

            // PUBLICAR
            Button publicar = new Button();
            publicar.Text = "Publicar libro";
            publicar.Location = new Point(30, 555);
            publicar.Size = new Size(180, 45);
            publicar.BackColor = morado;
            publicar.ForeColor = Color.White;
            publicar.FlatStyle = FlatStyle.Flat;
            publicar.FlatAppearance.BorderSize = 0;
            publicar.Font = new Font("Arial", 10, FontStyle.Bold);
            contenido.Controls.Add(publicar);

            publicar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    cmbNivel.SelectedIndex == -1 ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                    string.IsNullOrWhiteSpace(txtPropietario.Text))
                {
                    MessageBox.Show(
                        "Completa los campos obligatorios.",
                        "Datos incompletos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                if (!decimal.TryParse(
                    txtPrecio.Text,
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out decimal precioLibro) || precioLibro <= 0)
                {
                    MessageBox.Show(
                        "Ingresa un precio válido. Ejemplo: 12.50",
                        "Precio incorrecto",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                Libro nuevoLibro = new Libro
                {
                    Nombre = txtNombre.Text.Trim(),
                    Nivel = cmbNivel.Text,
                    Precio = precioLibro,
                    Descripcion = txtDescripcion.Text.Trim(),
                    Propietario = txtPropietario.Text.Trim(),
                    Estado = "Disponible",
                    Imagen = rutaImagen
                };

                libros.Add(nuevoLibro);
                rutaImagen = "";

                MessageBox.Show(
                    "¡Tu libro se publicó correctamente en B2Market!",
                    "Publicación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                MostrarInicio();
            };
        }

        // ETIQUETAS DEL FORMULARIO
        private void AgregarEtiqueta(string textoEtiqueta, int x, int y)
        {
            Label etiqueta = new Label();
            etiqueta.Text = textoEtiqueta;
            etiqueta.Font = new Font("Arial", 10, FontStyle.Bold);
            etiqueta.ForeColor = texto;
            etiqueta.Location = new Point(x, y);
            etiqueta.AutoSize = true;
            contenido.Controls.Add(etiqueta);
        }
    }
}