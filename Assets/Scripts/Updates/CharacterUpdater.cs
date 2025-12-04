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


public class CharacterUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    private SQLiteConnection database;
    private TextMeshProUGUI _label;


    [Header("Characters")]
    [SerializeField] private TMP_InputField charName;
    [SerializeField] private TMP_InputField charLVL;
    [SerializeField] private TMP_InputField charSTR;
    [SerializeField] private TMP_InputField charSPD;
    [SerializeField] private TMP_InputField charDEF;
    [SerializeField] private TMP_InputField charVIT;

    private int ID = 0;
    void Start()
    {
        string file_loc = Application.dataPath + "/Database/MyDb.db";
        this.database = new SQLiteConnection(file_loc);
    }

    public void CharacterPlacer(CharacterData charData)
    {
        this.ID = charData.Character_ID;
        this.charName.text = charData.Character_Name;
        this.charLVL.text = charData.Level.ToString();
        this.charSTR.text = charData.Strength.ToString();
        this.charDEF.text = charData.Defence.ToString();
        this.charSPD.text = charData.Speed.ToString();
        this.charVIT.text = charData.Vitality.ToString();
     
    }

    public void CharacterUpdate()
    {


        var record = new CharacterData
        {
            Character_ID = this.ID,
            Character_Name =charName.text,
            Character_Type = "PC",
            Defence = int.Parse(charDEF.text),
            Level = int.Parse(charLVL.text),
            Speed = int.Parse(charSPD.text),
            Strength = int.Parse(charSTR.text),
            Vitality = int.Parse(charVIT.text)
            
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
