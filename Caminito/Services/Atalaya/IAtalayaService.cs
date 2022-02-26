
using Caminito.Atalaya;

namespace Caminito.Services
{
    public interface IAtalayaService
    {
        Task<AtalayaHotelsDto> GetAtalayaHotelsAsync();
        Task<AtalayaRoomsDto> GetAtalayaRoomsAsync();
        Task<AtalayaMealPlansDto> GetAtalayaRegimesAsync();
    }
}
