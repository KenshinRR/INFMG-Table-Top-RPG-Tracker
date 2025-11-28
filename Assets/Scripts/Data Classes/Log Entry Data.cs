using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Assets.Scripts.Data_Classes
{
    [Table("Log Entries")]
    public class Log_Entry_Data
    {
        [PrimaryKey, AutoIncrement]
        [Column("Log ID")]
        public int Log_ID
        { get; set; }

        [Column("Description 0")]
        public string Desc0
        { get; set; }

        [Column("Description 1")]
        public string Desc1
        { get; set; }

        [Column("Dice")]
        public int Dice
        { get; set; }

        [Column("Dice Result")]
        public int DiceResult
        { get; set; }
    }
}
