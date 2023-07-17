using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PJ_Login.Models
{
    public partial class LogChartAnomly
    {
        [Key]
        public int id { get; set; }
        public double? SourceIp { get; set; }
        public double? DestinationIp { get; set; }
        public int? SourcePort { get; set; }
        public int? DistinationPort { get; set; }
        public string Action { get; set; }
    }
}
