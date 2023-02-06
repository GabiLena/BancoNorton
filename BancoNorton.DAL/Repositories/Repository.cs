using BancoNorton.Domain.Repository;

namespace BancoNorton.DAL.Repositories;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;

    protected Repository(AppDbContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity?> FindByIdAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        return entity;
    }

    public virtual async Task<bool> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return await _context.SaveChangesAsync();
    }

    public virtual Task<bool> UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        return _context.SaveChangesAsync();
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var dbSet = _context.Set<TEntity>();
        var entity = await dbSet.FindAsync(id);

        if (entity is not null)
            dbSet.Remove(entity);

        return await _context.SaveChangesAsync();
    }
}
