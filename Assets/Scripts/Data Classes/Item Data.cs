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
        [Column("ItemID")]
        public int Item_ID
        { get; set; }

        [Column("ItemName")]
        public string Item_Name
        { get; set; }

        [Column("ItemDescription")]
        public string Item_Description
        { get; set; }
    }
}
