using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Repository.IRepository
{
    public interface IPeopleRepository
    {
        // Task<PagedList<People>> GetPagedPeopleAsync(int offset, int page, int pageSize, CancellationToken cancellationToken = default(CancellationToken));
        Task<People> GetPersonByIdAsync(int id);
        Task AddPersonAsync(People person);
        Task UpdatePersonAsync(People person);
        Task DeletePersonAsync(int id);
        bool PersonExists(int id);
        Task<List<People>> GetPeopleAsync();
        Task<List<People>> SearchPeopleAsync(string searchString);
    }
}
