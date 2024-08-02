using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;


    private void Awake()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            canvas1.SetActive(false);
            canvas2.SetActive(false);
        }
    }
}
