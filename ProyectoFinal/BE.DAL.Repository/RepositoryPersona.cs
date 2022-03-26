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
    public class RepositoryPersona : Repository<data.Persona>, IRepositoryPersona
    {
        public RepositoryPersona(NDbContext _dbContext) : base(_dbContext)
        {

        }

        public Task<IEnumerable<Persona>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Persona> GetOneByIdAsync(int id)
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
