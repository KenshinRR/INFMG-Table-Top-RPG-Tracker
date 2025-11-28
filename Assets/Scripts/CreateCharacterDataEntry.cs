using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateCharacterDataEntry : MonoBehaviour
{
    [SerializeField] public TableCreator tableCreator;

    [SerializeField] public TMP_Text charTypeText;
    [SerializeField] public TMP_Text charNameText;
    [SerializeField] public TMP_Text backstoryText;
    [SerializeField] public TMP_Text alignmentText;
    [SerializeField] public TMP_Text raceText;
    [SerializeField] public TMP_Text charClassText;

    [SerializeField] public TMP_Text strengthText;
    [SerializeField] public TMP_Text dexterityText;
    [SerializeField] public TMP_Text constitutionText;
    [SerializeField] public TMP_Text intelligenceText;
    [SerializeField] public TMP_Text charismaText;

    [SerializeField] public TMP_Text armorClassText;
    [SerializeField] public TMP_Text speedText;
    [SerializeField] public TMP_Text hitpointsText;

    [SerializeField] public TMP_Text experiencePointsText;
    [SerializeField] public TMP_Text levelText;

    [SerializeField] public string charType = "PC";
    [SerializeField] public string charName = "Namae";
    [SerializeField] public string backstory = "...";
    [SerializeField] public string alignment = "Lawful Good";
    [SerializeField] public string race = "Human";
    [SerializeField] public string charClass = "Ranger";

    [SerializeField] public int strength = 16;
    [SerializeField] public int dexterity = 14;
    [SerializeField] public int constitution = 15;
    [SerializeField] public int intelligence = 12;
    [SerializeField] public int charisma = 13;

    [SerializeField] public int armorClass = 17;
    [SerializeField] public int speed = 30;
    [SerializeField] public int hitpoints = 45;

    [SerializeField] public int experiencePoints = 0;
    [SerializeField] public int level = 1;

    [Tooltip("If true, uses the text directly placed here instead of the ones attached to the UI.")]
    public bool debugMode = false;

    public void CreateCharacterEntry()
    {
        if(debugMode)
            this.tableCreator.AddCharacterDataEntry(charType, charName, backstory, alignment,
                race, charClass, strength, dexterity, constitution, intelligence, charisma, 
                armorClass, speed, hitpoints, experiencePoints, level);
        else if (int.TryParse(strengthText.text, out int str) &&
               int.TryParse(dexterityText.text, out int dex) &&
               int.TryParse(constitutionText.text, out int con) &&
               int.TryParse(intelligenceText.text, out int intel) &&
               int.TryParse(charismaText.text, out int cha) &&
               int.TryParse(armorClassText.text, out int ac) &&
               int.TryParse(speedText.text, out int spd) &&
               int.TryParse(hitpointsText.text, out int hp) &&
               int.TryParse(experiencePointsText.text, out int exp) &&
               int.TryParse(levelText.text, out int lvl))
        {
                this.tableCreator.AddCharacterDataEntry(charTypeText.text, charNameText.text, backstoryText.text, alignmentText.text,
                raceText.text, charClassText.text, str, dex, con, intel, cha,
                ac, spd, hp, exp, lvl);

        }
        else
        {
            Debug.LogError("Failed to parse one or more integer inputs for character stats.");
        }
    }
}
