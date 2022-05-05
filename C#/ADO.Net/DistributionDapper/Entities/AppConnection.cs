using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace DistributionDapper.Entities
{
    public static class AppConnection
    {
        public static string ConnectionString
        {
            get => ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}
