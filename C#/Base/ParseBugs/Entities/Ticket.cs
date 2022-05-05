using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseExeptions.Entities
{
    public class Ticket
    {
        public string Key { get; set; }
        public string Summary { get; set; }
        public string Status { get; set; }
        public string Assignee { get; set; }

        private string Label;

        public string Labels {
            get => Label; set => Label = Regex.Match(value, @"TEAM_([^,]+)|MISC").Value;
        }
        public string FixVersion { get; set; }
        public string Reporter { get; set; }
        public string IssueType { get; set; }
        public string OriginalEstimate { get; set; }
        public string Priority { get; set; }
        public string Sprint { get; set; }
        public string DueDate { get; set; }
        public string Created { get; set; }
        public string QADueDate { get; set; }
    }
}
