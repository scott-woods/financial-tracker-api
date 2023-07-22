using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    public interface IAssetService
    {
        public List<AssetDTO> GetAllAssets(int userId);

        public List<AssetDTO> GetLiquidAssets(int userId);

        public List<AssetDTO> GetNonLiquidAssets(int userId);

        public bool UpdateAssetList(int userId, List<AssetDTO> assets);
    }
}
