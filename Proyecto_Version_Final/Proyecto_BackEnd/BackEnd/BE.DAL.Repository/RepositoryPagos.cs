using BE.DAL.DO.Objects;
using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;

namespace BE.DAL.Repository
{
    public class RepositoryPagos : Repository<data.Pagos>, IRepositoryPagos
    {
        public RepositoryPagos(NDbContext _dbContext) : base(_dbContext)
        {

        }

        public void AddRange(IEnumerable<Pagos> t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pagos t)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pagos>> GetAllAsync()
        {
            //return null;
            return await _db.Pagos.Include(n => n.TipoPago).ToListAsync();
        }

        public Pagos GetOne(Expression<Func<Pagos, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagos> GetOneByIdAsync(int id)
        {
            return await _db.Pagos.Include(n => n.TipoPago).SingleOrDefaultAsync(n => n.IdPago == id);
        }

        public void Insert(Pagos t)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Pagos> t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pagos> Search(Expression<Func<Pagos, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public void Update(Pagos t)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Pagos> t)
        {
            throw new NotImplementedException();
        }

        IQueryable<Pagos> IRepository<Pagos>.AsQueryble()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Pagos> IRepository<Pagos>.GetAll()
        {
            throw new NotImplementedException();
        }

        Pagos IRepository<Pagos>.GetOnebyID(int id)
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
