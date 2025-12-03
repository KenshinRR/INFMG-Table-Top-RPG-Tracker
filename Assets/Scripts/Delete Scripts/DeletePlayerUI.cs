using UnityEngine;
using TMPro;

public class DeletePlayerUI : MonoBehaviour
{
    [Header("References")]
    public DeleteManager deleteManager;
    public TMP_InputField inputID;

    public void OnDeletePressed()
    {
        if (!ValidateInput(out int id)) return;

        deleteManager.DeletePlayer(id);
        Debug.Log($"Deleted Player ID: {id}");
        inputID.text = "";
    }

    private bool ValidateInput(out int id)
    {
        id = -1;
        if (inputID == null)
        {
            Debug.LogError("DeletePlayerUI: Input field not assigned!");
            return false;
        }
        if (!int.TryParse(inputID.text, out id))
        {
            Debug.LogError("DeletePlayerUI: Invalid ID!");
            return false;
        }
        return true;
    }
}
