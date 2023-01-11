namespace BancoNorton.DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _contexto;

    protected Repository(AppDbContext context)
    {
        _contexto = context;
    }

    public virtual async Task<TEntity> FindByIdAsync(int id)
    {
        var objeto = await _contexto.Set<TEntity>().FindAsync(id);
        return objeto!;
    }

    public virtual async Task<bool> AddAsync(TEntity entity)
    {
        await _contexto.Set<TEntity>().AddAsync(entity);
        return await _contexto.SaveChangesAsync();
    }

    public virtual Task<bool> UpdateAsync(TEntity entity)
    {
        _contexto.Set<TEntity>().Update(entity);
        return _contexto.SaveChangesAsync();
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var dbSet = _contexto.Set<TEntity>();
        var entity = await dbSet.FindAsync(id);

        if (entity is not null)
            dbSet.Remove(entity);

        return await _contexto.SaveChangesAsync();
    }
}
public interface IRepository<TEntity>
{
    Task<TEntity> FindByIdAsync(int id);
    Task<bool> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(int id);
}
