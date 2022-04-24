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
    public class Expedientes : ICRUD<data.Expedientes>
    {

        private dal.Expedientes _dal;
        public Expedientes(NDbContext dbContext)
        {
            _dal = new dal.Expedientes(dbContext);
        }
        public void Delete(data.Expedientes t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Expedientes> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Expedientes>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Expedientes GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Expedientes> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Expedientes t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Expedientes t)
        {
            _dal.Update(t);
        }
    }
}
