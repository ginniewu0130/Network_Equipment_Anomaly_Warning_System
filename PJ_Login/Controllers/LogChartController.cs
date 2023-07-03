using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PJ_Login.Data;
using PJ_Login.Models;
using PJ_Login.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PJ_Login.Controllers
{
    [Authorize]
    public class LogChartController : Controller
    {
        private readonly ChartDBContext _context;
        public LogChartController(ChartDBContext context)
        {
            _context = context;
        }
        public IActionResult bar_accept()
        {
            List<LogChart> charts = _context.LogCharts.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChart chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult bar_timeout()
        {
            List<LogChart> charts = _context.LogCharts.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChart chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult bar_ip_conn()
        {
            List<LogChart> charts = _context.LogCharts.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChart chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult bar_deny()
        {
            List<LogChart> charts = _context.LogCharts.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChart chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult bar_client_rst()
        {
            List<LogChart> charts = _context.LogCharts.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChart chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult bar_close()
        {
            List<LogChart> charts = _context.LogCharts.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChart chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult bar_server_rst()
        {
            List<LogChart> charts = _context.LogCharts.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChart chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult line_server_rst_anomlies()
        {
            List<LogChartAnomly> charts = _context.LogChartAnomlies.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChartAnomly chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult line_close_anomlies()
        {
            List<LogChartAnomly> charts = _context.LogChartAnomlies.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChartAnomly chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult line_client_rst_anomlies()
        {
            List<LogChartAnomly> charts = _context.LogChartAnomlies.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChartAnomly chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult line_deny_anomlies()
        {
            List<LogChartAnomly> charts = _context.LogChartAnomlies.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChartAnomly chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult line_ip_conn_anomlies()
        {
            List<LogChartAnomly> charts = _context.LogChartAnomlies.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChartAnomly chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult line_timeout_anomlies()
        {
            List<LogChartAnomly> charts = _context.LogChartAnomlies.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChartAnomly chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
        public IActionResult line_accept_anomlies()
        {
            List<LogChartAnomly> charts = _context.LogChartAnomlies.ToList();
            List<LogDBViewModel> bars = new List<LogDBViewModel>();
            foreach (LogChartAnomly chart in charts)
            {
                bars.Add(new LogDBViewModel
                {
                    x = chart.SourceIp,
                    y = chart.DestinationIp,
                    condition = chart.Action

                });
            }
            return View(bars);
        }
    }
}