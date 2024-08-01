using UnityEngine;

public class PlatformPuzzle : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;
    public bool puzzle = false; // Bu deðiþken platformun hareket edip etmeyeceðini belirler

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            puzzle = true;
        }
        if (puzzle) // Eðer puzzle true ise platform hareket eder
        {
            Vector3 target = endPoint.position; // Platformu sadece endPoint noktasýna götür
            platform.position = Vector3.Lerp(platform.position, target, speed * Time.deltaTime);

            float distance = (target - platform.position).magnitude;

            if (distance <= 0.1f)
            {
                puzzle = false; // Hedefe ulaþýldýðýnda puzzle'ý durdur
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.position, startPoint.position);
            Gizmos.DrawLine(platform.position, endPoint.position);
        }
    }
}
