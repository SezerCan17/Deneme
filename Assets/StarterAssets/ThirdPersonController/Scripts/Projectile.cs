using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Vuruldu");
            other.GetComponent<Enemy>().GetHit(1);
            Destroy(gameObject);
        }
    }
}
