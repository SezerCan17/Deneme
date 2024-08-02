//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Silah_Toplama : MonoBehaviour
//{
//    private bool isPlayerInTrigger = false;
//    private TPS_ShooterController shooterController;
//    private MeshRenderer meshRenderer;
//    public GameObject silah;

//    private void Start()
//    {
//        shooterController = FindObjectOfType<TPS_ShooterController>();
//        if (shooterController == null)
//        {
//            Debug.LogError("TPS_ShooterController bulunamad�!");
//        }

//        meshRenderer = GetComponent<MeshRenderer>();
//        if (meshRenderer == null)
//        {
//            Debug.LogError("MeshRenderer bile�eni bulunamad�!");
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            Debug.Log("Player trigger i�ine girdi");
//            isPlayerInTrigger = true;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            Debug.Log("Player trigger d���na ��kt�");
//            isPlayerInTrigger = false;
//        }
//    }

//    private void Update()
//    {
//        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
//        {
//            Debug.Log("E tu�una bas�ld� ve silah al�n�yor");
//            shooterController.HasGun = true; // Silah al�nd���n� belirt
//            Debug.Log("HasGun set edildi: " + shooterController.HasGun);
//            silah.SetActive(false);
//            Debug.Log("Silah g�r�nmez yap�ld�");
//        }
//    }
//}
