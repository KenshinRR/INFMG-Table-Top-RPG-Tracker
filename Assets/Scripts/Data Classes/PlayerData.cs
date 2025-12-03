using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Assets.Scripts.Data_Classes
{
    [Table("Players")]
    public class PlayerData
    {
        [PrimaryKey, AutoIncrement]
        [Column("PlayerID")]
        public int Player_ID
        { get; set; }

        [Column("PlayerName")]
        public string Player_Name
        { get; set; }
    }
}
