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
    public class Pagos : ICRUD<data.Pagos>
    {

        private dal.Pagos _dal;
        public Pagos(NDbContext dbContext)
        {
            _dal = new dal.Pagos(dbContext);
        }
        public void Delete(data.Pagos t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Pagos> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Pagos>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Pagos GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Pagos> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Pagos t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Pagos t)
        {
            _dal.Update(t);
        }
    }
}
