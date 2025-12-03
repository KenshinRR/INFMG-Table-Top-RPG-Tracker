using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite;

[Table("Session_Logs")]
public class SessionLogData
{
    [PrimaryKey, AutoIncrement]
    [Column("SessionID")]
    public int Session_ID
    { get; set; }

    [Column("Date")]
    public string Date
    { get; set; }

    [Column("Duration")]
    public float Duration
    { get; set; }

    [Column("Summary")]
    public string Summary
    { get; set; }
}
