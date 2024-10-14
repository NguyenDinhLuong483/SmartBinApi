
namespace SmartBin.Infrastructure.Domain.Resources.BinUnits
{
    public class UpdateBinUnitViewModel
    {
        public string FullLevel { get; set; }
        public string EngineError { get; set; }
        public DateTime LastCollected {  get; set; }
        public bool IsConnected { get; set; }
    }
}
