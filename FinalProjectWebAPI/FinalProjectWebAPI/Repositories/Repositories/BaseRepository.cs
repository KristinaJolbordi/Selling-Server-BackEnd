using FinalProjectWebAPI.Model;
using FinalProjectWebAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly SellingDbContext context;
    protected DbSet<T> entities;
    string errorMessage = string.Empty;
    public BaseRepository(SellingDbContext context)
    {
        this.context = context;
        entities = context.Set<T>();
    }
    public IEnumerable<T> GetAll() => entities.AsEnumerable();
    public T Get(int id) => entities.Find(id);
    public void Insert(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException("entity");

        entities.Add(entity);
        context.SaveChanges();
    }
    public void Update(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException("entity");

        context.SaveChanges();
    }
    public void Delete(T entity)
    {
        if (entity == null)
            throw new ArgumentNullException("entity");

        entities.Remove(entity);
        context.SaveChanges();
    }
    public IQueryable<T> FindAll() => context.Set<T>().AsNoTracking();
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        context.Set<T>().Where(expression).AsNoTracking();
}
