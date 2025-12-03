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
        [PrimaryKey]
        [Column("RelationID")]
        public int Relation_ID
        { get; set; }

        [Column("CampaignID")]
        public int Campaign_ID
        { get; set; }

        [Column("SessionID")]
        public int Session_ID
        { get; set; }
    }
}
