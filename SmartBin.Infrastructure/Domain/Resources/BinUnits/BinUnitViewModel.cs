
namespace SmartBin.Infrastructure.Domain.Resources.BinUnits
{
    public class BinUnitViewModel
    {
        public string BinUnitId { get; set; }
        public string FullLevel { get; set; }
        public string EngineError { get; set; }
        public DateTime LastCollected { get; set; }
        public bool IsConnected { get; set; }
        public BinUnitType Type { get; set; }
        public List<CollectedHistoryViewModel> CollectedHistories { get; set; }
    }
}
