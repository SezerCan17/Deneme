using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZamanMakinesi1 : MonoBehaviour
{
    public string position1Name = "Position1"; // Position1 GameObject'inin adý
    private GameObject position1;
    private bool geldi = false;

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
            }
        }
    }
}
