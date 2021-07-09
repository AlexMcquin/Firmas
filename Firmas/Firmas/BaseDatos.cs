using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Firmas
{
    public class BaseDatos
    {

        readonly SQLiteAsyncConnection db;

        public BaseDatos(String dbpath)
        {
            db = new SQLiteAsyncConnection(dbpath);
            // Creacion de las tablas de la base de datos

            db.CreateTableAsync<Firmas>().Wait();

        }
        // Metodos del CRUD

        // Select
        public Task<List<Firmas>> ObtenerFirmas()
        {
            return db.Table<Firmas>().ToListAsync();
        }





        // Insert
        public Task<int> InsertarFirma(Firmas signature)
        {
            if (signature.id != 0)
            {
                return db.UpdateAsync(signature); // UPDATE
            }
            else
            {
                return db.InsertAsync(signature); // INSERT
            }
        }



        public Task<Firmas> ObtenerFirma(int pid)
        {
            return db.Table<Firmas>()
            .Where(i => i.id == pid)
            .FirstOrDefaultAsync();
        }


        // Delete
        public Task<int> EliminarFirma(Firmas ubicacion)
        {
            return db.DeleteAsync(ubicacion);
        }




    }
}
