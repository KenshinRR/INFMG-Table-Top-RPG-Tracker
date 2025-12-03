using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SQLite;
using TMPro;
using UnityEngine.Windows;
using Assets.Scripts.Data_Classes;
using Unity.VisualScripting;

namespace Assets.Scripts.Queries
{
    public class FilterDataViewerHandler : MonoBehaviour
    {
        private SQLiteConnection database;
        private TextMeshProUGUI _label;

        private QueryDataViewerHandler _Query_Data_Viewer_Handler;

        [Header("Campaign Inputs")]
        [SerializeField]
        private TMP_InputField c_if_campaignID;
        [SerializeField]
        private TMP_InputField c_if_playerID;

        [Header("Session Inputs")]
        [SerializeField]
        private TMP_InputField s_if_campaignID;

        void Start()
        {
            string file_loc = Application.dataPath + "/Database/MyDb.db";
            this.database = new SQLiteConnection(file_loc);

            this._Query_Data_Viewer_Handler = GetComponent<QueryDataViewerHandler>();
        }

        public void AssignTextLabel(TextMeshProUGUI current_label)
        {
            this._label = current_label;
        }

        private void UpdateText(string to_display)
        {
            this._label.text = to_display;
        }

        public void OnFilterCampaigns()
        {
            int curr_campaign_id, curr_player_id;
            string where_condition = "WHERE ";
            bool camp_id_exists = false, player_id_exists = false;

            //getting campaign ID
            if (int.TryParse(c_if_campaignID.text, out curr_campaign_id))
            {
                where_condition += "C.CampaignID = " + curr_campaign_id;
                camp_id_exists = true;
            }
            else
            {
                Debug.LogWarning("Invalid input: '" + c_if_campaignID.text + "' cannot be converted to an integer.");
            }

            //getting player ID
            if (int.TryParse(c_if_playerID.text, out curr_player_id))
            {
                if (camp_id_exists)
                {
                    where_condition += " OR ";
                }

                where_condition += "P.PlayerID = " + curr_player_id;
                player_id_exists = true;
            }
            else
            {
                Debug.LogWarning("Invalid input: '" + c_if_playerID.text + "' cannot be converted to an integer.");
            }

            //checking if there are inputs
            if (!camp_id_exists  && !player_id_exists)
            {
                Debug.LogError("No inputted filters!");

                this._Query_Data_Viewer_Handler.OnCampaignDataView();

                return;
            }

            //getting campaign data
            var camp_results = database.Query<CampaignData>(
                "SELECT DISTINCT C.CampaignID, CampaignName\r\n" +
                "FROM Campaigns C\r\n" +
                "INNER JOIN CampaignSessions CS\r\nON C.CampaignID = CS.CampaignID\r\n" +
                "INNER JOIN CampaignPlayers CaP\r\nON CS.CampaignID = CaP.CampaignID\r\n" +
                "INNER JOIN Players P\r\nON CaP.PlayerID = P.PlayerID\r\n" +
                where_condition
                );

            string to_print = "";

            //foreach (CampaignData campaignData in results)
            //{
            //    to_print +=
            //        "Campaign ID: " + campaignData.Campaign_ID
            //        + " // Campaign Name: " + campaignData.Campaign_Name
            //        + "\n"
            //        ;
            //}

            //getting player data
            var player_results = database.Query<PlayerData>(
                "SELECT DISTINCT C.CampaignID, CampaignName, Cap.PlayerID, P.PlayerName\r\n" +
                "FROM Campaigns C\r\n" +
                "INNER JOIN CampaignSessions CS\r\nON C.CampaignID = CS.CampaignID\r\n" +
                "INNER JOIN CampaignPlayers CaP\r\nON CS.CampaignID = CaP.CampaignID\r\n" +
                "INNER JOIN Players P\r\nON CaP.PlayerID = P.PlayerID\r\n" +
                where_condition
                );

            //foreach (PlayerData playerData in results2)
            //{
            //    to_print +=
            //        "// Player ID: " + playerData.Player_ID
            //        + " // Player Name: " + playerData.Player_Name
            //        + "\n"
            //        ;
            //}

            for (int i = 0; i < player_results.Count; i++)
            {
                to_print +=
                    $"Campaign ID: {camp_results[i].Campaign_ID} // Campaign Name: {camp_results[i].Campaign_Name} // " +
                    $"Player ID: {player_results[i].Player_ID} // Player Name: {player_results[i].Player_Name}"
                    ;
            }

            //Debug.Log(to_print);

            this.UpdateText(to_print);
        }
    
        public void OnFilterSessions()
        {
            int curr_camp_id;
            bool camp_id_exists = false;

            //getting campaign ID
            if (int.TryParse(c_if_campaignID.text, out curr_camp_id))
            {
                camp_id_exists = true;
            }
            else
            {
                Debug.LogWarning("Invalid input: '" + c_if_campaignID.text + "' cannot be converted to an integer.");
            }

            if (!camp_id_exists)
            {
                this._Query_Data_Viewer_Handler.OnSessionDataView();

                return;
            }

            var sl_results = database.Query<SessionLogData>(
                "SELECT C.CampaignID, SL.SessionID, SL.Date \r\n" +
                "FROM 'Campaigns' C, 'Session_Logs' SL, CampaignSessions CS\r\n" +
                "WHERE C.CampaignID = CS.CampaignID\r\n" +
                "AND SL.SessionID = CS.SessionID\r\n" +
                $"AND C.CampaignID = {curr_camp_id}"
                );

            var camp_results = database.Query<CampaignData>(
                "SELECT C.CampaignID, SL.SessionID, SL.Date \r\n" +
                "FROM 'Campaigns' C, 'Session_Logs' SL, CampaignSessions CS\r\n" +
                "WHERE C.CampaignID = CS.CampaignID\r\n" +
                "AND SL.SessionID = CS.SessionID\r\n" +
                $"AND C.CampaignID = {curr_camp_id}"
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
    }
}
