using UnityEngine;
using Photon.Pun;

public class PlayerCameraActivator : MonoBehaviourPun
{
    public GameObject rightCamera;
    public GameObject leftCamera;

    void Start()
    {
        if (photonView.IsMine)
        {
            ActivateCameras();
        }
    }

    void ActivateCameras()
    {
        if (photonView.IsMine)
        {
            if (rightCamera != null)
            {
                rightCamera.SetActive(true);
            }
            else
            {
                Debug.LogError("RightCamera bulunamadý!");
            }

            if (leftCamera != null)
            {
                leftCamera.SetActive(true);
            }
            else
            {
                Debug.LogError("LeftCamera bulunamadý!");
            }
        }
    }
}
