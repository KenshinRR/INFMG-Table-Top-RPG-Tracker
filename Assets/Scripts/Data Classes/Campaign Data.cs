using SQLite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Table("Campaigns")]
public class CampaignData
{
    [PrimaryKey, AutoIncrement]
    [Column("CampaignID")]
    public int Campaign_ID
    { get; set; }

    [Column("CampaignName")]
    public string Campaign_Name
    { get; set; }

    [Column("RuleSystem")]
    public string RuleSystem
    { get; set; }

}