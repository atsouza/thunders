using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Infrastructure.Data;


namespace Infrastructure.Data.Repository
{
    public class Repository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext _applicationDbContext;
        internal DbSet<TEntity> dbSet;


        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            dbSet = _applicationDbContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filtro = null,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> ordenarPor = null,
                                            string incluirPropriedades = "")
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filtro != null)
                    query = query.Where(filtro);

                foreach (var propriedade in incluirPropriedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(propriedade);
                }

                if (ordenarPor != null)
                    return ordenarPor(query);
                else
                    return query;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return dbSet.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public TEntity GetById(object id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Add(TEntity entidade)
        {
            dbSet.Add(entidade);
        }

        public void Update(TEntity entidade)
        {
            dbSet.Attach(entidade);
            _applicationDbContext.Entry(entidade).State = EntityState.Modified;

        }

        public void Delete(TEntity entidade)
        {
            dbSet.Remove(entidade);
        }


        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();            
        }

      

    }
}
