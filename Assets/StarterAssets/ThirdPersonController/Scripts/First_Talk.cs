using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First_Talk : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    public GameObject canvas5;
    public GameObject canvas6;
    public GameObject canvas7;
    public GameObject canvas8;
    public GameObject canvas9;
    public GameObject canvas10;
    private int currentIndex = 0;
    

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            canvas1.SetActive(true);
            canvas2.SetActive(true);
            currentIndex++;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.R))
        {
            if (currentIndex == 1)
            {
                canvas1.SetActive(false);
                canvas2.SetActive(false);
                canvas3.SetActive(true);
                canvas4.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 2)
            {
                canvas3.SetActive(false);
                canvas4.SetActive(false);
                canvas5.SetActive(true);
                canvas6.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 3)
            {
                canvas5.SetActive(false);
                canvas6.SetActive(false);
                canvas7.SetActive(true);
                canvas8.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 4)
            {
                canvas7.SetActive(false);
                canvas8.SetActive(false);
                canvas9.SetActive(true);
                canvas10.SetActive(true);
                currentIndex++;
            }
            else if (currentIndex == 5)
            {
                canvas9.SetActive(false);
                canvas10.SetActive(false);
                currentIndex++;
            }
        }
    }

    
}
