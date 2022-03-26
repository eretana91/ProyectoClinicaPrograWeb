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
    public class Persona : ICRUD<data.Persona>
    {
        private RepositoryPersona repo;
        public Persona(NDbContext dbContext)
        {
            repo = new RepositoryPersona(dbContext);
        }
        public void Delete(data.Persona t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Persona> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Persona>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Persona GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Persona> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Persona t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Persona t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
