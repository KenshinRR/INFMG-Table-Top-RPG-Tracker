using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite;

[Table("Sesson Logs")]
public class SessionLogData
{
    [PrimaryKey, AutoIncrement]
    [Column("Session ID")]
    public int Session_ID
    { get; set; }

    [Column("Date")]
    public string Date
    { get; set; }

    [Column("Duration")]
    public int Duration
    { get; set; }

    [Column("Summary")]
    public string Summary
    { get; set; }
}
