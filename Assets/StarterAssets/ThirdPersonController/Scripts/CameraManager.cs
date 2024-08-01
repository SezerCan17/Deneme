using Photon.Pun;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public PhotonView photonView;

    void Start()
    {
        if (!photonView.IsMine)
        {
            // Eðer bu kamera bizim deðilse, deaktif et
            gameObject.SetActive(false);
        }
    }
}
