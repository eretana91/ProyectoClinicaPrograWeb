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
    public class Direccion : ICRUD<data.Direccion>
    {

        private dal.Direccion _dal;
        public Direccion(NDbContext dbContext)
        {
            _dal = new dal.Direccion(dbContext);
        }
        public void Delete(data.Direccion t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Direccion> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Direccion>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Direccion GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Direccion> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Direccion t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Direccion t)
        {
            _dal.Update(t);
        }
    }
}
