using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ITasksService
    {
        IEnumerable<Tasks> GetAll();
        Tasks Get(long id);
        Tasks Create(string name, string description);
        void Delete(long id);
        Tasks? Update(long id, string name, string description, bool isComplete);
        Tasks? UpdateIsComplete(long id, bool isComplete);
    }
}
