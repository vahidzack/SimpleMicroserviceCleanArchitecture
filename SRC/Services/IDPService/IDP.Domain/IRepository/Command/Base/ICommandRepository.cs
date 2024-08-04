namespace IDP.Domain.IRepository.Command.Base
{
    public interface ICommandRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
