using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerFollowTarget; // Kameranýn takip ettiði oyuncu
    public Transform playerSeeTarget;    // Kameranýn görmesini istediði diðer oyuncu

    private Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (camera == null)
            return;

        // Kameranýn takip ettiði oyuncu
        if (playerFollowTarget != null)
        {
            Vector3 targetPosition = playerFollowTarget.position;
            targetPosition.z = camera.transform.position.z; // Kamera pozisyonunun z koordinatýný koru
            camera.transform.position = targetPosition;
            camera.transform.LookAt(playerFollowTarget);
        }

        // Diðer oyuncuyu ekranda göstermek için
        if (playerSeeTarget != null)
        {
            // Diðer oyuncunun konumunu ekranýn doðru yerinde göstermek için
        }
    }

    public void SetTarget(Transform followTarget, Transform seeTarget)
    {
        playerFollowTarget = followTarget;
        playerSeeTarget = seeTarget;
    }
}
