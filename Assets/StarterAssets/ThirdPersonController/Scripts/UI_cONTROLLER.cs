using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject canvas1; // UI öðesi
    public GameObject canvas2;
    public GameObject character; // Karakter GameObject'i
    
    //private Controller2 controllerScript; // Karakterin kontrol script'i

    void Start()
    {
        // Karakter GameObject'inden Controller2 script'ini alýn
        if (character != null)
        {
            //controllerScript = character.GetComponent<Controller2>();
        }
    }

    void Update()
    {
        // UI açýk mý kontrol edin
        if (canvas1.activeSelf || canvas2.activeSelf)
        {
            // Karakterin kontrol script'ini devre dýþý býrak
            //if (controllerScript != null)
            //{
            //    controllerScript.enabled = false;
            //}

            // Cursor'ý görünür yap
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // Karakterin kontrol script'ini tekrar etkinleþtir
            //if (controllerScript != null)
            //{
            //    controllerScript.enabled = true;
            //}

            // Cursor'ý gizle (isteðe baðlý)
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // UI'yi açmak için J tuþuna basma iþlemi
        if (Input.GetKeyDown(KeyCode.J))
        {
            canvas1.SetActive(true);
            Cursor.visible = true;
        }

        // UI'yi kapatmak için H tuþuna basma iþlemi
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
