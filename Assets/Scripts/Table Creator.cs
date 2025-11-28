using Assets.Scripts.Data_Classes;
using SQLite;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

using Assets.Scripts.Relations;
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

        //Relations Tables
        this.CreateTable<CampaignSessions>(this.database);
        this.CreateTable<SessionLogEntries>(this.database);
        this.CreateTable<CharacterItems>(this.database);
        this.CreateTable<CharacterActions>(this.database);

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
    public void AddSessionLogDataEntry(int campaignID, float duration, string summary)
    {
        database.Insert(new SessionLogData
        {
            Date = System.DateTime.Today.ToString(),
            Duration = duration,
            Summary = summary
        });

        var lastSessionEntry = this.database.Table<SessionLogData>().OrderByDescending(x => x.Session_ID).FirstOrDefault();
        int lastSessionID = lastSessionEntry.Session_ID;

        database.Insert(new CampaignSessions
        {
            Campaign_ID = campaignID,
            Session_ID = lastSessionID
        });

        Debug.Log($"Added New Session Log Entry");
    }
    public void AddLogEntryDataEntry(int SessionID, string D0, string D1, int RolledDice, int RolledDiceResult)
    {
        this.database.Insert(new Log_Entry_Data
        {
            Desc0 = D0,
            Desc1 = D1,
            Dice = RolledDice,
            DiceResult = RolledDiceResult
        });

        var lastLogEntry = this.database.Table<Log_Entry_Data>().OrderByDescending(x => x.Log_ID).FirstOrDefault();
        int lastLogID = lastLogEntry.Log_ID;

        this.database.Insert(new SessionLogEntries
        {
            Session_ID = SessionID,
            Log_ID = lastLogID
        });

        Debug.Log($"Added New Log Entry Data");
    }

    public void AddCharacterDataEntry( //add int PlayerID, when the player class is ready
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

        /*
        var lastCharacterEntry = this.database.Table<CharacterData>().OrderByDescending(x => x.Character_ID).FirstOrDefault();
        int lastCharacterID = lastCharacterEntry.Character_ID;

        this.database.Insert(new CampaignCharacters
        {
            Campaign_ID = campaignID,
            Character_ID = lastCharacterID
        });*/

        Debug.Log($"Added New Character Entry: {charName}");
    }

    public void AddActionDataEntry(int characterID, string aName, string aDesc)
    {
        this.database.Insert(new Action_Data
        {
            Action_Name = aName,
            Action_Description = aDesc
        });

        var lastActionEntry = this.database.Table<Action_Data>().OrderByDescending(x => x.Action_ID).FirstOrDefault();
        int lastActionID = lastActionEntry.Action_ID;

        this.database.Insert (new CharacterActions
        {
            Character_ID = characterID,
            Action_ID = lastActionID
        });

        Debug.Log($"Added New Action Data Entry: {aName}");
    }

    public void AddItemDataEntry(int characterID, string iName, string iDesc, int itemQuantity)
    {
        this.database.Insert(new Item_Data
        {
            Item_Name = iName,
            Item_Description = iDesc
        });

        var lastItemEntry = this.database.Table<Item_Data>().OrderByDescending(x => x.Item_ID).FirstOrDefault();
        int lastItemID = lastItemEntry.Item_ID;

        this.database.Insert(new CharacterItems
        {
            Character_ID = characterID,
            Item_ID = lastItemID,
            Quantity = itemQuantity
        });

        Debug.Log($"Added New Action Data Entry: {iName}");
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
