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
    public class RepositoryInventarios : Repository<data.Inventarios>, IRepositoryInventarios
    {
        public RepositoryInventarios(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<Inventarios>> GetAllAsync()
        {
            //return null;
            return await _db.Inventarios.Include(n => n.TipoProducto).ToListAsync();
        }

        public async Task<Inventarios> GetOneByIdAsync(int id)
        {
            return await _db.Inventarios.Include(n => n.TipoProducto).SingleOrDefaultAsync(n => n.IdProducto == id);
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
