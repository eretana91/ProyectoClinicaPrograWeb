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
    public class Direccion : ICRUD<data.Direccion>
    {
        private Repository<data.Direccion> repo;

        public Direccion(NDbContext dbContext)
        {
            repo = new Repository<data.Direccion>(dbContext);
        }
        public void Delete(data.Direccion t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Direccion> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Direccion>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Direccion GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Direccion> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Direccion t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Direccion t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
