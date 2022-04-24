using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    public interface IRepositoryUsuario : IRepository<data.Usuario>
    {
        Task<IEnumerable<data.Usuario>> GetAllAsync();
        Task<data.Usuario> GetOneByIdAsync(int id);
    }
}
