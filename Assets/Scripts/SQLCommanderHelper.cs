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
            var results = database.Query<Log_Entry_Data>(
                "SELECT \"Log ID\", \"Description 0\" FROM 'Log Entries'"
                );

            string to_print = "Sessions:\n";

            foreach (Log_Entry_Data logData in results)
            {
                to_print +=
                    "ID: " + logData.Log_ID
                    + " // Desc 0: " + logData.Desc0
                    + "\n"
                    ;
            }

            Debug.Log(to_print);
        }
    }
}
