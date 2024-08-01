using UnityEngine;
using Photon.Pun;

public class DialogueTrigger : MonoBehaviourPun
{
    public GameObject canvas1;
    public GameObject canvas1_2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas1.SetActive(true);
            canvas1_2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas1.SetActive(false);
            canvas1_2.SetActive(false);
        }
    }
}
