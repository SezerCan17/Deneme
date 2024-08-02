using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silah_Toplama : MonoBehaviour
{
    
    private bool isPlayerInTrigger = false;
    


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

        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }


    }
}
