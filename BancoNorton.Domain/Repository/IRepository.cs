namespace BancoNorton.Domain.Repository;

public interface IRepository<TEntity>
{
    Task<TEntity?> FindByIdAsync(int id);
    Task<bool> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(int id);
}
