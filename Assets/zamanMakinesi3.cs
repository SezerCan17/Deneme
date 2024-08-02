using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zamanMakinesi3 : MonoBehaviour
{
    public string position1Name = "Position3"; // Position1 GameObject'inin adý
    private GameObject position1;
    private bool geldi = false;

    public GameObject canvas2;
    public GameObject canvas2_2;

    private void Start()
    {
        // Sahne yüklendiðinde position1 GameObject'ini bulun
        position1 = GameObject.Find(position1Name);
        if (position1 == null)
        {
            Debug.LogError("Position1 GameObject bulunamadý.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Makine1"))
        {
            geldi = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Makine1"))
        {
            geldi = false;
        }
    }

    private void Update()
    {
        if (geldi && Input.GetKeyDown(KeyCode.E))
        {
            if (position1 != null)
            {
                Debug.Log("Position1 konumu: " + position1.transform.position);
                transform.position = position1.transform.position;
                canvas2.SetActive(true);
                canvas2_2.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            canvas2.SetActive(false);
            canvas2_2.SetActive(false);
        }
    }
}
