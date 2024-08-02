using UnityEngine;
using Photon.Pun;

public class DialogueTrigger : MonoBehaviourPun
{
    public GameObject canvas6;
    public GameObject canvas6_2;
    public GameObject canvas7;
    public GameObject canvas7_2;
    public GameObject canvas8;
    public GameObject canvas8_2;
    public GameObject canvas9;
    public GameObject canvas9_2;
    public GameObject canvas10;
    public GameObject canvas10_2;
    public GameObject KeyImage1;
    public GameObject KeyImage2;

    private bool isPlayerInTrigger = false;
    private int currentIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
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
        if(isPlayerInTrigger && UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            if (currentIndex == 0)
            {
                canvas6.SetActive(true);
                canvas6_2.SetActive(true);

                currentIndex++;
            }
        }
        if (isPlayerInTrigger && UnityEngine.Input.GetKeyDown(KeyCode.R))
        {
            
            if (currentIndex == 1)
            {
                canvas6.SetActive(false);
                canvas6_2.SetActive(false);
                canvas7.SetActive(true);
                canvas7_2.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 2)
            {
                canvas7.SetActive(false);
                canvas7_2.SetActive(false);
                canvas8.SetActive(true);
                canvas8_2.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 3)
            {
                canvas8.SetActive(false);
                canvas8_2.SetActive(false);
                canvas9.SetActive(true);
                canvas9_2.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 4)
            {
                canvas9.SetActive(false);
                canvas9_2.SetActive(false);
                canvas10.SetActive(true);
                canvas10_2.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 5)
            {
                canvas10.SetActive(false);
                canvas10_2.SetActive(false);
                KeyImage1.SetActive(true);
                KeyImage2.SetActive(true);
                currentIndex++;
            }
        }
    }
}
