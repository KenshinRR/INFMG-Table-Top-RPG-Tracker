using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateSessionLogDataEntry : MonoBehaviour
{
    [SerializeField] public TableCreator tableCreator;

    [SerializeField] public TMP_Text CampaignIDText;
    [SerializeField] public CampaignData campaignData = null;
    [SerializeField] private bool campaignDataAssigned = false;

    [SerializeField] public TMP_Text durationInHoursText;
    [SerializeField] public TMP_Text summaryText;

    [SerializeField] public float durationInHours = 1.5f;
    [SerializeField] public string summary = "Once upon a time, stuff happened, The End.";

    [Tooltip("If true, uses the text directly placed here instead of the ones attached to the UI.")]
    public bool debugMode = false;

    public void AssignCampaignData()
    {
        if (int.TryParse(CampaignIDText.text, out int CampaignID))
        {
            this.campaignData = this.tableCreator.database.Find<CampaignData>(CampaignID);
            if (this.campaignData != null)
            {
                this.campaignDataAssigned = true;
                Debug.Log($"Assigned CampaignData with Campaign_ID: {CampaignID}");
            }
            else
                Debug.LogError($"Failed to find CampaignData with Campaign_ID: {CampaignID}");
        }
        else
            Debug.LogError("Failed to parse Campaign ID input as integer.");
        this.campaignData = this.tableCreator.database.Find<CampaignData>(CampaignID);

    }

    public void CreateSessionLogEntry()
    {
        if (this.debugMode)
        {
            this.tableCreator.AddSessionLogDataEntry(0, this.durationInHours, this.summary);
        }
        else if (this.campaignDataAssigned && int.TryParse(CampaignIDText.text, out int cID)&& float.TryParse(this.durationInHoursText.text, out float floatResult))
        {
            this.tableCreator.AddSessionLogDataEntry(cID, floatResult, this.summaryText.text);
        }
        else
            Debug.LogError("Failed to parse Campaign ID input as integer or Duration input as float.");
    }
}
