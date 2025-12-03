using Assets.Scripts.Data_Classes;
using Assets.Scripts.Relations;
using SQLite;
using System.Collections.Generic;
using UnityEngine;

public class DeleteManager : MonoBehaviour
{
    private SQLiteConnection database;

    void Start()
    {
        string fileLoc = Application.dataPath + "/Database/MyDb.db";
        database = new SQLiteConnection(fileLoc);
        Debug.Log("DeleteManager connected to DB");
    }

    // -------------------------
    // CHARACTER DELETE
    // -------------------------
    public void DeleteCharacter(int characterID)
    {
        database.Execute($"DELETE FROM PlayerCharacters WHERE CharacterID = {characterID}");
        database.Execute($"DELETE FROM CharacterItems   WHERE CharacterID = {characterID}");
        database.Execute($"DELETE FROM CharacterActions WHERE CharacterID = {characterID}");
        database.Execute($"DELETE FROM Characters       WHERE CharacterID = {characterID}");

        database.Execute("VACUUM");

        Debug.Log($"Deleted Character {characterID}");
        
    }

    // -------------------------
    // PLAYER DELETE
    // -------------------------
    public void DeletePlayer(int playerID)
    {
        database.Execute($"DELETE FROM PlayerCharacters WHERE PlayerID = {playerID}");
        database.Execute($"DELETE FROM CampaignPlayers  WHERE PlayerID = {playerID}");
        database.Execute($"DELETE FROM Players          WHERE PlayerID = {playerID}");

        database.Execute("VACUUM");

        Debug.Log($"Deleted Player {playerID}");
    }

    // -------------------------
    // ITEM DELETE
    // -------------------------
    public void DeleteItem(int itemID)
    {
        database.Execute($"DELETE FROM CharacterItems WHERE ItemID = {itemID}");
        database.Execute($"DELETE FROM Items           WHERE ItemID = {itemID}");

        database.Execute("VACUUM");

        Debug.Log($"Deleted Item {itemID}");
    }

    // -------------------------
    // ABILITY / ACTION DELETE
    // -------------------------
    public void DeleteAbility(int actionID)
    {
        database.Execute($"DELETE FROM CharacterActions WHERE ActionID = {actionID}");
        database.Execute($"DELETE FROM Actions          WHERE ActionID = {actionID}");

        database.Execute("VACUUM");

        Debug.Log($"Deleted Ability {actionID}");
    }

    // -------------------------
    // LOG ENTRY DELETE
    // -------------------------
    public void DeleteLogEntry(int logID)
    {
        database.Execute($"DELETE FROM SessionLogEntries WHERE LogID = {logID}");
        database.Execute($"DELETE FROM Log_Entries       WHERE LogID = {logID}");

        database.Execute("VACUUM");

        Debug.Log($"Deleted Log Entry {logID}");
    }

    // -------------------------
    // SESSION LOG DELETE
    // -------------------------
    public void DeleteSessionLog(int sessionID)
    {
        database.Execute($"DELETE FROM SessionLogEntries WHERE SessionID = {sessionID}");
        database.Execute($"DELETE FROM CampaignSessions  WHERE SessionID = {sessionID}");
        database.Execute($"DELETE FROM Session_Logs      WHERE SessionID = {sessionID}");

        database.Execute("VACUUM");

        Debug.Log($"Deleted Session Log {sessionID}");
    }

    // -------------------------
    // CAMPAIGN DELETE
    // -------------------------
    public void DeleteCampaign(int campaignID)
    {
        var sessions = database.Query<CampaignSessions>(
            $"SELECT * FROM CampaignSessions WHERE CampaignID = {campaignID}");

        foreach (var s in sessions)
        {
            DeleteSessionLog(s.Session_ID);
        }

        database.Execute($"DELETE FROM CampaignPlayers  WHERE CampaignID = {campaignID}");
        database.Execute($"DELETE FROM CampaignSessions WHERE CampaignID = {campaignID}");
        database.Execute($"DELETE FROM Campaigns        WHERE CampaignID = {campaignID}");

        database.Execute("VACUUM");

        Debug.Log($"Deleted Campaign {campaignID}");
    }
}
