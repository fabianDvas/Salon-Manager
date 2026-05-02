using System;
using System.Collections.Generic;

namespace SalonManager.Datos.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();  // traer todos
        Task<T?> GetByIdAsync(int id);       // traer uno por ID
        Task AddAsync(T entity);             // insertar
        Task UpdateAsync(T entity);          // actualizar
        Task DeleteAsync(int id);            // eliminar
    }
}