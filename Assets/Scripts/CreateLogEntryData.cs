using TMPro;
using UnityEngine;

public class CreateLogEntryData : MonoBehaviour
{
    [SerializeField] public TableCreator tableCreator;

    [SerializeField] public TMP_Text SessionIDText;
    [SerializeField] public SessionLogData sessionLogData = null;
    [SerializeField] private bool sessionLogDataAssigned = false;

    [SerializeField] public TMP_Text Desc0Text;
    [SerializeField] public TMP_Text Desc1Text;
    [SerializeField] public TMP_Text DiceText;
    [SerializeField] public TMP_Text DiceResultText;

    [SerializeField] public string Desc0 = "Epic Adventure";
    [SerializeField] public string Desc1 = "Dungeons & Dragons 5e";
    [SerializeField] public int Dice = 20;
    [SerializeField] public int DiceResult = 15;

    [Tooltip("If true, uses the text directly placed here instead of the ones attached to the UI.")]
    public bool debugMode = false;

    [Tooltip("For Testing with Debug Mode (IDs start at 1, not 0!)")]
    public void DebugAssignSessionLogData(int SessionLogData_SessionID)
    {
        this.sessionLogData = this.tableCreator.database.Find<SessionLogData>(SessionLogData_SessionID);
        if (this.sessionLogData != null)
        {
            this.sessionLogDataAssigned = true;
            Debug.Log($"Assigned SessionLogData with Session_ID: {SessionLogData_SessionID}");
        }
        else      
            Debug.LogError($"Failed to find SessionLogData with Session_ID: {SessionLogData_SessionID}");
    }

    public void AssignSessionLogData()
    {

        if(int.TryParse(SessionIDText.text, out int SessionLogData_SessionID))
        {
            this.sessionLogData = this.tableCreator.database.Find<SessionLogData>(SessionLogData_SessionID);
            if (this.sessionLogData != null)
            {
                this.sessionLogDataAssigned = true;
                Debug.Log($"Assigned SessionLogData with Session_ID: {SessionLogData_SessionID}");
            }
            else
                Debug.LogError($"Failed to find SessionLogData with Session_ID: {SessionLogData_SessionID}");
        }
        else
         Debug.LogError("Failed to parse Session ID input as integer."); 
            this.sessionLogData = this.tableCreator.database.Find<SessionLogData>(SessionLogData_SessionID);

    }

    public void CreateLogEntry()
    {
        if (sessionLogDataAssigned == false || sessionLogData == null)
        {
            Debug.LogError("SessionLogData not assigned in CreateLogEntryData script.");
        }
        else
        {
            if (this.debugMode)
                this.tableCreator.AddLogEntryDataEntry(sessionLogData.Session_ID, this.Desc0, this.Desc1, this.Dice, this.DiceResult);
            else if (int.TryParse(DiceText.text, out int dText) && int.TryParse(DiceResultText.text, out int dRText))
                this.tableCreator.AddLogEntryDataEntry(sessionLogData.Session_ID, Desc0Text.text, Desc1Text.text, dText, dRText);
            else
                Debug.LogError("Failed to parse Dice or Dice Result input as integer.");
        }

    }
}
