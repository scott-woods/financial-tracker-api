using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services.Interfaces;
using Microsoft.AspNetCore.Routing.Constraints;

namespace FinancialTrackerApi.Services
{
    public class AssetService : IAssetService
    {
        private readonly ILogger<AssetService> _log;
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public AssetService(ILogger<AssetService> log, AppDbContext context, IMapper mapper)
        {
            _log = log;
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all assets by user id
        /// </summary>
        /// <returns></returns>
        public List<AssetDTO> GetAllAssets(int userId)
        {
            try
            {
                var assets = _context.Assets.Where(a => a.User.Id == userId).ToList();

                return assets.Select(_mapper.Map<Asset, AssetDTO>).ToList();
            }
            catch(Exception e)
            {
                _log.LogError(e, $"Exception occurred while retrieving Assets for User with id {userId}");
                throw;
            }
        }

        public List<AssetDTO> GetLiquidAssets(int userId)
        {
            try
            {
                var assets = _context.Assets.Where(a => a.User.Id == userId && a.IsLiquid).ToList();

                return assets.Select(_mapper.Map<Asset, AssetDTO>).ToList();
            }
            catch (Exception e)
            {
                _log.LogError(e, $"Exception occurred while retrieving Liquid Assets for User with id {userId}");
                throw;
            }
        }

        public List<AssetDTO> GetNonLiquidAssets(int userId)
        {
            try
            {
                var assets = _context.Assets.Where(a => a.User.Id == userId && !a.IsLiquid).ToList();

                return assets.Select(_mapper.Map<Asset, AssetDTO>).ToList();
            }
            catch (Exception e)
            {
                _log.LogError(e, $"Exception occurred while retrieving Non Liquid Assets for User with id {userId}");
                throw;
            }
        }

        /// <summary>
        /// Update the list of assets for a user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="assetDtos"></param>
        /// <returns></returns>
        public bool UpdateAssetList(int userId, List<AssetDTO> assetDtos)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                //map assets from request to ef objects
                var newAssets = _mapper.Map<List<AssetDTO>, List<Asset>>(assetDtos, opts =>
                {
                    opts.AfterMap((src, dest) =>
                    {
                        dest.ForEach(d => d.User = user);
                    });
                });

                //Get current assets
                var currentAssets = _context.Assets.Where(a => a.User.Id == userId).ToList();

                //loop through assets from request
                foreach (var asset in newAssets)
                {
                    var existingAsset = currentAssets.FirstOrDefault(a => a.Id == asset.Id);

                    //if asset doesn't exist yet, add it
                    if (existingAsset == null)
                    {
                        _context.Assets.Add(asset);
                    }
                    else //otherwise, update it
                    {
                        _context.Entry(existingAsset).CurrentValues.SetValues(asset);
                    }
                }

                //delete assets that currently exist but aren't in the new assets list
                var assetsToDelete = currentAssets.Where(ca => !newAssets.Where(na => na.Id == ca.Id).Any()).ToList();
                if (assetsToDelete.Any())
                {
                    _context.RemoveRange(assetsToDelete);
                }

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                _log.LogError(e, $"Exception occurred while adding Assets for User with id {userId}");
                throw;
            }
        }
    }
}
