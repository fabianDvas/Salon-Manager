using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace SalonManager.UI
{
    public static class DatabaseHelper
    {
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SalonData.db");
        private static string connectionString = $"Data Source={dbPath}";

        public static void InicializarBaseDeDatos()
        {
            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    var command = connection.CreateCommand();

                    // Se ELIMINAn las TABLAS PARA FORZAR LA ACTUALIZACIÓN Y EVITAR CONFLICTOS DE LLAVES
                    // Es vital borrar CitaServicios antes que Citas por la relación de dependencia.
                    command.CommandText = "DROP TABLE IF EXISTS CitaServicios;";
                    command.ExecuteNonQuery();

                    command.CommandText = "DROP TABLE IF EXISTS Citas;";
                    command.ExecuteNonQuery();

                    // Se CREAN CREAMOS TODAS LAS TABLAS CON LA ESTRUCTURA CORRECTA
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Clientes (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nombre TEXT NOT NULL,
                            Telefono TEXT,
                            Correo TEXT
                        );
             
                        CREATE TABLE IF NOT EXISTS Estilistas (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nombre TEXT NOT NULL,
                            Telefono TEXT,
                            Especialidad TEXT
                        ); 
            
                        CREATE TABLE IF NOT EXISTS Citas (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Cliente TEXT,
                            Fecha TEXT,
                            Hora TEXT,
                            Estilista TEXT,
                            Estado TEXT
                        );

                        CREATE TABLE IF NOT EXISTS CitaServicios (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            CitaId INTEGER,
                            Servicio TEXT,
                            Precio REAL,
                            FOREIGN KEY (CitaId) REFERENCES Citas(Id) ON DELETE CASCADE
                        );";

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al inicializar la base de datos: " + ex.Message);
            }
        }

        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }
    }
}