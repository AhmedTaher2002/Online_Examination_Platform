using System.Linq.Expressions;

namespace ExaminationSystem.Repositories
{
    public interface IGeneralRepository
    {
        IQueryable<T> GetAll<T>() where T : class;
        Task<T> GetByID<T>(int id) where T : class;
        IQueryable<T> Get<T>(Expression<Func<T, bool>> expression) where T : class;
        Task<T> GetByIDWithTracking<T>(int id) where T : class;
        Task Add<T>(T entity) where T : class;
        Task Update<T>(T entity) where T : class;
        Task Delete<T>(int id) where T : class;
        void UpdateInclude<T>(T entity, params string[] modifiedParams) where T : class;
        public Task<T> GetAllSoftDeleted<T>() where T : class;
        public Task<T> ReturnSoftDeletedObject<T>(int id) where T : class;
        public Task<T> GetSoftDeletedObject<T>(int id) where T : class;
        public bool IsExist(int id);
    }
}
