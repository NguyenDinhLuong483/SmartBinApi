
namespace SmartBin.Infrastructure.Services.BinUnits
{
    public interface IBinUnitService
    {
        public Task<BinUnitViewModel> GetBinUnitById(string id);
        public Task<bool> UpdateBinUnit(string id, UpdateBinUnitViewModel viewModel);
    }
}
