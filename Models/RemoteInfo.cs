using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class RemoteInfo
    {
        public string Ip { get; set; }
        public string City { get; set; }
        public CoordinateInfo Coordinate { get; set; }
        public string Country { get; set; }
        public string Agent { get; set; }
        public class CoordinateInfo
        {
            public double? Lat { get; set; }
            public double? Lng { get; set; }
        }
    }
}
