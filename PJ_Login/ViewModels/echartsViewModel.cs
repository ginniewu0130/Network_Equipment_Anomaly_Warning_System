using System.ComponentModel.DataAnnotations;

namespace PJ_Login.ViewModels
{
    public class echartsViewModel
    {
        [Key]
        public int id { get; set; }
        public double? x { get; set; }
        public int? SPort { get; set; }
        public double? y { get; set; }
        public int? DPort { get; set; }
        public string Action { get; set; }
        public string Anomly { get; set; }
    }
}
