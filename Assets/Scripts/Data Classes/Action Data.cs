using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Assets.Scripts.Data_Classes
{
    [Table("Actions")]
    public class Action_Data
    {
        [PrimaryKey, AutoIncrement]
        [Column("ActionID")]
        public int Action_ID
        { get; set; }

        [Column("ActionName")]
        public string Action_Name
        { get; set; }

        [Column("ActionDescription")]
        public string Action_Description
        { get; set; }
    }
}
