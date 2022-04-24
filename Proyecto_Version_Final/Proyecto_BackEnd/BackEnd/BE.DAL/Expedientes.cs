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
    public class Expedientes : ICRUD<data.Expedientes>
    {
        private Repository<data.Expedientes> repo;

        public Expedientes(NDbContext dbContext)
        {
            repo = new Repository<data.Expedientes>(dbContext);
        }
        public void Delete(data.Expedientes t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Expedientes> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Expedientes>> GetAllAsync()
        {
            return null;
            //return repo.GetAllAsync();
        }

        public data.Expedientes GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Expedientes> GetOneByIdAsync(int id)
        {
            return null;
           //return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Expedientes t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Expedientes t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
