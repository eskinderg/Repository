using System.Data.Entity;
using Project.Model;

namespace Project.Data
{
    public interface IDbContext
    {

        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        int SaveChanges();

        int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);

    }
}
