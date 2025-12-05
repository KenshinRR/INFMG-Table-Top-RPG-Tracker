using SQLite;
using UnityEngine;

[Tooltip("Use this script to run custom SQL script on start")]
public class SQLCommanderHelper : MonoBehaviour
{
    private SQLiteConnection database;
    [SerializeField] private bool _do_it = false;

    void Start()
    {
        string file_loc = Application.persistentDataPath + "/Database/MyDb.db";
        this.database = new SQLiteConnection(file_loc);
    }

    private void Update()
    {
        if (_do_it)
        {
            _do_it = false;

            //insert
            //string query =
            //    $"INSERT INTO Characters (CharacterName) " +
            //    $"VALUES ('Jorge');";

            //database.Query<CharacterData>(query);


            //Debug.Log($"Added new entry");

            //string query =
            //    "SELECT C.CampaignID, CampaignName\r\n" +
            //    "FROM Campaigns C\r\n" +
            //    "INNER JOIN CampaignSessions CS\r\nON C.CampaignID = CS.CampaignID\r\n" +
            //    "INNER JOIN CampaignPlayers CaP\r\nON CS.CampaignID = CaP.CampaignID\r\n" +
            //    "INNER JOIN Players P\r\nON CaP.PlayerID = P.PlayerID";

            //database.Query<CampaignData>(query);

            InsertInitialData();
            Debug.Log($"Added new entry");
        }
    }

    private void InsertInitialData()
    {
        database.Execute("INSERT INTO Actions (ActionID, ActionName, ActionDescription)\r\nVALUES (0, 'Yell', 'Causes another person to move faster');\r\n");
        database.Execute("INSERT INTO CampaignPlayers (RelationID, CampaignID, PlayerID)\r\nVALUES (0, 0, 0);\r\n");
        database.Execute("INSERT INTO CampaignSessions (RelationID, CampaignID, SessionID)\r\nVALUES (0, 0, 0);");
        database.Execute("INSERT INTO Campaigns (CampaignID, CampaignName, RuleSystem)\r\nVALUES (0, 'The Beginning of the End', 'Dungeons & Dragons 5e');");
        database.Execute("INSERT INTO CharacterActions (RelationID, CharacterID, ActionID)\r\nVALUES (0, 0, 0);");
        database.Execute("INSERT INTO CharacterItems (RelationID, CharacterID, ItemID, Quantity)\r\nVALUES (0, 0, 0, 2);");
        database.Execute("INSERT INTO Characters (CharacterID, CharacterType, CharacterName, Level, Strength, Vitality, Speed, Defence)\r\nVALUES (0, 'NPC', 'Freddy', 1, 10, 12, 9, 11);");
        database.Execute("INSERT INTO Items (ItemID, ItemName, ItemDescription)\r\nVALUES (0, 'Coin', 'Used to buy stuff');");
        database.Execute("INSERT INTO Log_Entries (LogID, Description0, Description1, Dice, DiceResult)\r\nVALUES (0, 'The beginning', 'The adventure begins in a tavern', 0, 0);");
        database.Execute("INSERT INTO PlayerCharacters (RelationID, PlayerID, CharacterID)\r\nVALUES (0, 0, 0);");
        database.Execute("INSERT INTO Players (PlayerID, PlayerName)\r\nVALUES (0, 'Jay');");
        database.Execute("INSERT INTO SessionLogEntries (RelationID, SessionID, LogID)\r\nVALUES (0, 0, 0);\r\n");
        database.Execute("INSERT INTO Session_Logs (SessionID, Date, Duration, Summary)\r\nVALUES (0, '03/12/2025 12:00:00 AM', 1.5, 'The tavern hustles and bustles');");
    
    }
}
