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
    public class Doctor : ICRUD<data.Doctor>
    {
        private RepositoryDoctor repo;
        public Doctor(NDbContext dbContext)
        {
            repo = new RepositoryDoctor(dbContext);
        }
        public void Delete(data.Doctor t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Doctor> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Doctor>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Doctor GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Doctor> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Doctor t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Doctor t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
