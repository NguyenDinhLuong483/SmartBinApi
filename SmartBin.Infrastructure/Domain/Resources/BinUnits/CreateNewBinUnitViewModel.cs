
namespace SmartBin.Infrastructure.Domain.Resources.BinUnits
{
    public class CreateNewBinUnitViewModel
    {
        public string BinUnitId { get; set; }
        public string BinId {  get; set; }
        public string FullLevel { get; set; }
        public string EngineError { get; set; }
        public bool IsConnected { get; set; }
        public BinUnitType Type { get; set; }

        public CreateNewBinUnitViewModel(string id, string binId, BinUnitType type)
        {
            BinUnitId = id;
            BinId = binId;
            Type = type;
            FullLevel = "";
            EngineError = "";
            IsConnected = true;
        }
    }
}
