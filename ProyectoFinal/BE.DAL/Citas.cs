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
    public class Citas : ICRUD<data.Citas>
    {
        private Repository<data.Citas> repo;

        public Citas(NDbContext dbContext)
        {
            repo = new Repository<data.Citas>(dbContext);
        }
        public void Delete(data.Citas t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Citas> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Citas>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Citas GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Citas> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Citas t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Citas t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
