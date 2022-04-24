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
    public class Enfermedades : ICRUD<data.Enfermedades>
    {

        private dal.Enfermedades _dal;
        public Enfermedades(NDbContext dbContext)
        {
            _dal = new dal.Enfermedades(dbContext);
        }
        public void Delete(data.Enfermedades t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Enfermedades> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Enfermedades>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Enfermedades GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Enfermedades> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Enfermedades t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Enfermedades t)
        {
            _dal.Update(t);
        }
    }
}
