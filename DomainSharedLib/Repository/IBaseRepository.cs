

namespace DomainSharedLib.Repository { 

    public interface IBaseRepository<T> : IBaseQueryRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
