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
    public class SchedulerRecurringEvent : ICRUD<data.SchedulerRecurringEvent>
    {
        private Repository<data.SchedulerRecurringEvent> repo;

        public SchedulerRecurringEvent(NDbContext dbContext)
        {
            repo = new Repository<data.SchedulerRecurringEvent>(dbContext);
        }
        public void Delete(data.SchedulerRecurringEvent t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.SchedulerRecurringEvent> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.SchedulerRecurringEvent>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.SchedulerRecurringEvent GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.SchedulerRecurringEvent> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.SchedulerRecurringEvent t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.SchedulerRecurringEvent t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
