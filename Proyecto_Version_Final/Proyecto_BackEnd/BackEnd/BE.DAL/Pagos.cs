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
    public class Pagos : ICRUD<data.Pagos>
    {
        private Repository<data.Pagos> repo;

        public Pagos(NDbContext dbContext)
        {
            repo = new Repository<data.Pagos>(dbContext);
        }
        public void Delete(data.Pagos t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Pagos> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Pagos>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Pagos GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Pagos> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Pagos t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Pagos t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
