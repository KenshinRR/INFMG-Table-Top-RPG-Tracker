using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreatePlayerDataEntry : MonoBehaviour
{
    [SerializeField] public TableCreator tableCreator;
    [SerializeField] public TMP_InputField playerNameText;


    [SerializeField] public TMP_InputField CampaignIDText;
    [SerializeField] public CampaignData campaignData = null;
    [SerializeField] private bool campaignDataAssigned = false;

    public void AssignCampaignData()
    {
        campaignDataAssigned = false;
        if (int.TryParse(CampaignIDText.text, out int CampaignID))
        {
            this.campaignData = this.tableCreator.database.Find<CampaignData>(CampaignID);
            if (this.campaignData != null)
            {
                this.campaignDataAssigned = true;
                Debug.Log($"Assigned CampaignData with Campaign_ID: {CampaignID}");
            }
            else
            {
                Debug.LogError($"Failed to find CampaignData with Campaign_ID: {CampaignID}");
            }
        }
        else
        {
            Debug.LogError("Failed to parse Campaign ID input as integer.");
        }
    }

    public void CreatePlayerEntry()
    {
        AssignCampaignData();

        if(campaignDataAssigned)
       this.tableCreator.AddPlayerDataEntry(campaignData.Campaign_ID,playerNameText.text);
        else
            Debug.LogError("CampaignData not assigned. Cannot create PlayerData entry.");
    }
}

