
namespace SmartBin.Infrastructure.Domain.Models.Bin
{
    public class BinUnit
    {
        public string BinUnitId { get; set; }
        public string BinId { get; set; }
        public string FullLevel { get; set; }
        public string EngineError { get; set; }
        public DateTime LastCollected { get; set; }
        public bool IsConnected { get; set; }
        public BinUnitType Type { get; set; }
        public Bin Bin {  get; set; }
        public List<CollectedHistory> CollectedHistories { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BinUnit() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BinUnit(string id, string binId, string fullLevel, string engineError, DateTime lastCollected, bool isConnected, BinUnitType type, Bin bin, List<CollectedHistory> collectedHistories)
        {
            BinUnitId = id;
            BinId = binId;
            FullLevel = fullLevel;
            EngineError = engineError;
            LastCollected = lastCollected;
            IsConnected = isConnected;
            Type = type;
            Bin = bin;
            CollectedHistories = collectedHistories;
        }
    }
}
