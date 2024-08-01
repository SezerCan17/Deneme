using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialog_Manager dialogManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogManager.StartDialogue();
        }
    }
}
