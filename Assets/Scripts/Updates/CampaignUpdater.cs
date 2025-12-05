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
using System.Data;
using UnityEngine.Profiling;
using Unity.VisualScripting;


public class CampaignUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    private SQLiteConnection database;
    private TextMeshProUGUI _label;


    [Header("Campaigns")]
    [SerializeField] private TMP_InputField campaignName;
    [SerializeField] private TMP_Dropdown campaignRul;
    private int ID = 0;
    void Start()
    {
        string file_loc = Application.persistentDataPath + "/Database/MyDb.db";
        this.database = new SQLiteConnection(file_loc);
    }

    public void CampaignPlacer(CampaignData campData)
    {
        this.ID = campData.Campaign_ID;
       if(campData.RuleSystem == "Rule 5E")
       {
            this.campaignRul.value = 0;
       }
        campaignName.text = campData.Campaign_Name;
    }

    public void CampaignUpdate()
    {
        
       
        var record = new CampaignData { Campaign_ID = ID,
            Campaign_Name = campaignName.text, 
            RuleSystem = campaignRul.options[this.campaignRul.value].text };
        
       

        var results = database.Update(record);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnDestroy()
    {
        database.Close();
    }
}
