using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SalonManager.Datos.Entidades;
using SalonManager.Negocios;

namespace SalonManager.UI
{
    public partial class FormProducto : Form
    {
        private readonly InventarioServicio _servicio;
        private readonly Producto? _productoExistente;

        // Si el producto es null esta agregando, si tiene valor esta editando
        public FormProducto(Producto? producto, InventarioServicio servicio)
        {
            InitializeComponent();
            _servicio = servicio;
            _productoExistente = producto;
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {
            // Cargamos las categorias disponibles en el ComboBox
            cmbCategoria.Items.AddRange(new[]
            {
                "Shampoo", "Tinte", "Acondicionador",
                "Cera", "Gel", "Herramienta", "Otro"
            });

            // Si se esta editando, llena los campos con los datos actuales
            if (_productoExistente != null)
            {
                txtNombre.Text = _productoExistente.Nombre;
                cmbCategoria.SelectedItem = _productoExistente.Categoria;
                txtPrecio.Text = _productoExistente.PrecioCompra.ToString();
                txtStockActual.Text = _productoExistente.Inventario?.StockActual.ToString() ?? "0";
                txtStockMinimo.Text = _productoExistente.Inventario?.StockMinimo.ToString() ?? "5";
                Text = " Editar Producto";
            }
            else
            {
                Text = " Agregar Producto";
            }
        }

        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
            {
                MessageBox.Show("Ingresa un precio valido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtStockActual.Text, out int stockActual) || stockActual < 0)
            {
                MessageBox.Show("El stock no puede ser negativo.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtStockMinimo.Text, out int stockMinimo) || stockMinimo < 0)
            {
                MessageBox.Show("El stock minimo no puede ser negativo.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // fin de validaciones

            var producto = new Producto
            {
                Nombre = txtNombre.Text.Trim(),
                Categoria = cmbCategoria.SelectedItem?.ToString() ?? "Otro",
                PrecioCompra = precio
            };

            if (_productoExistente == null)
            {
                await _servicio.AgregarAsync(producto, stockActual, stockMinimo);
                MessageBox.Show(" Producto agregado correctamente.");
            }
            else
            {
                producto.ProductoId = _productoExistente.ProductoId;
                await _servicio.ActualizarAsync(producto, stockActual, stockMinimo);
                MessageBox.Show(" Producto actualizado correctamente.");
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
