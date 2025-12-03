using UnityEngine;
using TMPro;

public class DeleteAbilitiesUI : MonoBehaviour
{
    [Header("References")]
    public DeleteManager deleteManager;
    public TMP_InputField inputID;

    public void OnDeletePressed()
    {
        if (!ValidateInput(out int id)) return;

        deleteManager.DeleteAbility(id);
        Debug.Log($"Deleted Ability (Action) ID: {id}");
        inputID.text = "";
    }

    private bool ValidateInput(out int id)
    {
        id = -1;
        if (inputID == null)
        {
            Debug.LogError("DeleteAbilitiesUI: Input field not assigned!");
            return false;
        }
        if (!int.TryParse(inputID.text, out id))
        {
            Debug.LogError("DeleteAbilitiesUI: Invalid ID!");
            return false;
        }
        return true;
    }
}
