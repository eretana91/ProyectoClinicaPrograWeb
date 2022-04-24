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
    public class RepositoryEnfermedades : Repository<data.Enfermedades>, IRepositoryEnfermedades
    {
        public RepositoryEnfermedades(NDbContext _dbContext) : base(_dbContext)
        {

        }

        private NDbContext _db
        {
            get
            {
                return dbContext as NDbContext;
            }
        }

        public async Task<IEnumerable<Enfermedades>> GetAllAsync()
        {
            return await _db.Enfermedades.Include(n => n.Cedula).ToListAsync();
        }

        public async Task<Enfermedades> GetOneByIdAsync(int id)
        {
            return await _db.Enfermedades.Include(n => n.Cedula).SingleOrDefaultAsync(n => n.IdEnfermedad == id);
        }
    }
}
