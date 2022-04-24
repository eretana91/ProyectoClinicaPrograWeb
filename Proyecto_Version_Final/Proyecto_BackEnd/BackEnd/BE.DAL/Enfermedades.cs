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
    public class Enfermedades : ICRUD<data.Enfermedades>
    {
        private Repository<data.Enfermedades> repo;

        public Enfermedades(NDbContext dbContext)
        {
            repo = new Repository<data.Enfermedades>(dbContext);
        }
        public void Delete(data.Enfermedades t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Enfermedades> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Enfermedades>> GetAllAsync()
        {
            return null;
            //return repo.GetAllAsync();
        }

        public data.Enfermedades GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Enfermedades> GetOneByIdAsync(int id)
        {
            return null;
            //return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Enfermedades t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Enfermedades t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
