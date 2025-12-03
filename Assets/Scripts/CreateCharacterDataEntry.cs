using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Assets.Scripts.Data_Classes;

public class CreateCharacterDataEntry : MonoBehaviour
{
    [SerializeField] public TableCreator tableCreator;


    [SerializeField] public TMP_InputField PlayerIDText;
    [SerializeField] public bool PlayerFound = false;

    [SerializeField] public TMP_InputField charTypeText;
    [SerializeField] public TMP_InputField charNameText;
    [SerializeField] public TMP_InputField strengthText;
    [SerializeField] public TMP_InputField armorClassText;
    [SerializeField] public TMP_InputField speedText;
    [SerializeField] public TMP_InputField hitpointsText;
    [SerializeField] public TMP_InputField levelText;

    public void CreateCharacterEntry()
    {
        this.PlayerFound = false;

        if (int.TryParse(PlayerIDText.text, out int PID))
        {
            var playerData = this.tableCreator.database.Find<PlayerData>(PID);
            if (playerData != null)
            {
                this.PlayerFound = true;
            }
            else
                Debug.LogError($"Failed to find PlayerData with PlayerID: {PID}");
        }
        else
            Debug.LogError("Failed to parse Player ID input as integer.");


        if (PlayerFound && int.TryParse(strengthText.text, out int str) &&
               int.TryParse(armorClassText.text, out int def) &&
               int.TryParse(speedText.text, out int spd) &&
               int.TryParse(hitpointsText.text, out int vit) &&
               int.TryParse(levelText.text, out int lvl))
        {
                this.tableCreator.AddCharacterDataEntry(int.Parse(PlayerIDText.text),charTypeText.text,charNameText.text,lvl,str,vit,spd,def);
        }
        else
        {
            Debug.LogError("Failed to parse one or more integer inputs for character stats.");
        }
    }
}
