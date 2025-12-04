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


public class LogUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    private SQLiteConnection database;
    private TextMeshProUGUI _label;


    [Header("Logs")]
    [SerializeField] private TMP_InputField logDesc1;
    [SerializeField] private TMP_InputField logDesc2;
    [SerializeField] private TMP_InputField logDice;
    [SerializeField] private TMP_InputField logDiceRes;
    private Log_Entry_Data foundlog;
    private int ID = 0;
    void Start()
    {
        string file_loc = Application.dataPath + "/Database/MyDb.db";
        this.database = new SQLiteConnection(file_loc);
    }

    public void LogPlacer(Log_Entry_Data log)
    {
        this.ID = log.Log_ID;
        this.logDesc1.text = log.Desc0;
        this.logDesc2.text = log.Desc1;
        this.logDice.text = log.Dice.ToString();
        this.logDiceRes.text = log.DiceResult.ToString();
        this.foundlog = log;
    }

    public void LogUpdate()
    {


        var record = new Log_Entry_Data
        {
            Log_ID = ID,
            Desc0 = this.logDesc1.text,
            Desc1 = this.logDesc2.text,
            Dice = int.Parse(this.logDice.text),
            DiceResult = int.Parse(this.logDiceRes.text)

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
