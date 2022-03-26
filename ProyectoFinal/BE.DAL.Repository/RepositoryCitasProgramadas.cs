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
    public class RepositoryCitasProgramadas : Repository<data.CitasProgramadas>, IRepositoryCitasProgramadas
    {
        public RepositoryCitasProgramadas(NDbContext _dbContext) : base(_dbContext)
        {

        }

        public Task<IEnumerable<CitasProgramadas>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CitasProgramadas> GetOneByIdAsync(int id)
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
