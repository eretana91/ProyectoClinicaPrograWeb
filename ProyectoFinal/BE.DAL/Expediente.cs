using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objects;
using BE.DAL.EF;
using BE.DAL.Repository;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;

namespace BE.DAL
{
    public class Expediente : ICRUD<data.Expediente>
    {
        private RepositoryExpediente repo;
        public Expediente(NDbContext dbContext)
        {
            repo = new RepositoryExpediente(dbContext);
        }
        public void Delete(data.Expediente t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Expediente> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Expediente>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Expediente GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Expediente> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Expediente t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Expediente t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
