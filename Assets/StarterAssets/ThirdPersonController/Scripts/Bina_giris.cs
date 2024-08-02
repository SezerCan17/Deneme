using UnityEngine;
using Photon.Pun;

public class Bina_Giris : MonoBehaviourPun
{
    public GameObject canvas18;
    public GameObject canvas18_2;
    public GameObject canvas19;
    public GameObject canvas19_2;
    public GameObject canvas20;
    public GameObject canvas20_2;
    public GameObject canvas21;
    public GameObject canvas21_2;

    public GameObject keypad;
   

    private bool isPlayerInTrigger = false;
    private int currentIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            canvas18.SetActive(true);
            canvas18_2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            keypad.SetActive(false);
            currentIndex = 0;
        }
    }

    private void Update()
    {
        
        if (isPlayerInTrigger && UnityEngine.Input.GetKeyDown(KeyCode.R))
        {

            if (currentIndex == 0)
            {
                canvas18.SetActive(false);
                canvas18_2.SetActive(false);
                canvas19.SetActive(true);
                canvas19_2.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 1)
            {
                canvas19.SetActive(false);
                canvas19_2.SetActive(false);
                canvas20.SetActive(true);
                canvas20_2.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 2)
            {
                canvas20.SetActive(false);
                canvas20_2.SetActive(false);
                canvas21.SetActive(true);
                canvas21_2.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 3)
            {
                canvas21.SetActive(false);
                canvas21_2.SetActive(false);
                keypad.SetActive(true);
                currentIndex++;
            }

        }
    }

}

