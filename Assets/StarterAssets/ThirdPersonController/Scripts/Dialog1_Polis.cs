using UnityEngine;
using Photon.Pun;

public class Dialog1_Polis : MonoBehaviourPun
{
    public GameObject canvas11;
    public GameObject canvas11_2;
    public GameObject canvas12;
    public GameObject canvas12_2;
    public GameObject canvas13;
    public GameObject canvas13_2;
    public GameObject canvas14;
    public GameObject canvas14_2;
    public GameObject canvas15;
    public GameObject canvas15_2;
    public GameObject canvas16;
    public GameObject canvas16_2;
    public GameObject canvas17;
    public GameObject canvas17_2;

    public GameObject Bilmece;
    public bool cevap=false;

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
        if (isPlayerInTrigger && UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            if (currentIndex == 0)
            {
                canvas11.SetActive(true);
                canvas11_2.SetActive(true);

                currentIndex++;
            }
        }
        if (isPlayerInTrigger && UnityEngine.Input.GetKeyDown(KeyCode.R))
        {

            if (currentIndex == 1)
            {
                canvas11.SetActive(false);
                canvas11_2.SetActive(false);
                canvas12.SetActive(true);
                canvas12_2.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 2)
            {
                canvas12.SetActive(false);
                canvas12_2.SetActive(false);
                canvas13.SetActive(true);
                canvas13_2.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 3)
            {
                canvas13.SetActive(false);
                canvas13_2.SetActive(false);
                canvas14.SetActive(true);
                canvas14_2.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 4)
            {
                canvas14.SetActive(false);
                canvas14_2.SetActive(false);
                canvas15.SetActive(true);
                canvas15_2.SetActive(true);
                currentIndex++;
            }
            
        }

        if(currentIndex == 5)
        {
            Bilmece.SetActive(true);
        }

        if (currentIndex == 6 && cevap)
        {
            canvas16.SetActive(true);
            canvas16_2.SetActive(true);
            currentIndex++;
        }
        else if (currentIndex == 7)
        {
            canvas16.SetActive(false);
            canvas16_2.SetActive(false);
            canvas17.SetActive(true);
            canvas17_2.SetActive(true);
            currentIndex++;
        }
        else if(currentIndex == 8)
        {
            canvas17.SetActive(false);
            canvas17_2.SetActive(false);
            currentIndex++;
        }

    }

    public void DogruCevap()
    {
        cevap = true;
        canvas15.SetActive(false);
        canvas15_2.SetActive(false);
        currentIndex++;
        Bilmece.SetActive(false);
    }

    public void YanlisCevap()
    {
        cevap = false;
    }
}
