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


public class ActionUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    private SQLiteConnection database;
    private TextMeshProUGUI _label;


    [Header("Actions")]
    [SerializeField] private TMP_InputField actionName;
    [SerializeField] private TMP_InputField actionDesc;
    private int ID = 0;
    void Start()
    {
        string file_loc = Application.persistentDataPath + "/Database/MyDb.db";
        this.database = new SQLiteConnection(file_loc);
    }

    public void ActionPlacer(Action_Data actData)
    {
        this.ID = actData.Action_ID;
        this.actionName.text = actData.Action_Name;
        this.actionDesc.text = actData.Action_Description;
    }

    public void ActionUpdate()
    {


        var record = new Action_Data
        {
            Action_ID = ID,
            Action_Name = actionName.text,
            Action_Description = actionDesc.text
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
