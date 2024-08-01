using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Manager : MonoBehaviour
{
    public GameObject[] dialogueObjects; // Konuþma balonlarýný tutan dizi
    private int currentDialogueIndex = 0;

    void Start()
    {
        // Tüm konuþma balonlarýný baþta gizle
        foreach (var dialogueObject in dialogueObjects)
        {
            dialogueObject.SetActive(false);
        }

        // Ýlk diyaloðu göster
        ShowNextDialogue();
    }

    public void ShowNextDialogue()
    {
        // Önceki diyaloðu gizle
        if (currentDialogueIndex > 0)
        {
            dialogueObjects[currentDialogueIndex - 1].SetActive(false);
        }

        // Mevcut diyaloðu göster
        if (currentDialogueIndex < dialogueObjects.Length)
        {
            dialogueObjects[currentDialogueIndex].SetActive(true);
            currentDialogueIndex++;
        }
        else
        {
            Debug.Log("Tüm diyaloglar gösterildi.");
        }
    }

    // Bu metot, bir sonraki diyaloðu tetiklemek için kullanýlabilir
    public void OnDialogueButtonPressed()
    {
        ShowNextDialogue();
    }
}
