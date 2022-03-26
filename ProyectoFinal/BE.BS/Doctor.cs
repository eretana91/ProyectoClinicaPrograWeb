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
    public class Doctor : ICRUD<data.Doctor>
    {
        private dal.Doctor _dal;
        public Doctor(NDbContext dbContext)
        {
            _dal = new dal.Doctor(dbContext);
        }
        public void Delete(data.Doctor t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Doctor> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Doctor>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Doctor GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Doctor> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Doctor t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Doctor t)
        {
            _dal.Update(t);
        }
    }
}
