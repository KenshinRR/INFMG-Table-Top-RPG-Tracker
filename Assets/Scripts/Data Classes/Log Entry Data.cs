using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Assets.Scripts.Data_Classes
{
    [Table("Log_Entries")]
    public class Log_Entry_Data
    {
        [PrimaryKey,AutoIncrement]
        [Column("LogID")]
        public int Log_ID
        { get; set; }

        [Column("Description0")]
        public string Desc0
        { get; set; }

        [Column("Description1")]
        public string Desc1
        { get; set; }

        [Column("Dice")]
        public int Dice
        { get; set; }

        [Column("DiceResult")]
        public int DiceResult
        { get; set; }
    }
}
