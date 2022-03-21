using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BE.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        //Select customizado mas rapido
        IQueryable<T> AsQueryble();

        //Select customizado
        IEnumerable<T> GetAll();

        //SelectAll pero se construye el where de manera dinamica
        IEnumerable<T> Search(Expression<Func<T, bool>> predicado);

        //Utilizar un predicado para obtener un objeto
        T GetOne(Expression<Func<T, bool>> predicado);

        //Obtener por un ID nada mas
        T GetOnebyID(int id);

        //CRUD
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        void Commit();

        //BULK - se pasa un grupo o una lista
        void AddRange(IEnumerable<T> t);
        void UpdateRange(IEnumerable<T> t);
        void RemoveRange(IEnumerable<T> t);
    }
}
