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
    public class CitasProgramadas : ICRUD<data.CitasProgramadas>
    {
        private RepositoryCitasProgramadas repo;
        public CitasProgramadas(NDbContext dbContext)
        {
            repo = new RepositoryCitasProgramadas(dbContext);
        }
        public void Delete(data.CitasProgramadas t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.CitasProgramadas> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.CitasProgramadas>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.CitasProgramadas GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.CitasProgramadas> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.CitasProgramadas t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.CitasProgramadas t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
