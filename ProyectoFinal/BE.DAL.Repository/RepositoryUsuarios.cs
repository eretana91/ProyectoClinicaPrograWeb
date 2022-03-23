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
    public class RepositoryUsuarios : Repository<data.Usuarios>, IRepositoryUsuarios
    {
        public RepositoryUsuarios(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            //return null;
            return await _db.Usuarios.Include(n => n.CodigoUsuario).ToListAsync();
        }

        public async Task<Usuarios> GetOneByIdAsync(int id)
        {
            return await _db.Usuarios.Include(n => n.CodigoUsuario).SingleOrDefaultAsync(n => n.CodigoUsuario == id);
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
