using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.AspNetCore.Models;

namespace Tasks.AspNetCore.Services
{
    public class ToDoService : IToDoService
    {
        private TasksContext _context;

        public ToDoService(TasksContext context)
        {
            _context = context;
        }

        public async Task<Itam> AddAsync(Itam i)
        {
            await _context.Tasks.AddAsync(i);
            await _context.SaveChangesAsync();
            return i;
        }

        public async Task DeleteAsync(Itam i)
        {
            i = _context.Tasks.SingleOrDefault(x => x.Id == i.Id);
            _context.Tasks.Remove(i);
            await _context.SaveChangesAsync();
        }

        public async Task ChangeConditionAsync(Itam i)
        {
            var itam = _context.Tasks.SingleOrDefault(x => x.Id == i.Id);

            if (i.Compleated)
            {
                itam.Compleated = false;
            }
            else
            {
                itam.Compleated = true;
            }

            _context.Tasks.Update(itam);
            await _context.SaveChangesAsync();
        }

        public async Task<Itam> GetItamAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Itam>> GetItamsAsync(OrderBy orderBy = OrderBy.IdAsc, int offset = 0, int limit = 10, bool? completed = null, string titleFilter = null)
        {
            throw new NotImplementedException();
        }
    }
}
