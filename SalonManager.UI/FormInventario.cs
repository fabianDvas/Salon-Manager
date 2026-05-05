using Microsoft.EntityFrameworkCore;
using SalonManager.Datos;
using SalonManager.Datos.Entidades;
using SalonManager.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SalonManager.UI
{
    public partial class FormInventario : Form
    {
        private readonly InventarioServicio _servicio;

        public FormInventario(SalonDbContext context)
        {
            InitializeComponent();
            _servicio = new InventarioServicio(context);
        }

        // Carga la lista al abrir el formulario
        private async void FormInventario_Load(object sender, EventArgs e)
        {
            await CargarProductosAsync();
        }

        private async Task CargarProductosAsync()
        {
            var productos = await _servicio.ObtenerTodosAsync();

            // Mostramos solo las columnas que el usuario necesita ver
            dgvProductos.DataSource = productos.Select(p => new
            {
                ID = p.ProductoId,
                Nombre = p.Nombre,
                Categoria = p.Categoria,
                Precio = p.PrecioCompra,
                StockActual = p.Inventario?.StockActual ?? 0,
                StockMinimo = p.Inventario?.StockMinimo ?? 0
            }).ToList();

            // Pinta en rojo las filas donde el stock esta por debajo del minimo
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                int actual = Convert.ToInt32(fila.Cells["StockActual"].Value);
                int minimo = Convert.ToInt32(fila.Cells["StockMinimo"].Value);
                if (actual <= minimo)
                    fila.DefaultCellStyle.BackColor = Color.LightCoral;
            }

            // Actualiza el label de alerta segun cuantos productos tienen stock bajo
            var bajos = await _servicio.ObtenerStockBajoAsync();
            lblAlerta.Text = bajos.Count > 0
                ? $"Alerta {bajos.Count} producto(s) con stock bajo"
                : " Stock en buen estado";
            lblAlerta.ForeColor = bajos.Count > 0 ? Color.Red : Color.Green;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var form = new FormProducto(null, _servicio);
            if (form.ShowDialog() == DialogResult.OK)
                await CargarProductosAsync();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["ID"].Value);
            var producto = await _servicio.ObtenerPorIdAsync(id);

            var form = new FormProducto(producto, _servicio);
            if (form.ShowDialog() == DialogResult.OK)
                await CargarProductosAsync();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            // Guardar la fila en una variable para que C# no dude de que es null
            var fila = dgvProductos.CurrentRow;
            int id = Convert.ToInt32(fila.Cells["ID"].Value);
            string nombre = fila.Cells["Nombre"].Value?.ToString() ?? "este producto";

            var confirmar = MessageBox.Show(
                $"¿Eliminar '{nombre}'?",
                "Confirmar eliminacion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmar == DialogResult.Yes)
            {
                await _servicio.EliminarAsync(id);
                await CargarProductosAsync();
            }
        }

        private async void btnStockBajo_Click(object sender, EventArgs e)
        {
            var bajos = await _servicio.ObtenerStockBajoAsync();

            if (bajos.Count == 0)
            {
                MessageBox.Show(" Todos los productos tienen stock suficiente.");
                return;
            }

            // Construcion de la lista de productos con stock bajo para mostrarla
            var lista = string.Join("\n", bajos.Select(p =>
                $"• {p.Nombre} - Stock: {p.Inventario?.StockActual} / Minimo: {p.Inventario?.StockMinimo}"));

            MessageBox.Show($"Productos con stock bajo:\n\n{lista}",
                " Alerta de Stock",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

    }
}
