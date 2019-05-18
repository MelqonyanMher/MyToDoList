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

        public Itam GetItam(Guid id)
        {
            return  _context.Tasks.SingleOrDefault(i => i.Id == id);
        }

        public  IEnumerable<Itam> GetItams(OrderBy orderBy = OrderBy.IdAsc, int offset = 0, int limit = 10, bool? completed = null, string titleFilter = null)
        {
            var query = _context.Tasks.AsQueryable();
            switch (orderBy)
            {
                case OrderBy.TitleAsc:
                    query = _context.Tasks.OrderBy(i => i.Title);
                    break;
                case OrderBy.TitleDesc:
                    query = _context.Tasks.OrderByDescending(i => i.Title);
                    break;
                case OrderBy.IdAsc:
                    query = _context.Tasks.OrderBy(i => i.Id);
                    break;
                case OrderBy.IdDesc:
                    query = _context.Tasks.OrderByDescending(i => i.Id);
                    break;
                default:
                    break;
            }

            if (offset >= 0 && limit >= 0)
            {
                try
                {
                    query = _context.Tasks.Skip(offset).Take(limit);
                }
                catch
                {
                    throw;
                }
            }

            if (completed.HasValue)
            {
                query = _context.Tasks.Where(i => i.Compleated == completed);
            }

            if(titleFilter!= null)
            {
                query = _context.Tasks.Where(i => i.Title.Contains(titleFilter));
            }

            return query;
        }
    }
}
