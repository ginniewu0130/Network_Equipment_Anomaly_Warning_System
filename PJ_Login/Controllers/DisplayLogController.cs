using Microsoft.AspNetCore.Mvc;
using PJ_Login.Data;
using System.Collections.Generic;
using System.Linq;
using PJ_Login.Models;
using PJ_Login.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using PJ_Login.Hubs;
using System.Threading.Tasks;

namespace PJ_Login.Controllers
{
    [Authorize]
    public class DisplayLogController : Controller
    {
        private readonly ChartDBContext _ctx;
        private readonly IHubContext<LogHub> _hubContext; // 注入LogHub的上下文
        public DisplayLogController(ChartDBContext ctx, IHubContext<LogHub> hubContext)
        {
            _ctx = ctx;
            _hubContext = hubContext;
        }
        
        //這個請先忽略
        public async Task<IActionResult> DisplayLogList()
        {
            List<LogChartAnomly> abnomalLog  =await _ctx.LogChartAnomlies.ToListAsync();
            var abnomalLogVM = abnomalLog.Select(log => new AbnomalLogViewmodel
            {
                SourceIp = log.SourceIp,
                DestinationIp = log.DestinationIp,
                SourcePort = log.SourcePort,
                DistinationPort = log.DistinationPort,
                Action = log.Action,
                Level = log.Level,
                id = log.id,
                Anomly = log.Anomly,
                Date = log.Date,
                Time = log.Time
            }).ToList();

            return View(abnomalLogVM);
        }
        [HttpPost]
        public async Task<IActionResult> AddLog(LogChartAnomly log)
        {
            // 發送更新通知給前端
            await _hubContext.Clients.All.SendAsync("ReceiveLogUpdate");

            return RedirectToAction("DisplayLogList2");
        }
        public async Task<IActionResult> DisplayLogList2()
        {
            List<LogChartAnomly> abnomalLog =await _ctx.LogChartAnomlies.ToListAsync();
            var abnomalLogVM = abnomalLog.Select(log => new AbnomalLogViewmodel
            {
                SourceIp = log.SourceIp,
                DestinationIp = log.DestinationIp,
                SourcePort = log.SourcePort,
                DistinationPort = log.DistinationPort,
                Action = log.Action,
                Level = log.Level,
                id = log.id,
                Anomly = log.Anomly,
                Date = log.Date,
                Time = log.Time
            }).ToList();

            return View(abnomalLogVM);
        }
        public IActionResult Details(int id)
        {
            var logDetails = _ctx.LogChartAnomlies.FirstOrDefault(x => x.id == id);

            if (logDetails == null)
            {
                return NotFound();
            }

            var logViewModel = new AbnomalLogViewmodel
            {
                SourceIp = logDetails.SourceIp,
                DestinationIp = logDetails.DestinationIp,
                SourcePort = logDetails.SourcePort,
                DistinationPort = logDetails.DistinationPort,
                Action = logDetails.Action,
                Level = logDetails.Level,
                id = logDetails.id,
                Anomly = logDetails.Anomly,
                Date = logDetails.Date,
                Time = logDetails.Time
            };

            return View(logViewModel);
        }
        public IActionResult DisplayLogListData()
        {
            var abnomalLog = _ctx.LogChartAnomlies.ToList();
            var abnomalLogVM = abnomalLog.Select(log => new AbnomalLogViewmodel
            {
                SourceIp = log.SourceIp,
                DestinationIp = log.DestinationIp,
                SourcePort = log.SourcePort,
                DistinationPort = log.DistinationPort,
                Action = log.Action,
                Level = log.Level,
                id = log.id,
                Anomly = log.Anomly,
                Date = log.Date,
                Time = log.Time
            }).OrderByDescending(log => log.id).ToList();

            return PartialView("_LogTablePartial", abnomalLogVM);
            //return Json(abnomalLogVM);
        }

        public IActionResult ListIndex()
        {
            return View();
        }
    }
}
