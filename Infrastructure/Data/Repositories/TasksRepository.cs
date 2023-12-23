using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class TasksRepository : Repository<Tasks>, IRepository<Tasks>
    {
        public TasksRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
