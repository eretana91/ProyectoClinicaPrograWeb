using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objects;
using dal = BE.DAL;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;
using BE.DAL.EF;

namespace BE.BS
{
    public class Persona : ICRUD<data.Persona>
    {
        private dal.Persona _dal;
        public Persona(NDbContext dbContext)
        {
            _dal = new dal.Persona(dbContext);
        }
        public void Delete(data.Persona t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Persona> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Persona>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Persona GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Persona> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Persona t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Persona t)
        {
            _dal.Update(t);
        }
    }
}
