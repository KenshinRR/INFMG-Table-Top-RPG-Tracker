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
        [Column("Character ID")]
        public int Character_ID
        { get; set; }

        [Column("Character Type")]
        public string Character_Type
        { get; set; }

        [Column("Character Name")]
        public string Character_Name
        { get; set; }

        [Column("Backstory")]
        public string Backstory
        { get; set; }

        [Column("Alignment")]
        public string Alignment
        { get; set; }

        [Column("Race")]
        public string Race
        { get; set; }

        [Column("Class")]
        public string Class
        { get; set; }

        [Column("Strength")]
        public int Strength
        { get; set; }

        [Column("Dexterity")]
        public int Dexterity
        { get; set; }

        [Column("Constitution")]
        public int Constitution
        { get; set; }

        [Column("Intelligence")]
        public int Intelligence
        { get; set; }

        [Column("Charisma")]
        public int Charisma
        { get; set; }

        [Column("Armor Class")]
        public int Armor_Class
        { get; set; }

        [Column("Speed")]
        public int Speed
        { get; set; }

        [Column("Hitpoints")]
        public int Hitpoints
        { get; set; }

        [Column("Experience Points")]
        public int Experience_Points
        { get; set; }

        [Column("Character Level")]
        public int Character_Level
        { get; set; }
    }
}
