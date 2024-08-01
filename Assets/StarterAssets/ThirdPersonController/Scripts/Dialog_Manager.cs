using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Manager : MonoBehaviour
{
    public GameObject[] dialogueObjects; // Konu�ma balonlar�n� tutan dizi
    private int currentDialogueIndex = 0;
    public bool isDialogueActive = false;

    void Start()
    {
        // T�m konu�ma balonlar�n� ba�ta gizle
        foreach (var dialogueObject in dialogueObjects)
        {
            dialogueObject.SetActive(false);
        }
    }

    public void ShowNextDialogue()
    {
        if (isDialogueActive)
        {
            // �nceki diyalo�u gizle
            if (currentDialogueIndex > 0)
            {
                dialogueObjects[currentDialogueIndex - 1].SetActive(false);
            }

            // Mevcut diyalo�u g�ster
            if (currentDialogueIndex < dialogueObjects.Length)
            {
                dialogueObjects[currentDialogueIndex].SetActive(true);
                currentDialogueIndex++;
            }
            else
            {
                Debug.Log("T�m diyaloglar g�sterildi.");
                isDialogueActive = false; // Diyaloglar bitti�inde durdur
            }
        }
    }

    public void StartDialogue()
    {
        currentDialogueIndex = 0;
        isDialogueActive = true;
        ShowNextDialogue();
    }

    // Bu metot, bir sonraki diyalo�u tetiklemek i�in kullan�labilir
    public void OnDialogueButtonPressed()
    {
        ShowNextDialogue();
    }
}
