using Photon.Pun;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviourPun
{
    public GameObject playerCamera;

    private void Start()
    {
        if (photonView.IsMine)
        {
            playerCamera.SetActive(true);
        }
        else
        {
            playerCamera.SetActive(false);
        }
    }
}
