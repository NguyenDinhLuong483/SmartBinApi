
namespace SmartBin.Infrastructure.Domain.Resources.Bins
{
    [DataContract]
    public class AddNewBinViewModel
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public double Longtitude { get; set; }
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        [JsonIgnore]
        public double Battery { get; set; }
        [DataMember]
        [JsonIgnore]
        public bool IsConnected { get; set; }
        [DataMember]
        [JsonIgnore]
        public List<CreateNewBinUnitViewModel> BinUnits { get; set; } 

        public AddNewBinViewModel(string id, double longtitude, double latitude, string address)
        {
            Id = id;
            Longtitude = longtitude;
            Latitude = latitude;
            Address = address;
            Battery = 100;
            IsConnected = true;
            BinUnits = new List<CreateNewBinUnitViewModel>();
        }
    }
}
