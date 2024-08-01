using Photon.Pun;
using UnityEngine;

public class Dialog_Manager : MonoBehaviourPun
{
    public GameObject[] player1DialogueObjects; // Oyuncu 1 için konuþma balonlarý
    public GameObject[] player2DialogueObjects; // Oyuncu 2 için konuþma balonlarý
    private int currentDialogueIndex = 0;
    private bool isDialogueActive = false;

    private bool player1Interacted = false;
    private bool player2Interacted = false;

    void Start()
    {
        // Tüm konuþma balonlarýný baþta gizle
        foreach (var dialogueObject in player1DialogueObjects)
        {
            dialogueObject.SetActive(false);
        }
        foreach (var dialogueObject in player2DialogueObjects)
        {
            dialogueObject.SetActive(false);
        }
        Debug.Log("Dialog_Manager baþlatýldý. Tüm konuþma balonlarý gizlendi.");
    }

    public void ShowNextDialogue()
    {
        if (isDialogueActive)
        {
            // Önceki diyaloðu gizle
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
                Debug.Log("Önceki diyaloðu gizledik.");
            }

            // Mevcut diyaloðu göster
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
                Debug.Log($"Diyalog gösteriliyor: {currentDialogueIndex}");
                currentDialogueIndex++;
            }
            else
            {
                Debug.Log("Tüm diyaloglar gösterildi.");
                isDialogueActive = false; // Diyaloglar bittiðinde durdur
                photonView.RPC("HideAllDialoguesRPC", RpcTarget.Others);
            }
        }
    }

    public void StartDialogue()
    {
        currentDialogueIndex = 0;
        isDialogueActive = true;
        Debug.Log("Diyalog baþlatýlýyor.");
        ShowNextDialogue();
        photonView.RPC("StartDialogueRPC", RpcTarget.Others);
    }

    [PunRPC]
    public void StartDialogueRPC()
    {
        currentDialogueIndex = 0;
        isDialogueActive = true;
        Debug.Log("Diyalog baþlatýlýyor (RPC).");
        ShowNextDialogue();
    }

    public void OnDialogueButtonPressed()
    {
        Debug.Log("Diyalog butonuna basýldý.");
        ShowNextDialogue();
        photonView.RPC("ShowNextDialogueRPC", RpcTarget.Others);
    }

    [PunRPC]
    public void ShowNextDialogueRPC()
    {
        Debug.Log("Diyalog gösteriliyor (RPC).");
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
        Debug.Log("Tüm diyaloglar gizlendi (RPC).");
    }

    public void PlayerInteracted(int playerID)
    {
        Debug.Log($"Oyuncu {playerID} etkileþimde bulundu.");
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
        Debug.Log("Etkileþimler sýfýrlandý.");
    }
}
