using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.AspNetCore.Models;

namespace Tasks.AspNetCore.Services
{
    public interface IToDoService
    {
        Task<Itam> AddAsync(Itam i);

        Task DeleteAsync(Itam i);

        Task ChangeConditionAsync(Itam i);

        Task<Itam> GetItamAsync(Guid id);

        Task<IEnumerable<Itam>> GetItamsAsync(OrderBy orderBy = OrderBy.IdAsc,
            int offset = 0,
            int limit = 10,
            bool? completed = null,
            string titleFilter = null);
    }

    public enum OrderBy
    {
        TitleAsc,
        TitleDesc,
        IdAsc,
        IdDesc

    }
}
