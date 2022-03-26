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
    public class TipoUsuario : ICRUD<data.TipoUsuario>
    {
        private Repository<data.TipoUsuario> repo;

        public TipoUsuario(NDbContext dbContext)
        {
            repo = new Repository<data.TipoUsuario>(dbContext);
        }
        public void Delete(data.TipoUsuario t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.TipoUsuario> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.TipoUsuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.TipoUsuario GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.TipoUsuario> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.TipoUsuario t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.TipoUsuario t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
