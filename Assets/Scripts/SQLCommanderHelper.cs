using Assets.Scripts.Data_Classes;
using Assets.Scripts.Relations;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using static UnityEditor.Progress;

[Tooltip("Use this script to run custom SQL script on start")]
public class SQLCommanderHelper : MonoBehaviour
{
    private SQLiteConnection database;
    [SerializeField] private bool _do_it = false;

    void Start()
    {
        string file_loc = Application.dataPath + "/Database/MyDb.db";
        this.database = new SQLiteConnection(file_loc);
    }

    private void Update()
    {
        if (_do_it)
        {
            _do_it = false;

            string query =
                $"INSERT INTO CampaignPlayers (CampaignID, PlayerID) " +
                $"VALUES ('0', '1');";

            database.Query<CampaignPlayers>(query);


            Debug.Log($"Added new entry");
        }
    }
}
