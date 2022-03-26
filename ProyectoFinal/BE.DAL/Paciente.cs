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
    public class Paciente : ICRUD<data.Paciente>
    {
        private RepositoryPaciente repo;
        public Paciente(NDbContext dbContext)
        {
            repo = new RepositoryPaciente(dbContext);
        }
        public void Delete(data.Paciente t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Paciente> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Paciente>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Paciente GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Paciente> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Paciente t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Paciente t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
