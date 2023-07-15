using Microsoft.AspNetCore.Mvc;
using PJ_Login.Data;
using System.Collections.Generic;
using System.Linq;
using PJ_Login.Models;
using PJ_Login.ViewModels;

namespace PJ_Login.Controllers
{
    public class DisplayLogController : Controller
    {
        private readonly ChartDBContext _ctx;
        public DisplayLogController(ChartDBContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult DisplayLogList()
        {
            List<LogChartAnomly> abnomalLog  = _ctx.LogChartAnomlies.ToList();
            List<AbnomalLogViewmodel> abnomalLogVM = new List<AbnomalLogViewmodel>();
            foreach(var log in abnomalLog)
            {
                abnomalLogVM.Add(new AbnomalLogViewmodel
                {
                    SourceIp = log.SourceIp,
                    DestinationIp = log.DestinationIp,
                    SourcePort = log.SourcePort,
                    DistinationPort = log.DistinationPort,
                    Action = log.Action
                });
            }

            return View(abnomalLogVM);
        }
    }
}
