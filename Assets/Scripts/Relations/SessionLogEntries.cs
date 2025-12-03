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
        [Column("RelationID")]
        public int Relation_ID
        { get; set; }

        [Column("SessionID")]
        public int Session_ID
        { get; set; }

        [Column("LogID")]
        public int Log_ID
        { get; set; }
    }
}
