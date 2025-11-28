using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Assets.Scripts.Data_Classes
{
    [Table("Items")]
    public class Item_Data
    {

        [PrimaryKey, AutoIncrement]
        [Column("Item ID")]
        public int Item_ID
        { get; set; }

        [Column("Item Name")]
        public string Item_Name
        { get; set; }

        [Column("Item Description")]
        public string Item_Description
        { get; set; }
    }
}
