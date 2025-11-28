using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateSessionLogDataEntry : MonoBehaviour
{
    [SerializeField] public TableCreator tableCreator;

    [SerializeField] public TMP_Text durationInHoursText;
    [SerializeField] public TMP_Text summaryText;

    [SerializeField] public float durationInHours = 1.5f;
    [SerializeField] public string summary = "Once upon a time, stuff happened, The End.";

    [Tooltip("If true, uses the text directly placed here instead of the ones attached to the UI.")]
    public bool debugMode = false;

    public void CreateSessionLogEntry()
    {
        if (this.debugMode)
        {
            this.tableCreator.AddSessionLogDataEntry(this.tableCreator.database, this.durationInHours, this.summary);
        }
        else if (float.TryParse(this.durationInHoursText.text, out float floatResult))
        {
            this.tableCreator.AddSessionLogDataEntry(this.tableCreator.database, floatResult, this.summaryText.text);
        }
        else
            Debug.LogError("Failed to parse duration input as float.");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
