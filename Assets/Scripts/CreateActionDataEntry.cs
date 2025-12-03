using Assets.Scripts.Data_Classes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateActionDataEntry : MonoBehaviour
{
    [SerializeField] public TableCreator tableCreator;

    [SerializeField] public TMP_InputField CharacterIDText;
    [SerializeField] public CharacterData characterData = null;
    [SerializeField] private bool characterDataAssigned = false;

    [SerializeField] public TMP_InputField actionNameText;
    [SerializeField] public TMP_InputField actionDescText;

    [Tooltip("If true, uses the text directly placed inside the script instead of the ones attached to the UI.")]
    public bool debugMode = false;

    public void AssignCharacterData()
    {
        characterDataAssigned = false;
        if (int.TryParse(CharacterIDText.text, out int CharacterID))
        {
            this.characterData = this.tableCreator.database.Find<CharacterData>(CharacterID);
            if (this.characterData != null)
            {
                this.characterDataAssigned = true;
                Debug.Log($"Assigned CharacterData with Character_ID: {CharacterID}");
            }
            else
                Debug.LogError($"Failed to find CharacterData with Character_ID: {CharacterID}");
        }
        else
            Debug.LogError("Failed to parse Character ID input as integer.");

    }

    public void createActionData()
    {
        AssignCharacterData();
        if (debugMode)
        tableCreator.AddActionDataEntry(0, "Attack", "Roll a d20 and add your attack bonus to determine if you hit the target.");
        else if (this.characterDataAssigned)
        {
            tableCreator.AddActionDataEntry(characterData.Character_ID ,actionNameText.text, actionDescText.text);
        }
        else
            Debug.LogError("No CharacterData Assigned!");
    }
}
