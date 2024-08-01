using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Manager : MonoBehaviour
{
    public GameObject[] dialogueObjects; // Konu�ma balonlar�n� tutan dizi
    private int currentDialogueIndex = 0;

    void Start()
    {
        // T�m konu�ma balonlar�n� ba�ta gizle
        foreach (var dialogueObject in dialogueObjects)
        {
            dialogueObject.SetActive(false);
        }

        // �lk diyalo�u g�ster
        ShowNextDialogue();
    }

    public void ShowNextDialogue()
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
        }
    }

    // Bu metot, bir sonraki diyalo�u tetiklemek i�in kullan�labilir
    public void OnDialogueButtonPressed()
    {
        ShowNextDialogue();
    }
}
