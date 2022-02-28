using Caminito.Models.Resort;

namespace Caminito.Services
{
    public interface IResortService
    {
        Task<ResortHotelsDto> GetResortHotelsAsync();
        Task<ResortRegimesDto> GetResortRegimesAsync();
    }
}
