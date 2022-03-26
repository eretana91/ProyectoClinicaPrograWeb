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
    public class Expediente : ICRUD<data.Expediente>
    {
        private dal.Expediente _dal;
        public Expediente(NDbContext dbContext)
        {
            _dal = new dal.Expediente(dbContext);
        }
        public void Delete(data.Expediente t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Expediente> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Expediente>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Expediente GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Expediente> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Expediente t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Expediente t)
        {
            _dal.Update(t);
        }
    }
}
