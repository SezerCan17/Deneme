using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Manager : MonoBehaviour
{
    public GameObject[] dialogueObjects; // Konuþma balonlarýný tutan dizi
    private int currentDialogueIndex = 0;
    public bool isDialogueActive = false;

    void Start()
    {
        // Tüm konuþma balonlarýný baþta gizle
        foreach (var dialogueObject in dialogueObjects)
        {
            dialogueObject.SetActive(false);
        }
    }

    public void ShowNextDialogue()
    {
        if (isDialogueActive)
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
                isDialogueActive = false; // Diyaloglar bittiðinde durdur
            }
        }
    }

    public void StartDialogue()
    {
        currentDialogueIndex = 0;
        isDialogueActive = true;
        ShowNextDialogue();
    }

    // Bu metot, bir sonraki diyaloðu tetiklemek için kullanýlabilir
    public void OnDialogueButtonPressed()
    {
        ShowNextDialogue();
    }
}
