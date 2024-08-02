using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interact : MonoBehaviour
{

    public GameObject key_canvas1;
    public GameObject key_canvas2;
    private bool isPlayerInTrigger = false;

    public Animator animator;
   

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
            key_canvas1.SetActive(false);
            key_canvas2.SetActive(false);
            animator.SetBool("door", true);
        }
        
        
    }
}
