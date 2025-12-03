using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SQLite;
using Assets.Scripts.Data_Classes;
using TMPro;

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
            Debug.Log(to_print);

            this.UpdateText(to_print);
        }

        public void OnPlayerDataView()
        {
            var results = database.Query<PlayerData>(
                "SELECT PlayerID, PlayerName FROM Players"
                );

            string to_print = "";

            foreach (PlayerData playerData in results)
            {
                to_print +=
                    "ID: " + playerData.Player_ID
                    + " // Name: " + playerData.Player_Name
                    + "\n"
                    ;
            }

            Debug.Log(to_print);

            this.UpdateText(to_print);
        }

        public void OnSessionDataView()
        {
            var results = database.Query<SessionLogData>(
                "SELECT SessionID, Date FROM Session_Logs"
                );

            string to_print = "";

            foreach (SessionLogData sessionLog in results)
            {
                to_print +=
                    "ID: " + sessionLog.Session_ID
                    + " // Date: " + sessionLog.Date
                    + "\n"
                    ;
            }

            Debug.Log(to_print);

            this.UpdateText(to_print);
        }

        public void OnLogsDataView()
        {
            var results = database.Query<Log_Entry_Data>(
                "SELECT LogID, Description0 FROM Log_Entries"
                );

            string to_print = "";

            foreach (Log_Entry_Data logData in results)
            {
                to_print +=
                    "ID: " + logData.Log_ID
                    + " // Desc 0: " + logData.Desc0
                    + "\n"
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
