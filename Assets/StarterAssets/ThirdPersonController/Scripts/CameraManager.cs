using Photon.Pun;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public PhotonView photonView;

    void Start()
    {
        if (!photonView.IsMine)
        {
            // E�er bu kamera bizim de�ilse, deaktif et
            gameObject.SetActive(false);
        }
    }
}
