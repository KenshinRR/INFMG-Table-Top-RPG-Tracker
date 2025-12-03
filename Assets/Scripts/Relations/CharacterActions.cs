using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Assets.Scripts.Relations
{
    [Table("CharacterActions")]
    public class CharacterActions
    {
        [PrimaryKey]
        [Column("RelationID")]
        public int Relation_ID
        { get; set; }

        [Column("CharacterID")]
        public int Character_ID
        { get; set; }

        [Column("ActionID")]
        public int Action_ID
        { get; set; }
    }
}
