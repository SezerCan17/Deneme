using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject canvas1; // UI ��esi
    public GameObject canvas2;
    public GameObject character; // Karakter GameObject'i
    
    //private Controller2 controllerScript; // Karakterin kontrol script'i

    void Start()
    {
        // Karakter GameObject'inden Controller2 script'ini al�n
        if (character != null)
        {
            //controllerScript = character.GetComponent<Controller2>();
        }
    }

    void Update()
    {
        // UI a��k m� kontrol edin
        if (canvas1.activeSelf || canvas2.activeSelf)
        {
            // Karakterin kontrol script'ini devre d��� b�rak
            //if (controllerScript != null)
            //{
            //    controllerScript.enabled = false;
            //}

            // Cursor'� g�r�n�r yap
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // Karakterin kontrol script'ini tekrar etkinle�tir
            //if (controllerScript != null)
            //{
            //    controllerScript.enabled = true;
            //}

            // Cursor'� gizle (iste�e ba�l�)
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // UI'yi a�mak i�in J tu�una basma i�lemi
        if (Input.GetKeyDown(KeyCode.J))
        {
            canvas1.SetActive(true);
            Cursor.visible = true;
        }

        // UI'yi kapatmak i�in H tu�una basma i�lemi
        if (Input.GetKeyDown(KeyCode.H))
        {
            canvas1.SetActive(false);
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            canvas2.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            canvas2.SetActive(false);
        }
    }
}
