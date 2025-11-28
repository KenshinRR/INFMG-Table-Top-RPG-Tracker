using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Assets.Scripts.Data_Classes
{
    [Table("Players")]
    public class Player_Data
    {
        [PrimaryKey, AutoIncrement]
        [Column("Player ID")]
        public int Player_ID
        { get; set; }
    }
}
