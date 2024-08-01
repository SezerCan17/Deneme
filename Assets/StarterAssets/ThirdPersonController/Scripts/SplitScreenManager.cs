using UnityEngine;

public class SplitScreenManager : MonoBehaviour
{
    public string camera1Name = "RightCamera"; // Saðdaki kamera adý
    public string camera2Name = "LeftCamera";  // Soldaki kamera adý

    private Camera camera1;
    private Camera camera2;
    private CameraFollow camera1Follow;
    private CameraFollow camera2Follow;

    void Start()
    {
        // Kameralarý isimlerine göre bulma
        camera1 = GameObject.Find(camera1Name)?.GetComponent<Camera>();
        camera2 = GameObject.Find(camera2Name)?.GetComponent<Camera>();

        if (camera1 == null || camera2 == null)
        {
            Debug.LogError("Kameralar sahnede bulunamadý!");
            return;
        }

        // Kameralarýn ekran alanlarýný ayarla
        camera1.rect = new Rect(0.5f, 0, 0.5f, 1); // Saðdaki kamera ekranýn sað yarýsýný kaplar
        camera2.rect = new Rect(0, 0, 0.5f, 1); // Soldaki kamera ekranýn sol yarýsýný kaplar

        // KameraFollow scriptlerini bulma
        camera1Follow = camera1.GetComponent<CameraFollow>();
        camera2Follow = camera2.GetComponent<CameraFollow>();

        if (camera1Follow == null || camera2Follow == null)
        {
            Debug.LogError("CameraFollow scriptleri kameralarla iliþkilendirilmedi!");
            return;
        }
    }

    public void SetPlayerInstances(GameObject player1, GameObject player2)
    {
        if (camera1Follow != null)
        {
            // Saðdaki kamera için oyuncu 1 ayarlarýný yap
            camera1Follow.SetTarget(player1.transform, player2.transform);
        }

        if (camera2Follow != null)
        {
            // Soldaki kamera için oyuncu 2 ayarlarýný yap
            camera2Follow.SetTarget(player2.transform, player1.transform);
        }
    }
}
