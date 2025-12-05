using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using SQLite;
using Assets.Scripts.Data_Classes;
using Assets.Scripts.Relations;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using static UnityEditor.Progress;
using Unity.VisualScripting;
using NUnit.Framework.Internal;

public class UpdateSelector : MonoBehaviour
{
    // Start is called before the first frame update
    private SQLiteConnection database;
    private TextMeshProUGUI _label;


    [Header("Campaigns")]
    [SerializeField] private TMP_InputField campaignID;
    [SerializeField] private CampaignUpdater campUPD;

    [Header("Characters")]
    [SerializeField] private TMP_InputField characterID;
    [SerializeField] private CharacterUpdater charUPD;

    [Header("Actions")]
    [SerializeField] private TMP_InputField actionID;
    [SerializeField] private ActionUpdater actionUPD;

    [Header("Items")]
    [SerializeField] private TMP_InputField itemID;
    [SerializeField] private ItemUpdater itemUPD;

    [Header("Players")]
    [SerializeField] private TMP_InputField playerID;
    [SerializeField] private PlayerUpdater playerUPD;

    [Header("Sessions")]
    [SerializeField] private TMP_InputField sessionID;
    [SerializeField] private SessionUpdater sessionUPD;

    [Header("Logs")]
    [SerializeField] private TMP_InputField logsID;
    [SerializeField] private LogUpdater logsUPD;
    //Header
    void Start()
    {
        string file_loc = Application.dataPath + "/Database/MyDb.db";
        this.database = new SQLiteConnection(file_loc);
    }



    public void OnCampaignUpdateSelect()
    {
        var results = database.Query<CampaignData>(
                $"SELECT * FROM 'Campaigns' WHERE CampaignID = {campaignID.text}  LIMIT 0,30"
                );

        string to_print = "";

        foreach (CampaignData campaign in results)
        {
            to_print +=
                "ID: " + campaign.Campaign_ID
                + " // Campaign Name: " + campaign.Campaign_Name
                + " // Campaign Rule System" + campaign.RuleSystem
                + "\n"
                ;
            Debug.Log(to_print);
            this.campUPD.CampaignPlacer(campaign);
        }

       
     
    }

    public void OnCharactersUpdateSelect()
    {
        var results = database.Query<CharacterData>(
                $"SELECT * FROM 'Characters' WHERE CharacterID = {characterID.text}  LIMIT 0,30"
                );

        string to_print = "";

        foreach (CharacterData character in results)
        {
            to_print +=
                "ID: " + character.Character_ID
                + " // Char Name: " + character.Character_Name
                + "\n"
                ;
            Debug.Log(to_print);
            this.charUPD.CharacterPlacer(character);
        }



    }

    public void OnActionsUpdateSelect()
    {
        var results = database.Query<Action_Data>(
                $"SELECT * FROM 'Actions' WHERE ActionID = {actionID.text} LIMIT 0, 30"
                );

        string to_print = "";

        foreach (Action_Data action in results)
        {
            to_print +=
                "ID: " + action.Action_Name
                + " // Action Name:" + action.Action_Description
                + "\n"
                ;
            Debug.Log(to_print);
            this.actionUPD.ActionPlacer(action);
        }



    }

    public void OnItemsUpdateSelect()
    {
        var results = database.Query<Item_Data>(
                $"SELECT * FROM 'Items' WHERE ItemID = 1 LIMIT 0, 30"
                );

        string to_print = "";

        foreach (Item_Data item in results)
        {
            to_print +=
                "ID: " + item.Item_ID
                + " // Item Name:" + item.Item_Name
                + "\n"
                ;
            Debug.Log(to_print);
            this.itemUPD.ItemPlacer(item);
        }



    }

    public void OnPlayerUpdateSelect()
    {
        var results = database.Query<PlayerData>(
                $"SELECT * FROM 'Players' WHERE PlayerID = {playerID.text} LIMIT 0, 30"
                );

        string to_print = "";

        foreach (PlayerData player in results)
        {
            to_print +=
                "ID: " + player.Player_ID
                + " // Player Name:" + player.Player_Name
                + "\n"
                ;
            Debug.Log(to_print);
            this.playerUPD.PlayerPlacer(player);
        }



    }


    public void OnSessionUpdateSelect()
    {
        Debug.Log("I am runnig");
        var results = database.Query<SessionLogData>(
                $"SELECT * FROM 'Session_Logs' WHERE SessionID =  {sessionID.text} LIMIT 0,30"
                );

        string to_print = "";

        foreach (SessionLogData session in results)
        {
            to_print +=
                "ID: " + session.Session_ID
                + " // Summ:" + session.Summary
                + "\n"
                ;
            Debug.Log(to_print);
            this.sessionUPD.SessionPlacer(session);
        }



    }

    public void OnLogsUpdateSelect()
    {
        Debug.Log("I am runnig");
        var results = database.Query<Log_Entry_Data>(
                $"SELECT * FROM 'Log_Entries' WHERE LogID = {logsID.text} LIMIT 0,30"
                );

        string to_print = "";

        foreach (Log_Entry_Data log in results)
        {
            to_print +=
                "ID: " + log.Log_ID
                + " // Summ:" + log.Desc0
                + "\n"
                ;
            Debug.Log(to_print);
            this.logsUPD.LogPlacer(log);
        }



    }
}
