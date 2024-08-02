using UnityEngine;
using Photon.Pun;

public class Bina_ZamanMakinesý_Dialog : MonoBehaviourPun
{
    public GameObject canvas22;
    public GameObject canvas22_2;
    public GameObject canvas23;
    public GameObject canvas23_2;
    public GameObject canvas24;
    public GameObject canvas24_2;
    


    private bool isPlayerInTrigger = false;
    private int currentIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            canvas22.SetActive(true);
            canvas22_2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            currentIndex = 0;
        }
    }

    private void Update()
    {

        if (isPlayerInTrigger && UnityEngine.Input.GetKeyDown(KeyCode.R))
        {

            if (currentIndex == 0)
            {
                canvas22.SetActive(false);
                canvas22_2.SetActive(false);
                canvas23.SetActive(true);
                canvas23_2.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 1)
            {
                canvas23.SetActive(false);
                canvas23_2.SetActive(false);
                canvas24.SetActive(true);
                canvas24_2.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 2)
            {
                canvas24.SetActive(false);
                canvas24_2.SetActive(false);
                currentIndex++;
            }
            

        }
    }

}

