using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Assets.Scripts.Relations
{
    [Table("SessionLogEntries")]
    public class SessionLogEntries
    {
        [PrimaryKey]
        [Column("Relation ID")]
        public int Relation_ID
        { get; set; }

        [Column("Session ID")]
        public int Session_ID
        { get; set; }

        [Column("Log ID")]
        public int Log_ID
        { get; set; }
    }
}
