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
    public class Usuario : ICRUD<data.Usuario>
    {
        private Repository<data.Usuario> repo;

        public Usuario(NDbContext dbContext)
        {
            repo = new Repository<data.Usuario>(dbContext);
        }
        public void Delete(data.Usuario t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Usuario> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Usuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Usuario GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Usuario> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Usuario t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Usuario t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
