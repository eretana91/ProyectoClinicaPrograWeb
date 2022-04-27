using BE.DAL.DO.Interfaces;
using BE.DAL.EF;
using BE.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL
{
    //public class Biblioteca : ICRUD<data.Biblioteca>
    //{
    //    private Repository<data.Biblioteca> repo;

    //    public Biblioteca(NDbContext dbContext)
    //    {
    //        repo = new Repository<data.Biblioteca>(dbContext);
    //    }
    //    public void Delete(data.Biblioteca t)
    //    {
    //        repo.Delete(t);
    //        repo.Commit();
    //    }

    //    public IEnumerable<data.Biblioteca> GetAll()
    //    {
    //        return repo.GetAll();
    //    }

    //    public Task<IEnumerable<data.Biblioteca>> GetAllAsync()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public data.Biblioteca GetOneById(int id)
    //    {
    //        return repo.GetOnebyID(id);
    //    }

    //    public Task<data.Biblioteca> GetOneByIdAsync(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Insert(data.Biblioteca t)
    //    {
    //        repo.Insert(t);
    //        repo.Commit();
    //    }

    //    public void Update(data.Biblioteca t)
    //    {
    //        repo.Update(t);
    //        repo.Commit();
    //    }
    //}
}
