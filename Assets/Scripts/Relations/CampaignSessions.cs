using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Relations
{
    [Table("CampaignSessions")]
    public class CampaignSessions
    {
        [Column("Campaign ID")]
        public int Campaign_ID
        { get; set; }

        [Column("Session ID")]
        public int Session_ID
        { get; set; }
    }
}
