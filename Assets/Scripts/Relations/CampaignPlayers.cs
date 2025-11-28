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
        [Column("Relation ID")]
        public int Relation_ID
        { get; set; }


        [Column("Campaign ID")]
        public int Campaign_ID
        { get; set; }

        [Column("Player ID")]
        public int Player_ID
        { get; set; }
    }
}
