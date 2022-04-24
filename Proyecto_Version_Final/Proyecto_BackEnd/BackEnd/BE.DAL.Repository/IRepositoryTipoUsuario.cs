using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;


namespace BE.DAL.Repository
{
    public interface IRepositoryTipoUsuario : IRepository<data.TipoUsuario>
    {
        Task<IEnumerable<data.TipoUsuario>> GetAllAsync();
        Task<data.TipoUsuario> GetOneByIdAsync(int id);
    }
}
