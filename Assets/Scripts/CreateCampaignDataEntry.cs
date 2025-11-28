using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateCampaignDataEntry : MonoBehaviour
{
    [SerializeField] public TableCreator tableCreator;

    [SerializeField] public TMP_Text campaignNameText;
    [SerializeField] public TMP_Text ruleSystemText;

    [SerializeField] public string campaignName = "Epic Adventure";
    [SerializeField] public string ruleSystem = "Dungeons & Dragons 5e";

    [Tooltip("If true, uses the text directly placed here instead of the ones attached to the UI.")]
    public bool debugMode = false;

    public void CreateCampaignEntry()
    {
        if (this.debugMode)
            this.tableCreator.AddCampaignDataEntry(this.tableCreator.database, this.campaignName, this.ruleSystem);
        else 
        this.tableCreator.AddCampaignDataEntry(this.tableCreator.database, this.campaignNameText.text, this.ruleSystemText.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
