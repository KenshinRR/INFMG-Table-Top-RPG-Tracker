using SQLite;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

// The library contains simple attributes that you can use
// to control the construction of tables, ORM style
public class TestTable
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
}

public class TestSQLite : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _label;

    void Start()
    {
        // 1. Create a connection to the database.
        // The special ":memory:" in-memory database and
        // URIs like "file:///somefile" are also supported
        string file_loc = Application.persistentDataPath + "/MyDb.db";
        var db = new SQLiteConnection(file_loc);
        Debug.Log($"Database file at {file_loc}");

        //checking if table exists
        var table_exists = db.ExecuteScalar<int>(
            "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='TestTable';"
        );
        
        // 2. Once you have defined your entity, you can automatically
        // generate tables in your database by calling CreateTable
        db.DropTable<TestTable>(); //reset the table
        db.CreateTable<TestTable>();

        //if (table_exists > 0)
        //{
        //    Debug.Log("Table 'TestTable' exists!");
        //}
        //else
        //{
        //    Debug.Log("Table 'TestTable' does NOT exist. Creating one...");
        //    db.CreateTable<TestTable>();
        //}


        // 3. You can insert rows in the database using Insert
        // The Insert call fills Id, which is marked with [AutoIncremented]
        var newTestTable = new TestTable
        {
            Name = "gilzoide",
        };
        db.Insert(newTestTable);
        Debug.Log($"TestTable new ID: {newTestTable.Id}");
        // Similar methods exist for Update and Delete.

        // 4.a The most straightforward way to query for data
        // is using the Table method. This can take predicates
        // for constraining via WHERE clauses and/or adding ORDER BY clauses
        var query = db.Table<TestTable>().Where(p => p.Name.StartsWith("g"));
        foreach (TestTable player in query)
        {
            Debug.Log($"Found player named {player.Name} with ID {player.Id}");
        }

        // 4.b You can also make queries at a low-level using the Query method
        string player_query = "";
        var players = db.Query<TestTable>("SELECT * FROM TestTable WHERE Id = ?", 1);
        foreach (TestTable player in players)
        {
            Debug.Log($"TestTable with ID 1 is called {player.Name}");
            player_query += "TestTable with ID 1 is called " + player.Name;
        }

        this._label.text = player_query;

        //db.Execute("DELETE FROM TestTable;");

        // 5. You can perform low-level updates to the database using the Execute
        // method, for example for running PRAGMAs or VACUUM
        db.Execute("VACUUM");
    }
}