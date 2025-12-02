using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Assets.Scripts.Relations
{
    [Table("CharacterItems")]
    public class CharacterItems
    {
        [PrimaryKey]
        [Column("Relation ID")]
        public int Relation_ID
        { get; set; }

        [Column("Character ID")]
        public int Character_ID
        { get; set; }

        [Column("Item ID")]
        public int Item_ID
        { get; set; }
        
        [Column("Quantity")]
        public int Quantity
        { get; set; }
    }
}
