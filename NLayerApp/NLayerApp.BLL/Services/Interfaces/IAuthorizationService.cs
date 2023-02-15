using NLayerApp.BLL.BusinessModels;

namespace NLayerApp.BLL.Services.Interfaces
{
    public interface IAuthorizationService<T> where T : class
    {
        Task<bool> Authorization(T reg);
        void Dispose();
    }
}
