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


public class ItemUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    private SQLiteConnection database;
    private TextMeshProUGUI _label;


    [Header("Actions")]
    [SerializeField] private TMP_InputField itemName;
    [SerializeField] private TMP_InputField itemDesc;
    private int ID = 0;
    void Start()
    {
        string file_loc = Application.dataPath + "/Database/MyDb.db";
        this.database = new SQLiteConnection(file_loc);
    }

    public void ItemPlacer(Item_Data itemData)
    {
        this.ID = itemData.Item_ID;
        this.itemName.text = itemData.Item_Name;
        this.itemDesc.text = itemData.Item_Description;
    }

    public void ItemUpdate()
    {


        var record = new Item_Data
        {
            Item_ID = ID,
            Item_Name = itemName.text,
            Item_Description = itemDesc.text
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
