﻿
namespace SmartBin.Infrastructure.Domain.Resources.Bins
{
    public class UpdateBinViewModel
    {
        public double Longtitude { get; set; }
        public double Latitude { get; set; }
        public string Address { get; set; }
        public double Battery { get; set; }
        public bool IsConnected { get; set; }
    }
}