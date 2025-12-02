using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Assets.Scripts.Data_Classes
{
    [Table("Player")]
    public class PlayerData
    {
        [PrimaryKey]
        [Column("Player ID")]
        public int Player_ID
        { get; set; }

        [Column("Player Name")]
        public string Player_Name
        { get; set; }
    }
}
