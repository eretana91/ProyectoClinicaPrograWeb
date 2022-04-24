using BE.DAL.DO.Objects;
using BE.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public class RepositoryUsuarios : Repository<data.Usuario>, IRepositoryUsuarios
    {
        public RepositoryUsuarios(NDbContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _db.Usuario.Include(n => n.IdTipoUsuario).ToListAsync();
        }

        public async Task<Usuario> GetOneByIdAsync(string id)
        {
            return await _db.Usuario.Include(n => n.IdTipoUsuario).SingleOrDefaultAsync(n => n.Cedula == id);
        }

        public Task<Usuario> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private NDbContext _db
        {
            get
            {
                return dbContext as NDbContext;
            }
        }
    }
}
