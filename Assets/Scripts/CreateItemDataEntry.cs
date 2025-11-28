using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Assets.Scripts.Data_Classes;

public class CreateItemDataEntry : MonoBehaviour
{
    [SerializeField] public TableCreator tableCreator;

    [SerializeField] public TMP_Text CharacterIDText;
    [SerializeField] public CharacterData characterData = null;
    [SerializeField] private bool characterDataAssigned = false;

    [SerializeField] public TMP_Text itemNameText;
    [SerializeField] public TMP_Text itemDescText;
    [SerializeField] public TMP_Text itemQuantityText;

    [Tooltip("If true, uses the text directly placed inside the script instead of the ones attached to the UI.")]
    public bool debugMode = false;

    public void AssignCharacterData()
    {
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
        this.characterData = this.tableCreator.database.Find<CharacterData>(CharacterID);

    }

    public void createItemData()
    {
        if (debugMode)
            tableCreator.AddItemDataEntry(0, "Potion", "Heals a target for d8 HP.", 1);
        else if (this.characterDataAssigned && int.TryParse(itemQuantityText.text,out int quantity))
        {
            tableCreator.AddItemDataEntry(characterData.Character_ID, itemNameText.text, itemDescText.text, quantity);
        }
        else if (this.characterDataAssigned)
            Debug.LogError("No CharacterData Assigned!");
        else
            Debug.LogError("Failed to parse Item Quantity input as integer.");
    }
}
