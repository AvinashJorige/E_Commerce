using CoreModel.Interfaces;

namespace Service.Interfaces
{
    public partial interface IGenericService<TEntity> : IActionCore<TEntity> where TEntity : class
    {
    }
}
