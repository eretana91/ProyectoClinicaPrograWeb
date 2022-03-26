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
    public class Usuarios : ICRUD<data.Usuarios>
    {
        private RepositoryUsuarios repo;
        public Usuarios(NDbContext dbContext)
        {
            repo = new RepositoryUsuarios(dbContext);
        }
        public void Delete(data.Usuarios t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Usuarios> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Usuarios>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Usuarios GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Usuarios> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Usuarios t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Usuarios t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
