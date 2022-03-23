using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objects;

namespace BE.DAL.Repository
{
    internal interface IRepositoryPaciente : IRepository<data.Paciente>
    {
        Task<IEnumerable<data.Paciente>> GetAllAsync();
        Task<data.Paciente> GetOneByIdAsync(int id);
    }
}
