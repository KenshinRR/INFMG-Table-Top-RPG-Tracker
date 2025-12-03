using UnityEngine;
using TMPro;

public class DeleteSessionLogUI : MonoBehaviour
{
    [Header("References")]
    public DeleteManager deleteManager;
    public TMP_InputField inputID;

    public void OnDeletePressed()
    {
        if (!ValidateInput(out int id)) return;

        deleteManager.DeleteSessionLog(id);
        Debug.Log($"Deleted Session Log ID: {id}");
        inputID.text = "";
    }

    private bool ValidateInput(out int id)
    {
        id = -1;
        if (inputID == null)
        {
            Debug.LogError("DeleteSessionLogUI: Input field not assigned!");
            return false;
        }
        if (!int.TryParse(inputID.text, out id))
        {
            Debug.LogError("DeleteSessionLogUI: Invalid ID!");
            return false;
        }
        return true;
    }
}
