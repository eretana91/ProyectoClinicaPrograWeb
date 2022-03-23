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
    public class RepositoryDoctor : Repository<data.Doctor>, IRepositoryDoctor
    {
    public RepositoryDoctor(NDbContext _dbContext) : base(_dbContext)
    {

    }
    public async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        //return null;
        return await _db.Doctor.Include(n => n.CodigoDoctor).ToListAsync();
    }

    public async Task<Doctor> GetOneByIdAsync(int id)
    {
        return await _db.Doctor.Include(n => n.CodigoDoctor).SingleOrDefaultAsync(n => n.CodigoDoctor == id);
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
