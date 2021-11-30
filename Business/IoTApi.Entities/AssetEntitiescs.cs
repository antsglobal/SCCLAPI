using System;
using System.Collections.Generic;
using System.Text;

namespace IoTApi.Entities
{
    public class AssetEntitieseDto
    {
        public int ID { get; set; }
        public string AssetCode { get; set; }
        public string AssetDescription { get; set; }
        public int Location { get; set; }
        public int status { get; set; }
        public string action { get; set; }
    }

    public class AssetViewResultEntiriesDto
    {
        public string status { get; set; }
        public string message { get; set; }
        public IEnumerable<AssetEntitieseDto> data { get; set; }
    }

    public class AssetRegisterResultEntiriesDto
    {
        public string status { get; set; }
        public string message { get; set; }
        public int data { get; set; }
    }
}
