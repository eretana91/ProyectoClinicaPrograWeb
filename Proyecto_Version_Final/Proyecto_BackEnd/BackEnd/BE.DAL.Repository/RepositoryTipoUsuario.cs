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
    public class RepositoryTipoUsuario : Repository<data.TipoUsuario>, IRepositoryTipoUsuario
    {
        public RepositoryTipoUsuario(NDbContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<IEnumerable<TipoUsuario>> GetAllAsync()
        {
            return await _db.TipoUsuario.Include(n => n.IdTipoUsuario).ToListAsync();
        }

        public async Task<TipoUsuario> GetOneByIdAsync(int id)
        {
            return await _db.TipoUsuario.Include(n => n.IdTipoUsuario).SingleOrDefaultAsync(n => n.IdTipoUsuario == id);
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
