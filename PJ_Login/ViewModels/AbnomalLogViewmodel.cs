using PJ_Login.Models;
using System;

namespace PJ_Login.ViewModels
{
    public class AbnomalLogViewmodel
    {
        public double? SourceIp { get; set; }
        public double? DestinationIp { get; set; }
        public int? SourcePort { get; set; }
        public int? DistinationPort { get; set; }
        public string Action { get; set; }
    }
}
