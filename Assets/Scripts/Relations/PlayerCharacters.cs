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
        [Column("Player ID")]
        public int Player_ID
        { get; set; }

        [Column("Character ID")]
        public int Character_ID
        { get; set; }
    }
}
