using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Incess_Reports
{
    public class Report
    {
        public string ID { get; set; }
        public string Date { get; set; }
        public string Start_time { get; set; }
        public string Finish_time { get; set; }
        public string User { get; set; }
        public string Report_description { get; set; }

        public Report(string id, string date, string start_time, string finish_time, string user, string report_description)
        {
            ID = id;
            Date = date;
            Start_time = start_time;
            Finish_time = finish_time;
            User = user;
            Report_description = report_description;
        }
    }
}
