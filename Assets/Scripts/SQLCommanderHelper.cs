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
                $"INSERT INTO Actions (Action_Name, Action_Description) " +
                $"VALUES ('Yell', 'Causes another person to move faster');";

            database.Query<Action_Data>(query);


            Debug.Log($"Added Action entry: Yell");
        }
    }
}
