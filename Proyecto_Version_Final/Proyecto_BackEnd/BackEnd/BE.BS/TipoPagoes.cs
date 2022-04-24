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
    public class TipoPagoes : ICRUD<data.TipoPago>
    {

        private dal.TipoPago _dal;
        public TipoPagoes(NDbContext dbContext)
        {
            _dal = new dal.TipoPago(dbContext);
        }
        public void Delete(data.TipoPago t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.TipoPago> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.TipoPago>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.TipoPago GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.TipoPago> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.TipoPago t)
        {
            _dal.Insert(t);
        }

        public void Update(data.TipoPago t)
        {
            _dal.Update(t);
        }
    }
}
