using System;
using System.Collections.Generic;
using System.Text;
using data = BE.DAL.DO.Objects;
using dal = BE.DAL;
using BE.DAL.DO.Interfaces;
using System.Threading.Tasks;
using BE.DAL.EF;

namespace BE.BS
{
    public class SchedulerRecurringEvents : ICRUD<data.SchedulerRecurringEvent>
    {

        private dal.SchedulerRecurringEvent _dal;
        public SchedulerRecurringEvents(NDbContext dbContext)
        {
            _dal = new dal.SchedulerRecurringEvent(dbContext);
        }
        public void Delete(data.SchedulerRecurringEvent t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.SchedulerRecurringEvent> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.SchedulerRecurringEvent>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.SchedulerRecurringEvent GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.SchedulerRecurringEvent> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.SchedulerRecurringEvent t)
        {
            _dal.Insert(t);
        }

        public void Update(data.SchedulerRecurringEvent t)
        {
            _dal.Update(t);
        }
    }
}
