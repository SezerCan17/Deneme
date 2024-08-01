using UnityEngine;
using Photon.Pun;

public class DialogueTrigger : MonoBehaviourPun
{
    public Dialog_Manager dialogManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int playerID = other.GetComponent<PhotonView>().OwnerActorNr; // Oyuncunun ID'sini alýn
            photonView.RPC("PlayerInteractedRPC", RpcTarget.All, playerID);
        }
    }

    [PunRPC]
    public void PlayerInteractedRPC(int playerID)
    {
        dialogManager.PlayerInteracted(playerID);
    }
}
