using Microsoft.EntityFrameworkCore;
using SalonManager.Datos;
using SalonManager.Datos.Entidades;

namespace SalonManager.Negocios
{
    //Esta clase contine toda la logica del modulo inventario.
    //Los formularios llamaran a estos metodos en lugar de hablar
    //directamente con la base de datos
    public class InventarioServicio
    {
        private readonly SalonDbContext _context;

        //Constructor: recibe contexto por inyeccion de dependencias.
        public InventarioServicio(SalonDbContext context)
        {
            _context = context;
        }

        //Obtener todos los productos
        //Include() trae tambien el inventario relacioando
        //sin esto, inventario llegaria null
        public async Task<List<Producto>> ObtenerTodosAsync()
        {
            return await _context.Productos
                .Include(p => p.Inventario)
                .ToListAsync();
        }

        //Obtener un producto por su id
        //
        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Inventario)
                .FirstOrDefaultAsync(p => p.ProductoId == id);
        }

        //Agregar producto nuevo
        //Crear el producto y su inventario al mismo tiempo
        //porque son tablas separadas en la BD
        public async Task AgregarAsync(Producto producto, int stockInicial, int stockMinimo)
        {
            //Creo el inventario vinculado al producto
            producto.Inventario = new Inventario
            {
                StockActual = stockInicial,
                StockMinimo = stockMinimo
            };
            //Agrego y guardo en la base de datos
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        //Actualizar producto existente
        //Busco el original en BD y le cambio los valores
        //NO se crea uno nuevo, modifica el existente
        public async Task ActualizarAsync(Producto producto, int nuevoStock, int nuevoStockMinimo)
        {
            var existente = await ObtenerPorIdAsync(producto.ProductoId);
            if (existente == null) return;

            //Actualiza los campos del producto
            existente.Nombre = producto.Nombre;
            existente.Categoria = producto.Categoria;
            existente.PrecioCompra = producto.PrecioCompra;

            //Actualiza el inventario relacionado
            if (existente.Inventario != null)
            {
                existente.Inventario.StockActual = nuevoStock;
                existente.Inventario.StockMinimo = nuevoStockMinimo;
            }
             //Guarda todos los cambios en la base BD
            await _context.SaveChangesAsync();
        }

        //Eliminar producto
        //Al eliminar el producto, el EF Core tambien elimina
        //su inventario relacionado automaticamente
        public async Task EliminarAsync(int id)
        {
            var producto = await ObtenerPorIdAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }

        //Obtener productos con stock bajo
        //Compara sctockActual <= stockMinimo
        //Esta lista se usa para mostrar las alertas en rojo
        public async Task<List<Producto>> ObtenerStockBajoAsync()
        {
            return await _context.Productos
                .Include(p => p.Inventario)
                .Where(p => p.Inventario != null && p.Inventario.StockActual <= p.Inventario.StockMinimo).ToListAsync();
        }
    }
}

