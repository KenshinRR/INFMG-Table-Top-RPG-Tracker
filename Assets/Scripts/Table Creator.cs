using Assets.Scripts.Data_Classes;
using SQLite;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TableCreator : MonoBehaviour
{
    public SQLiteConnection database = null;
    void Start()
    {
        // 1. Create a connection to the database.
        // The special ":memory:" in-memory database and
        // URIs like "file:///somefile" are also supported
        string file_loc = Application.dataPath + "/Database/MyDb.db";
        this.database = new SQLiteConnection(file_loc);
        Debug.Log($"Database file at {file_loc}");

        this.CreateTable<CampaignData>(this.database);
        this.CreateTable<SessionLogData>(this.database);
        this.CreateTable<Log_Entry_Data>(this.database);
        this.CreateTable<CharacterData>(this.database);
        this.CreateTable<Item_Data>(this.database);
        this.CreateTable<Action_Data>(this.database);
    }

    public void callAddCampaignDataEntry(string name, string ruleSystem)
    {
        this.AddCampaignDataEntry(this.database, name, ruleSystem);
    }

    public void AddCampaignDataEntry(SQLiteConnection db, string name, string ruleSystem)
    {
        db.Insert(new CampaignData
        {
            Campaign_ID = 0,
            Campaign_Name = name,
            RuleSystem = ruleSystem
        });

        Debug.Log($"Added campaign entry: {name} - {ruleSystem}");
    }
    public void callAddSessionLogDataEntry(float duration, string summary)
    {
        this.AddSessionLogDataEntry(this.database, duration, summary);
    }
    public void AddSessionLogDataEntry(SQLiteConnection db, float duration, string summary)
    {
        db.Insert(new SessionLogData
        {
            Session_ID = 0,
            Date = System.DateTime.Today.ToString(),
            Duration = duration,
            Summary = summary
        });

        Debug.Log($"Added New Session Log Entry");
    }

    public void AddCharacterDataEntry(
        string charType,
        string charName,
        string backstory,
        string alignment,
        string race,
        string charClass,
        int strength,
        int dexterity,
        int constitution,
        int intelligence,
        int charisma,
        int armorClass,
        int speed,
        int hitpoints,
        int experiencePoints,
        int level)
    {
        this.database.Insert(new CharacterData
        {
            Character_Type = charType,
            Character_Name = charName,
            Backstory = backstory,
            Alignment = alignment,
            Race = race,
            Class = charClass,
            Strength = strength,
            Dexterity = dexterity,
            Constitution = constitution,
            Intelligence = intelligence,
            Charisma = charisma,
            Armor_Class = armorClass,
            Speed = speed,
            Hitpoints = hitpoints,
            Experience_Points = experiencePoints,
            Character_Level = level
        });
        Debug.Log($"Added New Character Entry: {charName}");
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
