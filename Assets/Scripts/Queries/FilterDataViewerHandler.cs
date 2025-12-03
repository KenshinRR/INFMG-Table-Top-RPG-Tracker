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

namespace Assets.Scripts.Queries
{
    public class FilterDataViewerHandler : MonoBehaviour
    {
        private SQLiteConnection database;
        private TextMeshProUGUI _label;

        [Header("Campaign Inputs")]
        [SerializeField]
        private TMP_InputField if_campaignID;
        [SerializeField]
        private TMP_InputField if_playerID;

        void Start()
        {
            string file_loc = Application.dataPath + "/Database/MyDb.db";
            this.database = new SQLiteConnection(file_loc);
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
            if (int.TryParse(if_campaignID.text, out curr_campaign_id))
            {
                where_condition += "C.CampaignID = " + curr_campaign_id;
                camp_id_exists = true;
            }
            else
            {
                Debug.LogWarning("Invalid input: '" + if_campaignID.text + "' cannot be converted to an integer.");
            }

            //getting player ID
            if (int.TryParse(if_playerID.text, out curr_player_id))
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
                camp_id_exists = false;
                Debug.LogWarning("Invalid input: '" + if_playerID.text + "' cannot be converted to an integer.");
            }

            if (!camp_id_exists  && !player_id_exists)
            {
                Debug.LogError("No inputted filters!");
                return;
            }

            //getting campaign data
            var results = database.Query<CampaignData>(
                "SELECT DISTINCT C.CampaignID, CampaignName, Cap.PlayerID, P.PlayerName\r\n" +
                "FROM Campaigns C" +
                "INNER JOIN CampaignSessions CS\r\nON C.CampaignID = CS.CampaignID" +
                "INNER JOIN CampaignPlayers CaP\r\nON CS.CampaignID = CaP.CampaignID" +
                "INNER JOIN Players P\r\nON CaP.PlayerID = P.PlayerID" +
                where_condition
                );

            string to_print = "";

            foreach (CampaignData campaignData in results)
            {
                to_print +=
                    "Campaign ID: " + campaignData.Campaign_ID
                    + " // Campaign Name: " + campaignData.Campaign_Name
                    + "\n"
                    ;
            }

            //getting player data
            var results2 = database.Query<PlayerData>(
                "SELECT DISTINCT C.CampaignID, CampaignName, Cap.PlayerID, P.PlayerName\r\n" +
                "FROM Campaigns C" +
                "INNER JOIN CampaignSessions CS\r\nON C.CampaignID = CS.CampaignID" +
                "INNER JOIN CampaignPlayers CaP\r\nON CS.CampaignID = CaP.CampaignID" +
                "INNER JOIN Players P\r\nON CaP.PlayerID = P.PlayerID" +
                where_condition
                );

            foreach (PlayerData playerData in results2)
            {
                to_print +=
                    "// Player ID: " + playerData.Player_ID
                    + " // Player Name: " + playerData.Player_Name
                    + "\n"
                    ;
            }

            Debug.Log(to_print);

            this.UpdateText(to_print);
        }
    }
}
