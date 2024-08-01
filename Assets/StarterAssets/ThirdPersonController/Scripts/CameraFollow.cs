using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerFollowTarget; // Kameran�n takip etti�i oyuncu
    public Transform playerSeeTarget;    // Kameran�n g�rmesini istedi�i di�er oyuncu

    private Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (camera == null)
            return;

        // Kameran�n takip etti�i oyuncu
        if (playerFollowTarget != null)
        {
            Vector3 targetPosition = playerFollowTarget.position;
            targetPosition.z = camera.transform.position.z; // Kamera pozisyonunun z koordinat�n� koru
            camera.transform.position = targetPosition;
            camera.transform.LookAt(playerFollowTarget);
        }

        // Di�er oyuncuyu ekranda g�stermek i�in
        if (playerSeeTarget != null)
        {
            // Di�er oyuncunun konumunu ekran�n do�ru yerinde g�stermek i�in
        }
    }

    public void SetTarget(Transform followTarget, Transform seeTarget)
    {
        playerFollowTarget = followTarget;
        playerSeeTarget = seeTarget;
    }
}
