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


public class SessionUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    private SQLiteConnection database;
    private TextMeshProUGUI _label;


    [Header("Actions")]
    [SerializeField] private TMP_Text sessionDate;
    [SerializeField] private TMP_InputField sessionSumm;
    [SerializeField] private TMP_Text sessionDur;
    private SessionLogData foundSesh;
    private int ID = 0;
    void Start()
    {
        string file_loc = Application.dataPath + "/Database/MyDb.db";
        this.database = new SQLiteConnection(file_loc);
    }

    public void SessionPlacer(SessionLogData sesh)
    {
        this.ID = sesh.Session_ID;
        this.sessionDate.text = sesh.Date;
        this.sessionSumm.text = sesh.Summary;
        this.sessionDur.text = sesh.Duration.ToString();
        this.foundSesh = sesh;
    }

    public void SessionUpdate()
    {


        var record = new SessionLogData
        {
            Session_ID = this.ID,
            Summary = this.sessionSumm.text,
            Date = foundSesh.Date,
            Duration = foundSesh.Duration

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
