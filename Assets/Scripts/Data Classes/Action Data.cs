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
        [Column("Action ID")]
        public int Action_ID
        { get; set; }

        [Column("Action Name")]
        public string Action_Name
        { get; set; }

        [Column("Action Description")]
        public string Action_Description
        { get; set; }
    }
}
