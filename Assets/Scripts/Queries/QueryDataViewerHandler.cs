using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using SQLite;
using Assets.Scripts.Data_Classes;

namespace Assets.Scripts.Queries
{
    //This contains functions that will be called when view buttons are clicked
    public class QueryDataViewerHandler : MonoBehaviour
    {

        private SQLiteConnection database;

        void Start()
        {
            string file_loc = Application.dataPath + "/Database/MyDb.db";
            this.database = new SQLiteConnection(file_loc);
        }

        public void OnCampaignDataView()
        {
            var results = database.Query<CampaignData>(
                "SELECT * FROM 'Campaigns'"
                );

            string to_print = "Campaigns:\n";

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
        }

        public void OnPlayerDataView()
        {
            var results = database.Query<PlayerData>(
                "SELECT \"Player ID\", \"Player Name\" FROM Players"
                );

            string to_print = "Players:\n";

            foreach (PlayerData playerData in results)
            {
                to_print +=
                    "ID: " + playerData.Player_ID
                    + " // Date: " + playerData.Player_Name
                    + "\n"
                    ;
            }

            Debug.Log(to_print);
        }

        public void OnSessionDataView()
        {
            var results = database.Query<SessionLogData>(
                "SELECT \"Session ID\", Date FROM 'Session Logs'"
                );

            string to_print = "Sessions:\n";

            foreach (SessionLogData sessionLog in results)
            {
                to_print +=
                    "ID: " + sessionLog.Session_ID
                    + " // Date: " + sessionLog.Date
                    + "\n"
                    ;
            }

            Debug.Log(to_print);
        }

        public void OnLogsDataView()
        {
            var results = database.Query<Log_Entry_Data>(
                "SELECT \"Log ID\", \"Description 0\" FROM 'Log Entries'"
                );

            string to_print = "Sessions:\n";

            foreach (Log_Entry_Data logData in results)
            {
                to_print +=
                    "ID: " + logData.Log_ID
                    + " // Desc 0: " + logData.Desc0
                    + "\n"
                    ;
            }

            Debug.Log(to_print);
        }

    }
}
