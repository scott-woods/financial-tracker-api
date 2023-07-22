using FinancialTrackerApi.Models.DatabaseModels;

namespace FinancialTrackerApi.Models.DTOs
{
    /// <summary>
    /// Asset DTO
    /// </summary>
    public class AssetDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// asset value
        /// </summary>
        public float Value { get; set; }
        /// <summary>
        /// date asset was added
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// last updated date
        /// </summary>
        public DateTime DateLastUpdated { get; set; }
        /// <summary>
        /// true if this is a liquid asset
        /// </summary>
        public bool IsLiquid { get; set; }
    }
}
