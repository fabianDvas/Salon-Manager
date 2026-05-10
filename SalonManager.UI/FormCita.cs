using SalonManager.Datos;
using SalonManager.Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SalonManager.UI
{
    public partial class FormCita : Form
    {
        private List<Estilista> _estilistasActivos = new List<Estilista>();
        private Dictionary<string, decimal> _preciosServicios = new Dictionary<string, decimal>();

        public FormCita()
        {
            InitializeComponent();
            // Configuración para que el usuario escriba el nombre del cliente
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDown;
            cmbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void FormCita_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Estados
                cmbEstado.Items.Clear();
                cmbEstado.Items.AddRange(new string[] { "Pendiente", "Completada", "Cancelada" });
                cmbEstado.SelectedIndex = 0;

                var optionsBuilder = new DbContextOptionsBuilder<SalonDbContext>();
                optionsBuilder.UseSqlite("Data Source=salon.db");

                using (var db = new SalonDbContext(optionsBuilder.Options))
                {
                    // 2. Variedad de Estilistas
                    _estilistasActivos = db.Estilistas.ToList();
                    if (_estilistasActivos.Count < 4)
                    {
                        db.Estilistas.AddRange(new List<Estilista> {
                            new Estilista { Nombre = "Ana (Senior - Colorista)", Especialidad = "Tinte" },
                            new Estilista { Nombre = "Pedro (Junior - Cortes)", Especialidad = "Corte" },
                            new Estilista { Nombre = "Luis (Master - Estilismo)", Especialidad = "Peinados" },
                            new Estilista { Nombre = "Sofía (Asistente)", Especialidad = "Lavado" }
                        });
                        db.SaveChanges();
                        _estilistasActivos = db.Estilistas.ToList();
                    }

                    cmbEstilista.Items.Clear();
                    foreach (var est in _estilistasActivos) cmbEstilista.Items.Add(est.Nombre);

                    cmbCliente.Items.Clear();
                    foreach (var n in db.Clientes.Select(c => c.Nombre)) cmbCliente.Items.Add(n);

                    // 3. Servicios con Precios
                    _preciosServicios.Clear();
                    _preciosServicios.Add("Corte de Cabello", 500.00m);
                    _preciosServicios.Add("Lavado y Secado", 350.00m);
                    _preciosServicios.Add("Tinte Profesional", 1200.00m);
                    _preciosServicios.Add("Manicura", 400.00m);

                    checkedListBox1.Items.Clear();
                    foreach (var servicio in _preciosServicios)
                    {
                        checkedListBox1.Items.Add($"{servicio.Key} (${servicio.Value})");
                    }

                    if (cmbEstilista.Items.Count > 0) cmbEstilista.SelectedIndex = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar: " + ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreIngresado = cmbCliente.Text.Trim();
            if (string.IsNullOrEmpty(nombreIngresado) || cmbEstilista.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<SalonDbContext>();
                optionsBuilder.UseSqlite("Data Source=salon.db");

                using (var db = new SalonDbContext(optionsBuilder.Options))
                {
                    var clienteDB = db.Clientes.FirstOrDefault(c => c.Nombre.ToLower() == nombreIngresado.ToLower());
                    if (clienteDB == null)
                    {
                        clienteDB = new Cliente { Nombre = nombreIngresado, Telefono = "N/A" };
                        db.Clientes.Add(clienteDB);
                        db.SaveChanges();
                    }

                    var nuevaCita = new Cita
                    {
                        Fecha = dtpFecha.Value,
                        ClienteId = clienteDB.ClienteId,
                        EstilistaId = _estilistasActivos[cmbEstilista.SelectedIndex].EstilistaId,
                        Estado = (EstadoCita)Enum.Parse(typeof(EstadoCita), cmbEstado.Text)
                    };

                    db.Citas.Add(nuevaCita);
                    db.SaveChanges();
                }

                decimal total = CalcularTotal();

                // MENSAJE DE ÉXITO 
                string mensajeResumen = $"--- REGISTRO DE CITA EXITOSO ---\n\n" +
                                       $"CLIENTE: {nombreIngresado.ToUpper()}\n" +
                                       $"TOTAL ESTIMADO: ${total:N2}\n\n" +
                                       $"Los datos se han guardado correctamente.";

                MessageBox.Show(mensajeResumen, "Salon Manager ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar: " + ex.Message); }
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in checkedListBox1.CheckedItems)
            {
                string? itemTexto = item?.ToString();
                if (!string.IsNullOrEmpty(itemTexto))
                {
                    string nombreServicio = itemTexto.Split('(')[0].Trim();
                    if (_preciosServicios.ContainsKey(nombreServicio))
                        total += _preciosServicios[nombreServicio];
                }
            }
            return total;
        }

        // EVENTO LIMPIAR: Quita todos los cambios realizados
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //  Limpiar la interfaz visual 
            cmbCliente.Text = "";
            cmbCliente.SelectedIndex = -1;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            //  Mejora: Resetear Fecha y Combos a valores iniciales
            dtpFecha.Value = DateTime.Now;
            if (cmbEstado.Items.Count > 0) cmbEstado.SelectedIndex = 0;
            if (cmbEstilista.Items.Count > 0) cmbEstilista.SelectedIndex = 0;

            // Esto asegura que si borraste el archivo 'salon.db', el combo se vacíe de inmediato
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<SalonDbContext>();
                optionsBuilder.UseSqlite("Data Source=salon.db");

                using (var db = new SalonDbContext(optionsBuilder.Options))
                {
                    cmbCliente.Items.Clear();
                    var nombres = db.Clientes.Select(c => c.Nombre).ToList();
                    foreach (var n in nombres) cmbCliente.Items.Add(n);
                }
            }
            catch { /* Si el archivo no existe aún, simplemente queda vacío */ }
        }

        // EVENTO CANCELAR: Cierra la ventana
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}