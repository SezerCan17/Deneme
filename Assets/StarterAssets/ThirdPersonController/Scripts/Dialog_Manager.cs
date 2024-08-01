using Photon.Pun;
using UnityEngine;

public class Dialog_Manager : MonoBehaviourPun
{
    public GameObject[] player1DialogueObjects; // Oyuncu 1 i�in konu�ma balonlar�
    public GameObject[] player2DialogueObjects; // Oyuncu 2 i�in konu�ma balonlar�
    private int currentDialogueIndex = 0;
    private bool isDialogueActive = false;

    private bool player1Interacted = false;
    private bool player2Interacted = false;

    void Start()
    {
        // T�m konu�ma balonlar�n� ba�ta gizle
        foreach (var dialogueObject in player1DialogueObjects)
        {
            dialogueObject.SetActive(false);
        }
        foreach (var dialogueObject in player2DialogueObjects)
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
                foreach (var dialogueObject in player1DialogueObjects)
                {
                    dialogueObject.SetActive(false);
                }
                foreach (var dialogueObject in player2DialogueObjects)
                {
                    dialogueObject.SetActive(false);
                }
            }

            // Mevcut diyalo�u g�ster
            if (currentDialogueIndex < player1DialogueObjects.Length)
            {
                player1DialogueObjects[currentDialogueIndex].SetActive(true);
                player2DialogueObjects[currentDialogueIndex].SetActive(true);
                currentDialogueIndex++;
            }
            else
            {
                Debug.Log("T�m diyaloglar g�sterildi.");
                isDialogueActive = false; // Diyaloglar bitti�inde durdur
                photonView.RPC("HideAllDialoguesRPC", RpcTarget.Others);
            }
        }
    }

    public void StartDialogue()
    {
        currentDialogueIndex = 0;
        isDialogueActive = true;
        ShowNextDialogue();
        photonView.RPC("StartDialogueRPC", RpcTarget.Others);
    }

    [PunRPC]
    public void StartDialogueRPC()
    {
        currentDialogueIndex = 0;
        isDialogueActive = true;
        ShowNextDialogue();
    }

    public void OnDialogueButtonPressed()
    {
        ShowNextDialogue();
        photonView.RPC("ShowNextDialogueRPC", RpcTarget.Others);
    }

    [PunRPC]
    public void ShowNextDialogueRPC()
    {
        ShowNextDialogue();
    }

    [PunRPC]
    public void HideAllDialoguesRPC()
    {
        foreach (var dialogueObject in player1DialogueObjects)
        {
            dialogueObject.SetActive(false);
        }
        foreach (var dialogueObject in player2DialogueObjects)
        {
            dialogueObject.SetActive(false);
        }
    }

    public void PlayerInteracted(int playerID)
    {
        if (playerID == 1)
        {
            player1Interacted = true;
        }
        else if (playerID == 2)
        {
            player2Interacted = true;
        }

        if (player1Interacted && player2Interacted)
        {
            StartDialogue();
        }
    }

    public void ResetInteractions()
    {
        player1Interacted = false;
        player2Interacted = false;
    }
}
