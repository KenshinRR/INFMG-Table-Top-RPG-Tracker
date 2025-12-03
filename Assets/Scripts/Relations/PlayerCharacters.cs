using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Assets.Scripts.Relations
{
    [Table("PlayerCharacters")]
    public class PlayerCharacters
    {
        [PrimaryKey]
        [Column("RelationID")]
        public int Relation_ID
        { get; set; }

        [Column("PlayerID")]
        public int Player_ID
        { get; set; }

        [Column("CharacterID")]
        public int Character_ID
        { get; set; }
    }
}
