using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2E158.Models;
using System.Threading.Tasks;


namespace PM2E158.Controles
{
    public class BDExamen
    {
        readonly SQLiteAsyncConnection _connection;
        public BDExamen() { }
        public BDExamen(string dbpath)
        {
            _connection = new SQLiteAsyncConnection(dbpath);
            /*Crear todos mis objetos de base de datos : tablas */
            _connection.CreateTableAsync<Visitas>().Wait();
        }
        /* Crear el CRUD BD */

        public Task<int> AddVisit(Visitas visitas)
        {
            if (visitas.Id == 0)
            {
                return _connection.InsertAsync(visitas);
            }
            else
            {
                return _connection.UpdateAsync(visitas);
            }
        }

        public Task<List<Visitas>> GetAll()
        {
            return _connection.Table<Visitas>().ToListAsync();
        }
        public Task<Visitas> GetById(int id)
        {
            return _connection.Table<Visitas>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        //Delete

        public Task<int> DeleteEmple(Visitas visitas)
        {
            return _connection.DeleteAsync(visitas);
        }
    }
}
