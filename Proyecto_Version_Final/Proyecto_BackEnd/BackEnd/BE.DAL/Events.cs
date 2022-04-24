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
    public class Events : ICRUD<data.Events>
    {
        private Repository<data.Events> repo;

        public Events(NDbContext dbContext)
        {
            repo = new Repository<data.Events>(dbContext);
        }
        public void Delete(data.Events t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Events> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Events>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Events GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Events> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Events t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Events t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
