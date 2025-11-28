using Assets.Scripts.Data_Classes;
using SQLite;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TableCreator : MonoBehaviour
{
    void Start()
    {
        // 1. Create a connection to the database.
        // The special ":memory:" in-memory database and
        // URIs like "file:///somefile" are also supported
        string file_loc = Application.persistentDataPath + "/MyDb.db";
        var db = new SQLiteConnection(file_loc);
        Debug.Log($"Database file at {file_loc}");

        this.CreateTable<CampaignData>(db);
        this.CreateTable<SessionLogData>(db);
        this.CreateTable<Log_Entry_Data>(db);
        this.CreateTable<CharacterData>(db);
        this.CreateTable<Item_Data>(db);
        this.CreateTable<Action_Data>(db);
    }

    private void CreateTable<T>(SQLiteConnection db)
    {
        //getting table name
        // Look for the [Table] attribute on the class
        var tableAttr = typeof(T).GetCustomAttribute<TableAttribute>();
        string table_name = tableAttr != null ? tableAttr.Name : typeof(T).Name;

        if (this.DoesTableExist(db, table_name))
        {
            Debug.Log($"Table {table_name} exists!");
        }
        else
        {
            Debug.Log($"Table {table_name} does NOT exist. Creating one...");
            db.CreateTable<T>();
        }
    }

    private bool DoesTableExist(SQLiteConnection db, string table_name)
    {
        bool is_exist = false;
        var table_exists = db.ExecuteScalar<int>(
            $"SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='{table_name}';"
        );

        if (table_exists > 0) is_exist = true;

        return is_exist;
    }
}
