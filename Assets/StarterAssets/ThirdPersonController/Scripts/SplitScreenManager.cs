using UnityEngine;

public class SplitScreenManager : MonoBehaviour
{
    public string camera1Name = "RightCamera"; // Sa�daki kamera ad�
    public string camera2Name = "LeftCamera";  // Soldaki kamera ad�

    private Camera camera1;
    private Camera camera2;
    private CameraFollow camera1Follow;
    private CameraFollow camera2Follow;

    void Start()
    {
        // Kameralar� isimlerine g�re bulma
        camera1 = GameObject.Find(camera1Name)?.GetComponent<Camera>();
        camera2 = GameObject.Find(camera2Name)?.GetComponent<Camera>();

        if (camera1 == null || camera2 == null)
        {
            Debug.LogError("Kameralar sahnede bulunamad�!");
            return;
        }

        // Kameralar�n ekran alanlar�n� ayarla
        camera1.rect = new Rect(0.5f, 0, 0.5f, 1); // Sa�daki kamera ekran�n sa� yar�s�n� kaplar
        camera2.rect = new Rect(0, 0, 0.5f, 1); // Soldaki kamera ekran�n sol yar�s�n� kaplar

        // KameraFollow scriptlerini bulma
        camera1Follow = camera1.GetComponent<CameraFollow>();
        camera2Follow = camera2.GetComponent<CameraFollow>();

        if (camera1Follow == null || camera2Follow == null)
        {
            Debug.LogError("CameraFollow scriptleri kameralarla ili�kilendirilmedi!");
            return;
        }
    }

    public void SetPlayerInstances(GameObject player1, GameObject player2)
    {
        if (camera1Follow != null)
        {
            // Sa�daki kamera i�in oyuncu 1 ayarlar�n� yap
            camera1Follow.SetTarget(player1.transform, player2.transform);
        }

        if (camera2Follow != null)
        {
            // Soldaki kamera i�in oyuncu 2 ayarlar�n� yap
            camera2Follow.SetTarget(player2.transform, player1.transform);
        }
    }
}
