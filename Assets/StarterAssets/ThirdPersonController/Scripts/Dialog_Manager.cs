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
        Debug.Log("Dialog_Manager ba�lat�ld�. T�m konu�ma balonlar� gizlendi.");
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
                Debug.Log("�nceki diyalo�u gizledik.");
            }

            // Mevcut diyalo�u g�ster
            if (currentDialogueIndex < player1DialogueObjects.Length)
            {
                foreach (var dialogueObject in player1DialogueObjects)
                {
                    dialogueObject.SetActive(true);
                }
                foreach (var dialogueObject in player2DialogueObjects)
                {
                    dialogueObject.SetActive(true);
                }
                Debug.Log($"Diyalog g�steriliyor: {currentDialogueIndex}");
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
        Debug.Log("Diyalog ba�lat�l�yor.");
        ShowNextDialogue();
        photonView.RPC("StartDialogueRPC", RpcTarget.Others);
    }

    [PunRPC]
    public void StartDialogueRPC()
    {
        currentDialogueIndex = 0;
        isDialogueActive = true;
        Debug.Log("Diyalog ba�lat�l�yor (RPC).");
        ShowNextDialogue();
    }

    public void OnDialogueButtonPressed()
    {
        Debug.Log("Diyalog butonuna bas�ld�.");
        ShowNextDialogue();
        photonView.RPC("ShowNextDialogueRPC", RpcTarget.Others);
    }

    [PunRPC]
    public void ShowNextDialogueRPC()
    {
        Debug.Log("Diyalog g�steriliyor (RPC).");
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
        Debug.Log("T�m diyaloglar gizlendi (RPC).");
    }

    public void PlayerInteracted(int playerID)
    {
        Debug.Log($"Oyuncu {playerID} etkile�imde bulundu.");
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
        Debug.Log("Etkile�imler s�f�rland�.");
    }
}
