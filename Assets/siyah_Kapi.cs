using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siyah_Kapi : MonoBehaviour
{
    public Keypad keypad;
    public Animator animator;

    private void Update()
    {
        if(keypad.cevap==true)
        {
            animator.SetBool("siyah", true);
        }
    }
}
