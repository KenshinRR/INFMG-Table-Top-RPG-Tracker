using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Assets.Scripts.Relations
{
    [Table("CampaignPlayers")]
    public class CampaignPlayers
    {
        [PrimaryKey]
        [Column("RelationID")]
        public int Relation_ID
        { get; set; }


        [Column("CampaignID")]
        public int Campaign_ID
        { get; set; }

        [Column("PlayerID")]
        public int Player_ID
        { get; set; }
    }
}
