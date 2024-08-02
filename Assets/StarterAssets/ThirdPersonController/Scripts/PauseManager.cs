using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0; // Oyunu durdur
        isPaused = true;
        // Ek olarak duraklatma men�s�n� g�stermek isterseniz, buraya kod ekleyebilirsiniz.
    }

    void ResumeGame()
    {
        Time.timeScale = 1; // Oyunu devam ettir
        isPaused = false;
        // Ek olarak duraklatma men�s�n� gizlemek isterseniz, buraya kod ekleyebilirsiniz.
    }
}
