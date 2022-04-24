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
    public class RepositoryExpedientes : Repository<data.Expedientes>, IRepositoryExpedientes
    {
        public RepositoryExpedientes(NDbContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<IEnumerable<Expedientes>> GetAllAsync()
        {
            //return null;
            return await _db.Expedientes.Include(n => n.Cedula).ToListAsync();
        }

        public async Task<Expedientes> GetOneByIdAsync(int id)
        {
            return await _db.Expedientes.Include(n => n.Canton).SingleOrDefaultAsync(n => n.IdExpediente == id);
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
