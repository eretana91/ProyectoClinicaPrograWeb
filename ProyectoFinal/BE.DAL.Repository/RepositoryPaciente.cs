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
    public class RepositoryPaciente : Repository<data.Paciente>, IRepositoryPaciente
    {
        public RepositoryPaciente(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            //return null;
            return await _db.Paciente.Include(n => n.CodigoPaciente).ToListAsync();
        }

        public async Task<Paciente> GetOneByIdAsync(int id)
        {
            return await _db.Paciente.Include(n => n.CodigoPaciente).SingleOrDefaultAsync(n => n.CodigoPaciente == id);
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
