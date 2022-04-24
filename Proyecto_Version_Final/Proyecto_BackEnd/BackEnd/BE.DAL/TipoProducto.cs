using BE.DAL.DO.Interfaces;
using BE.DAL.EF;
using BE.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL
{
    public class TipoProducto : ICRUD<data.TipoProducto>
    {
        private Repository<data.TipoProducto> repo;

        public TipoProducto(NDbContext dbContext)
        {
            repo = new Repository<data.TipoProducto>(dbContext);
        }
        public void Delete(data.TipoProducto t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.TipoProducto> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.TipoProducto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.TipoProducto GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.TipoProducto> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.TipoProducto t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.TipoProducto t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
