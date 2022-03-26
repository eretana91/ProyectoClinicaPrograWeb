using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public interface IRepositoryUsuarios : IRepository<data.Usuarios>
    {
        Task<IEnumerable<data.Usuarios>> GetAllAsync();
        Task<data.Usuarios> GetOneByIdAsync(int id);
    }
}
