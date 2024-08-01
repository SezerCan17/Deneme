using UnityEngine;
using Photon.Pun;

public class CameraActivation : MonoBehaviourPun
{
    public GameObject camera;
    private void Update()
    {
        camera.SetActive(true);
    }
}
