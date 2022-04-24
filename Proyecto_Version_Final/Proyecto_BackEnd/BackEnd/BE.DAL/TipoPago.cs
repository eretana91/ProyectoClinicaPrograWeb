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
    public class TipoPago : ICRUD<data.TipoPago>
    {
        private Repository<data.TipoPago> repo;

        public TipoPago(NDbContext dbContext)
        {
            repo = new Repository<data.TipoPago>(dbContext);
        }
        public void Delete(data.TipoPago t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.TipoPago> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.TipoPago>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.TipoPago GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.TipoPago> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.TipoPago t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.TipoPago t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
