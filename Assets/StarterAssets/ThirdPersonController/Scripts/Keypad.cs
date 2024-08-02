using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{
    public TMP_InputField charHolder;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button0;
    public GameObject clearButton;
    public GameObject enterButton;

    public GameObject canvas;

    public Animator solAnimator;
    public bool cevap=false;

   
    public float speed = 1.5f;
    private bool hasReachedEndPoint = false;

    public void b1() => AddCharacter("1");
    public void b2() => AddCharacter("2");
    public void b3() => AddCharacter("3");
    public void b4() => AddCharacter("4");
    public void b5() => AddCharacter("5");
    public void b6() => AddCharacter("6");
    public void b7() => AddCharacter("7");
    public void b8() => AddCharacter("8");
    public void b9() => AddCharacter("9");
    public void b0() => AddCharacter("0");

    private void AddCharacter(string character)
    {
        charHolder.text += character;
    }

    public void clearEvent()
    {
        charHolder.text = string.Empty;
    }

    public void enterEvent()
    {
        if (charHolder.text == "190324")
        {
            cevap = true;
            canvas.SetActive(false);
            Debug.Log("Doðru");

        }
        else
        {
            Debug.Log("Hatalý");
            cevap = false;
        }
    }


    


}
