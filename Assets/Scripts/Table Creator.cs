using SQLite;
using System.Collections;
using System.Collections.Generic;
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

        //checking if table exists
        string table_name = "Campaigns";
        bool table_exists = this.DoesTableExist(db, table_name);

        // 2. Once you have defined your entity, you can automatically
        // generate tables in your database by calling CreateTable
        //db.DropTable<TestTable>(); //reset the table
        //db.CreateTable<TestTable>();

        if (table_exists)
        {
            Debug.Log("Table 'Campaign' exists!");
        }
        else
        {
            Debug.Log("Table 'Campaign' does NOT exist. Creating one...");
            db.CreateTable<CampaignData>();
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
