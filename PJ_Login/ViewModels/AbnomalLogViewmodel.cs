using PJ_Login.Models;
using System;
using System.ComponentModel;

namespace PJ_Login.ViewModels
{
    public class AbnomalLogViewmodel
    {
        public double? SourceIp { get; set; }
        public double? DestinationIp { get; set; }
        public int? SourcePort { get; set; }
        [DisplayName("DestinationPort")]
        public int? DistinationPort { get; set; }
        public string Action { get; set; }
        public int id { get; set; }
        public string Level { get; set; }
        [DisplayName("Anomaly")]
        public string Anomly { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
