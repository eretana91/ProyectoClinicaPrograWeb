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
    public class Inventarios : ICRUD<data.Inventarios>
    {
        private Repository<data.Inventarios> repo;

        public Inventarios(NDbContext dbContext)
        {
            repo = new Repository<data.Inventarios>(dbContext);
        }
        public void Delete(data.Inventarios t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Inventarios> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Inventarios>> GetAllAsync()
        {
            return null;
            //return repo.GetAllAsync();
        }

        public data.Inventarios GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Inventarios> GetOneByIdAsync(int id)
        {
            return null;
            //return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Inventarios t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Inventarios t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
