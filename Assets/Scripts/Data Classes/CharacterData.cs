using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data_Classes
{
    [Table("Characters")]
    public class CharacterData
    {
        [PrimaryKey, AutoIncrement]
        [Column("CharacterID")]
        public int Character_ID
        { get; set; }

        [Column("CharacterType")]
        public string Character_Type
        { get; set; }

        [Column("CharacterName")]
        public string Character_Name
        { get; set; }

        [Column("Level")]
        public int Level
        { get; set; }

        [Column("Strength")]
        public int Strength
        { get; set; }

        [Column("Vitality")]
        public int Vitality
        { get; set; }

        [Column("Speed")]
        public int Speed
        { get; set; }

        [Column("Defence")]
        public int Defence
        { get; set; }
    }
}
