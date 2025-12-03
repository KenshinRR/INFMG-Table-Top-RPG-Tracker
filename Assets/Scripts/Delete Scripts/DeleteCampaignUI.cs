using UnityEngine;
using TMPro;

public class DeleteCampaignUI : MonoBehaviour
{
    [Header("References")]
    public DeleteManager deleteManager;
    public TMP_InputField inputID;

    public void OnDeletePressed()
    {
        if (!ValidateInput(out int id)) return;

        deleteManager.DeleteCampaign(id);
        Debug.Log($"Deleted Campaign ID: {id}");
        inputID.text = "";
    }

    private bool ValidateInput(out int id)
    {
        id = -1;
        if (inputID == null)
        {
            Debug.LogError("DeleteCampaignUI: Input field not assigned!");
            return false;
        }
        if (!int.TryParse(inputID.text, out id))
        {
            Debug.LogError("DeleteCampaignUI: Invalid ID!");
            return false;
        }
        return true;
    }
}
