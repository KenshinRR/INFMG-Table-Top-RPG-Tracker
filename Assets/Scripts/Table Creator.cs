using Assets.Scripts.Data_Classes;
using Assets.Scripts.Relations;
using SQLite;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        this.CreateTable<PlayerData>(this.database);

        //Relations Tables
        this.CreateTable<CampaignSessions>(this.database);
        this.CreateTable<CampaignPlayers>(this.database);
        this.CreateTable<SessionLogEntries>(this.database);
        this.CreateTable<CharacterItems>(this.database);
        this.CreateTable<CharacterActions>(this.database);
        this.CreateTable<PlayerCharacters>(this.database);

    }
    public void callAddCampaignDataEntry(string name, string ruleSystem)
    {
        this.AddCampaignDataEntry(this.database, name, ruleSystem);
    }
    public void AddCampaignDataEntry(SQLiteConnection db, string name, string ruleSystem)
    {
        string query =
            $"INSERT INTO Campaigns (CampaignName, RuleSystem) " +
            $"VALUES ('{name}', '{ruleSystem}');";

        db.Query<CampaignData>(query);


        Debug.Log($"Added campaign entry: {name} - {ruleSystem}");
    }
    public void AddSessionLogDataEntry(int campaignID, float duration, string summary)
    {
        // Sanitize string values to avoid SQL errors if they contain single quotes
        string safeDate = System.DateTime.Today.ToString().Replace("'", "''");
        string safeSummary = summary.Replace("'", "''");

        string insertSessionQuery =
            $"INSERT INTO Session_Logs (Date, Duration, Summary) " +
            $"VALUES ('{safeDate}', '{duration}', '{safeSummary}');";

        database.Query<SessionLogData>(insertSessionQuery);

        string getLastSessionQuery =
            "SELECT * FROM Session_Logs ORDER BY SessionID DESC LIMIT 1;";

        var lastSessionEntry = database.Query<SessionLogData>(getLastSessionQuery).FirstOrDefault();

        int lastSessionID = lastSessionEntry.Session_ID;

        string insertCampaignSessionQuery =
            $"INSERT INTO CampaignSessions (CampaignID, SessionID) " +
            $"VALUES ({campaignID}, {lastSessionID});";

        database.Query<CampaignSessions>(insertCampaignSessionQuery);

        Debug.Log("Added New Session Log Entry");

    }
    public void AddLogEntryDataEntry(int SessionID, string D0, string D1, int RolledDice, int RolledDiceResult)
    {
        // Escape only string inputs
        string safeD0 = D0.Replace("'", "''");
        string safeD1 = D1.Replace("'", "''");

        // 1. Insert into Log_Entry_Data
        string insertLogQuery =
            $"INSERT INTO Log_Entries (Description0, Description1, Dice, DiceResult) " +
            $"VALUES ('{safeD0}', '{safeD1}', {RolledDice}, {RolledDiceResult});";

        this.database.Query<Log_Entry_Data>(insertLogQuery);

        // 2. Retrieve last inserted Log_ID
        string getLastLogQuery =
            "SELECT * FROM Log_Entries ORDER BY LogID DESC LIMIT 1;";

        var lastLogEntry = this.database.Query<Log_Entry_Data>(getLastLogQuery).FirstOrDefault();
        int lastLogID = lastLogEntry.Log_ID;

        // 3. Insert into SessionLogEntries
        string insertSessionLogEntry =
            $"INSERT INTO SessionLogEntries (SessionID, LogID) " +
            $"VALUES ({SessionID}, {lastLogID});";

        this.database.Query<SessionLogEntries>(insertSessionLogEntry);

        Debug.Log("Added New Log Entry Data");
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
        // Escape all string inputs to prevent SQL errors from single quotes
        string safeType = charType.Replace("'", "''");
        string safeName = charName.Replace("'", "''");
        string safeBackstory = backstory.Replace("'", "''");
        string safeAlignment = alignment.Replace("'", "''");
        string safeRace = race.Replace("'", "''");
        string safeClass = charClass.Replace("'", "''");

        // 1. Insert CharacterData entry
        string insertCharacterQuery =
            "INSERT INTO Characters (" +
            "Character_Type, Character_Name, Backstory, Alignment, Race, Class, " +
            "Strength, Dexterity, Constitution, Intelligence, Charisma, " +
            "Armor_Class, Speed, Hitpoints, ExperiencePoints, CharacterLevel" +
            ") VALUES (" +
            $"'{safeType}', '{safeName}', '{safeBackstory}', '{safeAlignment}', '{safeRace}', '{safeClass}', " +
            $"{strength}, {dexterity}, {constitution}, {intelligence}, {charisma}, " +
            $"{armorClass}, {speed}, {hitpoints}, {experiencePoints}, {level}" +
            ");";

        this.database.Query<CharacterData>(insertCharacterQuery);

        /*
        // 2. Retrieve last inserted Character_ID
        string getLastCharacterQuery =
            "SELECT * FROM Characters ORDER BY CharacterID DESC LIMIT 1;";

        var lastCharacterEntry = this.database.Query<CharacterData>(getLastCharacterQuery).FirstOrDefault();
        int lastCharacterID = lastCharacterEntry.Character_ID;

        // 3. Insert into CampaignCharacters
        string insertCampaignCharacterQuery =
            $"INSERT INTO CampaignCharacters (CampaignID, CharacterID) " +
            $"VALUES ({campaignID}, {lastCharacterID});";

        this.database.Query<CampaignCharacters>(insertCampaignCharacterQuery);
        */

        Debug.Log($"Added New Character Entry: {charName}");
    }
    public void AddActionDataEntry(int characterID, string aName, string aDesc)
    {
        // Escape strings
        string safeName = aName.Replace("'", "''");
        string safeDesc = aDesc.Replace("'", "''");

        // 1. Insert into Action_Data
        string insertActionQuery =
            $"INSERT INTO Actions (ActionName, ActionDescription) " +
            $"VALUES ('{safeName}', '{safeDesc}');";

        this.database.Query<Action_Data>(insertActionQuery);

        // 2. Get last Action_ID
        string getLastActionQuery =
            "SELECT * FROM Actions ORDER BY ActionID DESC LIMIT 1;";

        var lastActionEntry = this.database.Query<Action_Data>(getLastActionQuery).FirstOrDefault();
        int lastActionID = lastActionEntry.Action_ID;

        // 3. Insert into CharacterActions
        string insertCharacterActionQuery =
            $"INSERT INTO CharacterActions (CharacterID, ActionID) " +
            $"VALUES ({characterID}, {lastActionID});";

        this.database.Query<CharacterActions>(insertCharacterActionQuery);

        Debug.Log($"Added New Action Data Entry: {aName}");
    }

    public void AddItemDataEntry(int characterID, string iName, string iDesc, int itemQuantity)
    {
        // Escape strings
        string safeName = iName.Replace("'", "''");
        string safeDesc = iDesc.Replace("'", "''");

        // 1. Insert into Item_Data
        string insertItemQuery =
            $"INSERT INTO Items (ItemName, ItemDescription) " +
            $"VALUES ('{safeName}', '{safeDesc}');";

        this.database.Query<Item_Data>(insertItemQuery);

        // 2. Get last Item_ID
        string getLastItemQuery =
            "SELECT * FROM Items ORDER BY ItemID DESC LIMIT 1;";

        var lastItemEntry = this.database.Query<Item_Data>(getLastItemQuery).FirstOrDefault();
        int lastItemID = lastItemEntry.Item_ID;

        // 3. Insert into CharacterItems
        string insertCharacterItemQuery =
            $"INSERT INTO CharacterItems (CharacterID, ItemID, Quantity) " +
            $"VALUES ({characterID}, {lastItemID}, {itemQuantity});";

        this.database.Query<CharacterItems>(insertCharacterItemQuery);

        Debug.Log($"Added New Item Data Entry: {iName}");
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
