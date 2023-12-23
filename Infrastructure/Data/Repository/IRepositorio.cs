using System.Linq.Expressions;

namespace Infrastructure.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filtro = null,
                                             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> ordenarPor = null,
                                             string incluirPropriedades = "");

        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);


        void Add(TEntity entidade);
        void Update(TEntity entidade);

        void Delete(TEntity entidade);
        void SaveChanges();



    }


}
