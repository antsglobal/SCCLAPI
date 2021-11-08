using System;
using System.Collections.Generic;
using System.Text;

namespace IoTApi.Entities
{
    public class AssetEntitiescs
    {
        public int ID { get; set; }
        public string AssetCode { get; set; }
        public string AssetDescription { get; set; }
        public int Location { get; set; }
        public int status { get; set; }
        public string action { get; set; }
    }
}
