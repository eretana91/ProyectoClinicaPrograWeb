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
    public class TipoProductoes : ICRUD<data.TipoProducto>
    {

        private dal.TipoProducto _dal;
        public TipoProductoes(NDbContext dbContext)
        {
            _dal = new dal.TipoProducto(dbContext);
        }
        public void Delete(data.TipoProducto t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.TipoProducto> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.TipoProducto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.TipoProducto GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.TipoProducto> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.TipoProducto t)
        {
            _dal.Insert(t);
        }

        public void Update(data.TipoProducto t)
        {
            _dal.Update(t);
        }
    }
}
