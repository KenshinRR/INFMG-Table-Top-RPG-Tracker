using UnityEngine;
using TMPro;

public class DeleteItemUI : MonoBehaviour
{
    [Header("References")]
    public DeleteManager deleteManager;
    public TMP_InputField inputID;

    public void OnDeletePressed()
    {
        if (!ValidateInput(out int id)) return;

        deleteManager.DeleteItem(id);
        Debug.Log($"Deleted Item ID: {id}");
        inputID.text = "";
    }

    private bool ValidateInput(out int id)
    {
        id = -1;
        if (inputID == null)
        {
            Debug.LogError("DeleteItemUI: Input field not assigned!");
            return false;
        }
        if (!int.TryParse(inputID.text, out id))
        {
            Debug.LogError("DeleteItemUI: Invalid ID!");
            return false;
        }
        return true;
    }
}
