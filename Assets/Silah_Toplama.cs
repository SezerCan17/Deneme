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
//            Debug.LogError("TPS_ShooterController bulunamadý!");
//        }

//        meshRenderer = GetComponent<MeshRenderer>();
//        if (meshRenderer == null)
//        {
//            Debug.LogError("MeshRenderer bileþeni bulunamadý!");
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            Debug.Log("Player trigger içine girdi");
//            isPlayerInTrigger = true;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            Debug.Log("Player trigger dýþýna çýktý");
//            isPlayerInTrigger = false;
//        }
//    }

//    private void Update()
//    {
//        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
//        {
//            Debug.Log("E tuþuna basýldý ve silah alýnýyor");
//            shooterController.HasGun = true; // Silah alýndýðýný belirt
//            Debug.Log("HasGun set edildi: " + shooterController.HasGun);
//            silah.SetActive(false);
//            Debug.Log("Silah görünmez yapýldý");
//        }
//    }
//}
