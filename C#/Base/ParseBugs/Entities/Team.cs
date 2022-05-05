using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseExeptions.Entities
{
    public class Team
    {
        public string Name { get; set; }

        public int TEAM_BEAUJOLAIS { get; set; }
        public int TEAM_BORDEAUX { get; set; }
        public int TEAM_BURGUNDY { get; set; }
        public int TEAM_LOIRE { get; set; }
        public int TEAM_PROVENCE { get; set; }
        public int TEAM_RHONE { get; set; }
        public int MISC { get; set; }
        public int Total { get => MISC + TEAM_RHONE + TEAM_PROVENCE + TEAM_LOIRE + TEAM_BURGUNDY + TEAM_BORDEAUX + TEAM_BEAUJOLAIS;}
    }
}
