using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SQLite;
using Assets.Scripts.Data_Classes;
using TMPro;
using Assets.Scripts.Relations;

namespace Assets.Scripts.Queries
{
    //This contains functions that will be called when view buttons are clicked
    public class QueryDataViewerHandler : MonoBehaviour
    {

        private SQLiteConnection database;
        private TextMeshProUGUI _label;

        void Start()
        {
            string file_loc = Application.dataPath + "/Database/MyDb.db";
            this.database = new SQLiteConnection(file_loc);
        }

        public void OnCampaignDataView()
        {
            var results = database.Query<CampaignData>(
                "SELECT * FROM Campaigns"
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
            }

            //replace debug to sending the text to the text UI
            //Debug.Log(to_print);

            this.UpdateText(to_print);
        }

        public void OnPlayerDataView()
        {
            string query_string =
                "SELECT C.CampaignID, P.PlayerID, P.PlayerName\r\n" +
                "FROM Campaigns C\r\n" +
                "INNER JOIN CampaignPlayers CaP ON C.CampaignID = CaP.CampaignID\r\n" +
                "INNER JOIN Players P ON CaP.PlayerID = P.PlayerID"
                ;

            var p_results = database.Query<PlayerData>(
                query_string
                );

            var camp_results = database.Query<CampaignData>(
                query_string
                );

            string to_print = "";

            for (int i = 0;  i < p_results.Count; i++)
            {
                to_print +=
                    $"Campaign ID: {camp_results[i].Campaign_ID} // Player ID: {p_results[i].Player_ID} // Name: {p_results[i].Player_Name}"
                    + "\r\n"
                    ;
            }

            //Debug.Log(to_print);

            this.UpdateText(to_print);
        }

        public void OnSessionDataView()
        {
            var sl_results = database.Query<SessionLogData>(
                "SELECT C.CampaignID, SL.SessionID, SL.Date \r\nFROM 'Campaigns' C, 'Session_Logs' SL, CampaignSessions CS\r\nWHERE C.CampaignID = CS.CampaignID\r\nAND SL.SessionID = CS.SessionID"
                );

            var camp_results = database.Query<CampaignData>(
                "SELECT C.CampaignID, SL.SessionID, SL.Date \r\nFROM 'Campaigns' C, 'Session_Logs' SL, CampaignSessions CS\r\nWHERE C.CampaignID = CS.CampaignID\r\nAND SL.SessionID = CS.SessionID"
                );

            string to_print = "";

            for (int i = 0; i < sl_results.Count; i++)
            {
                to_print +=
                    $"Campaign ID: {camp_results[i].Campaign_ID} // Session ID: {sl_results[i].Session_ID} // Date: {sl_results[i].Date}\r\n"
                    ;
            }

            Debug.Log(to_print);

            this.UpdateText(to_print);
        }

        public void OnLogsDataView()
        {
            string query_string =
                "SELECT C.CampaignID, SLE.SessionID, L.LogID, Description0\r\n" +
                "FROM Campaigns C\r\n" +
                "INNER JOIN CampaignSessions CS ON C.CampaignID = CS.CampaignID\r\n" +
                "INNER JOIN Session_Logs S ON CS.SessionID = S.SessionID\r\n" +
                "INNER JOIN SessionLogEntries SLE ON S.SessionID = SLE.SessionID\r\n" +
                "INNER JOIN Log_Entries L ON SLE.LogID = L.LogID"
                ;

            var log_results = database.Query<Log_Entry_Data>(
                query_string
                );

            var sle_results = database.Query<SessionLogEntries>(
                query_string
                );

            var camp_results = database.Query<CampaignData>(
                query_string
                );

            string to_print = "";

            for (int i = 0; i < log_results.Count; i++)
            {
                to_print +=
                    $"Campaign ID: {camp_results[i].Campaign_ID} // Session ID: {sle_results[i].Session_ID} // Log ID: {log_results[i].Log_ID} // Desc 0: {log_results[i].Desc0}\r\n"
                    ;
            }

            Debug.Log(to_print);

            this.UpdateText(to_print);
        }

        public void OnItemDataView()
        {
            var results = database.Query<Item_Data>(
                "SELECT * FROM Items"
                );

            string to_print = "";

            foreach (Item_Data itemData in results)
            {
                to_print +=
                    "ID: " + itemData.Item_ID
                    + " // Name: " + itemData.Item_Name
                    + " // Desc: " + itemData.Item_Description
                    + "\n"
                    ;
            }

            Debug.Log(to_print);

            this.UpdateText(to_print);
        }

        public void OnAbilityDataView()
        {
            var results = database.Query<Action_Data>(
                "SELECT * FROM Actions"
                );

            string to_print = "";

            foreach (Action_Data actionData in results)
            {
                to_print +=
                    "ID: " + actionData.Action_ID
                    + " // Name: " + actionData.Action_Name
                    + " // Desc: " + actionData.Action_Description
                    + "\n"
                    ;
            }

            Debug.Log(to_print);

            this.UpdateText(to_print);
        }

        public void OnCharacterDataView()
        {
            var ch_results = database.Query<CharacterData>(
                "SELECT CaP.CampaignID, PC.PlayerID, Ch.CharacterID, Ch.CharacterType, Ch.CharacterName\r\n" +
                "FROM Characters Ch\r\n" +
                "INNER JOIN PlayerCharacters PC ON Ch.CharacterID = PC.CharacterID\r\n" +
                "INNER JOIN CampaignPlayers CaP ON CaP.PlayerID = PC.PlayerID"
                );

            var cap_results = database.Query<CampaignPlayers>(
                "SELECT CaP.CampaignID, PC.PlayerID, Ch.CharacterID, Ch.CharacterType, Ch.CharacterName\r\n" +
                "FROM Characters Ch\r\n" +
                "INNER JOIN PlayerCharacters PC ON Ch.CharacterID = PC.CharacterID\r\n" +
                "INNER JOIN CampaignPlayers CaP ON CaP.PlayerID = PC.PlayerID"
                );

            string to_print = "";

            for (int i = 0;  i < ch_results.Count; i++)
            {
                to_print +=
                    $"Campaign ID: {cap_results[i].Campaign_ID} // Player ID: {cap_results[i].Player_ID}" +
                    $"// Character ID: {ch_results[i].Character_ID} // Character Type: {ch_results[i].Character_Type}" +
                    $"// Character Name: {ch_results[i].Character_Name}" +
                    "\r\n"
                    ;
            }

            //Debug.Log(to_print);

            this.UpdateText(to_print);
        }

        public void AssignTextLabel(TextMeshProUGUI current_label)
        {
            this._label = current_label;
        }

        private void UpdateText(string to_display)
        {
            this._label.text = to_display;
        }
    }
}
