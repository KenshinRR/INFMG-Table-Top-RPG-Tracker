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


public class PlayerUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    private SQLiteConnection database;
    private TextMeshProUGUI _label;


    [Header("Actions")]
    [SerializeField] private TMP_InputField playerName;
    //[SerializeField] private TMP_InputField playerDesc;
    private int ID = 0;
    void Start()
    {
        string file_loc = Application.dataPath + "/Database/MyDb.db";
        this.database = new SQLiteConnection(file_loc);
    }

    public void PlayerPlacer(PlayerData playerData)
    {
        this.ID = playerData.Player_ID;
        this.playerName.text = playerData.Player_Name;
    }

    public void PlayerUpdate()
    {


        var record = new PlayerData
        {
            Player_ID = ID,
            Player_Name = this.playerName.text
            
        };



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
