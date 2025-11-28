using SQLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Table("Campaigns")]
public class CampaignData
{
    [PrimaryKey, AutoIncrement]
    [Column("Campaign ID")]
    public int Campaign_ID
    { get; set; }

    [Column("Campaign Name")]
    public string Campaign_Name
    { get; set; }

    [Column("Rule System")]
    public string RuleSystem
    { get; set; }

}