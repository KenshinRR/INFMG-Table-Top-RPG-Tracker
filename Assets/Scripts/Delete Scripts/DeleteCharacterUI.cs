using UnityEngine;
using TMPro;

public class DeleteCharacterUI : MonoBehaviour
{
    [Header("References")]
    public DeleteManager deleteManager;
    public TMP_InputField inputID;

    public void OnDeletePressed()
    {
        if (!ValidateInput(out int id)) return;

        deleteManager.DeleteCharacter(id);
        Debug.Log($"Deleted Character ID: {id}");
        inputID.text = "";
    }

    private bool ValidateInput(out int id)
    {
        id = -1;
        if (inputID == null)
        {
            Debug.LogError("DeleteCharacterUI: Input field not assigned!");
            return false;
        }
        if (!int.TryParse(inputID.text, out id))
        {
            Debug.LogError("DeleteCharacterUI: Invalid ID!");
            return false;
        }
        return true;
    }
}
