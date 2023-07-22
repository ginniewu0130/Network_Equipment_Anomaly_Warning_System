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
using System.Web;

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
        //javascript display log
        public async Task<IActionResult> DisplayLogList()
        {
            List<LogAnomly> abnomalLog  =await _ctx.LogAnomlies.ToListAsync();
            var abnomalLogVM = abnomalLog.Select(log => new AbnomalLogViewmodel
            {
                id = log.id,
                Month = log.Month,
                Date = log.Date,
                Time = log.Time,
                Device = log.Device,
                Date2 = log.Date2,
                Time2 = log.Time2,
                DevName = log.DevName,
                DevId = log.DevId,
                EventTime = log.EventTime,
                TimeZone = log.TimeZone,
                LogId = log.LogId,
                Type = log.Type,
                Subtype = log.Subtype,
                EventType = log.EventType,
                Level = log.Level,
                VirtualDomain = log.VirtualDomain,
                Severity = log.Severity,
                SrcIp = log.SrcIp,
                SrcPort = log.SrcPort,
                SrcInterface = log.SrcInterface,
                SrcInterfaceRole = log.SrcInterfaceRole,
                DstIp = log.DstIp,
                DstPort = log.DstPort,
                DstInterface = log.DstInterface,
                DstInterfaceRole = log.DstInterfaceRole,
                SrcCountry = log.SrcCountry,
                DstCountry = log.DstCountry,
                SessionId = log.SessionId,
                Trandisp = log.Trandisp,
                ApplicationCategory = log.ApplicationCategory,
                ApplicationList = log.ApplicationList,
                Duration = log.Duration,
                SentByte = log.SentByte,
                RecoveredByte = log.RecoveredByte,
                SentPkt = log.SentPkt,
                RecoveredPkt = log.RecoveredPkt,
                Direction = log.Direction,
                Action = log.Action,
                AttackId = log.AttackId,
                Profile = log.Profile,
                TransactionId = log.TransactionId,
                QueryName = log.QueryName,
                QueryType = log.QueryType,
                QueryTypeValue = log.QueryTypeValue,
                QueryClass = log.QueryClass,
                Error = log.Error,
                ResponseCode = log.ResponseCode,
                Reference = log.Reference,
                Incidentserialno = log.Incidentserialno,
                Message = log.Message,
                CoreRuleAction = log.CoreRuleAction,
                CoreRuleLevel = log.CoreRuleLevel,
                LogDescription = log.LogDescription,
                Anomaly = log.Anomaly
            }).ToList();

            return View(abnomalLogVM);
        }
        // 發送更新通知給前端
        private async Task SendLogUpdateToClients()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveLogUpdate");
        }

        [HttpPost]
        public async Task<IActionResult> AddLog(LogAnomly log)
        {
            await SendLogUpdateToClients();
            return RedirectToAction("DisplayLogList2");
        }
        public async Task<IActionResult> DisplayLogList2()
        {
            var abnomalLogVM = await GetAbnomalLogVM();
            return View(abnomalLogVM);
        }
        public IActionResult Details(int id)
        {
            var logDetails = _ctx.LogAnomlies.FirstOrDefault(x => x.id == id);

            if (logDetails == null)
            {
                return NotFound();
            }

            var logViewModel = new AbnomalLogViewmodel
            {
                id = logDetails.id,
                Month = logDetails.Month,
                Date = logDetails.Date,
                Time = logDetails.Time,
                Device = logDetails.Device,
                Date2 = logDetails.Date2,
                Time2 = logDetails.Time2,
                DevName = logDetails.DevName,
                DevId = logDetails.DevId,
                EventTime = logDetails.EventTime,
                TimeZone = logDetails.TimeZone,
                LogId = logDetails.LogId,
                Type = logDetails.Type,
                Subtype = logDetails.Subtype,
                EventType = logDetails.EventType,
                Level = logDetails.Level,
                VirtualDomain = logDetails.VirtualDomain,
                Severity = logDetails.Severity,
                SrcIp = logDetails.SrcIp,
                SrcPort = logDetails.SrcPort,
                SrcInterface = logDetails.SrcInterface,
                SrcInterfaceRole = logDetails.SrcInterfaceRole,
                DstIp = logDetails.DstIp,
                DstPort = logDetails.DstPort,
                DstInterface = logDetails.DstInterface,
                DstInterfaceRole = logDetails.DstInterfaceRole,
                SrcCountry = logDetails.SrcCountry,
                DstCountry = logDetails.DstCountry,
                SessionId = logDetails.SessionId,
                Trandisp = logDetails.Trandisp,
                ApplicationCategory = logDetails.ApplicationCategory,
                ApplicationList = logDetails.ApplicationList,
                Duration = logDetails.Duration,
                SentByte = logDetails.SentByte,
                RecoveredByte = logDetails.RecoveredByte,
                SentPkt = logDetails.SentPkt,
                RecoveredPkt = logDetails.RecoveredPkt,
                Direction = logDetails.Direction,
                Action = logDetails.Action,
                AttackId = logDetails.AttackId,
                Profile = logDetails.Profile,
                TransactionId = logDetails.TransactionId,
                QueryName = logDetails.QueryName,
                QueryType = logDetails.QueryType,
                QueryTypeValue = logDetails.QueryTypeValue,
                QueryClass = logDetails.QueryClass,
                Error = logDetails.Error,
                ResponseCode = logDetails.ResponseCode,
                Reference = logDetails.Reference,
                Incidentserialno = logDetails.Incidentserialno,
                Message = logDetails.Message,
                CoreRuleAction = logDetails.CoreRuleAction,
                CoreRuleLevel = logDetails.CoreRuleLevel,
                LogDescription = logDetails.LogDescription,
                Anomaly = logDetails.Anomaly
            };

            return View(logViewModel);
        }
        public async Task<IActionResult> DisplayLogListData()
        {
            var abnomalLogVM = await GetAbnomalLogVM();
            return PartialView("_LogTablePartial", abnomalLogVM);
        }
        private async Task<List<AbnomalLogViewmodel>> GetAbnomalLogVM()
        {
            var abnomalLog = await _ctx.LogAnomlies.ToListAsync();
            return abnomalLog.Select(log => new AbnomalLogViewmodel
            {
                id = log.id,
                Month = log.Month,
                Date = log.Date,
                Time = log.Time,
                Device = log.Device,
                Date2 = log.Date2,
                Time2 = log.Time2,
                DevName = log.DevName,
                DevId = log.DevId,
                EventTime = log.EventTime,
                TimeZone = log.TimeZone,
                LogId = log.LogId,
                Type = log.Type,
                Subtype = log.Subtype,
                EventType = log.EventType,
                Level = log.Level,
                VirtualDomain = log.VirtualDomain,
                Severity = log.Severity,
                SrcIp = log.SrcIp,
                SrcPort = log.SrcPort,
                SrcInterface = log.SrcInterface,
                SrcInterfaceRole = log.SrcInterfaceRole,
                DstIp = log.DstIp,
                DstPort = log.DstPort,
                DstInterface = log.DstInterface,
                DstInterfaceRole = log.DstInterfaceRole,
                SrcCountry = log.SrcCountry,
                DstCountry = log.DstCountry,
                SessionId = log.SessionId,
                Trandisp = log.Trandisp,
                ApplicationCategory = log.ApplicationCategory,
                ApplicationList = log.ApplicationList,
                Duration = log.Duration,
                SentByte = log.SentByte,
                RecoveredByte = log.RecoveredByte,
                SentPkt = log.SentPkt,
                RecoveredPkt = log.RecoveredPkt,
                Direction = log.Direction,
                Action = log.Action,
                AttackId = log.AttackId,
                Profile = log.Profile,
                TransactionId = log.TransactionId,
                QueryName = log.QueryName,
                QueryType = log.QueryType,
                QueryTypeValue = log.QueryTypeValue,
                QueryClass = log.QueryClass,
                Error = log.Error,
                ResponseCode = log.ResponseCode,
                Reference = log.Reference,
                Incidentserialno = log.Incidentserialno,
                Message = log.Message,
                CoreRuleAction = log.CoreRuleAction,
                CoreRuleLevel = log.CoreRuleLevel,
                LogDescription = log.LogDescription,
                Anomaly = log.Anomaly
            }).OrderByDescending(log => log.id).ToList();
        }

            //異常檢測入口網頁
        public IActionResult ListIndex()
        {
            return View();
        }

        //new log history
        public async Task<IActionResult> LogHistory()
        {
            List<LogAnomly> logHistory = await _ctx.LogAnomlies.ToListAsync();
            var abnomalLogVM = logHistory.Select(log => new AbnomalLogViewmodel
            {
                id = log.id,
                Month = log.Month,
                Date = log.Date,
                Time = log.Time,
                Device = log.Device,
                Date2 = log.Date2,
                Time2 = log.Time2,
                DevName = log.DevName,
                DevId = log.DevId,
                EventTime = log.EventTime,
                TimeZone = log.TimeZone,
                LogId = log.LogId,
                Type = log.Type,
                Subtype = log.Subtype,
                EventType = log.EventType,
                Level = log.Level,
                VirtualDomain = log.VirtualDomain,
                Severity = log.Severity,
                SrcIp = log.SrcIp,
                SrcPort = log.SrcPort,
                SrcInterface = log.SrcInterface,
                SrcInterfaceRole = log.SrcInterfaceRole,
                DstIp = log.DstIp,
                DstPort = log.DstPort,
                DstInterface = log.DstInterface,
                DstInterfaceRole = log.DstInterfaceRole,
                SrcCountry = log.SrcCountry,
                DstCountry = log.DstCountry,
                SessionId = log.SessionId,
                Trandisp = log.Trandisp,
                ApplicationCategory = log.ApplicationCategory,
                ApplicationList = log.ApplicationList,
                Duration = log.Duration,
                SentByte = log.SentByte,
                RecoveredByte = log.RecoveredByte,
                SentPkt = log.SentPkt,
                RecoveredPkt = log.RecoveredPkt,
                Direction = log.Direction,
                Action = log.Action,
                AttackId = log.AttackId,
                Profile = log.Profile,
                TransactionId = log.TransactionId,
                QueryName = log.QueryName,
                QueryType = log.QueryType,
                QueryTypeValue = log.QueryTypeValue,
                QueryClass = log.QueryClass,
                Error = log.Error,
                ResponseCode = log.ResponseCode,
                Reference = log.Reference,
                Incidentserialno = log.Incidentserialno,
                Message = log.Message,
                CoreRuleAction = log.CoreRuleAction,
                CoreRuleLevel = log.CoreRuleLevel,
                LogDescription = log.LogDescription,
                Anomaly = log.Anomaly
            }).ToList();

            return View(abnomalLogVM);
        }
    }
 

}
