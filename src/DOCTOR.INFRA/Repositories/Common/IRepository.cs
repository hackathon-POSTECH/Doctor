using DOCTOR.DOMAIN.common;
using System.Linq.Expressions;

namespace DOCTOR.INFRA.Repositories.Common;

public interface IRepository<T> where T : AggregateRoot
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null);
    Task<T> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    void Update(T entity);
    void SaveChangesAsync();
}
