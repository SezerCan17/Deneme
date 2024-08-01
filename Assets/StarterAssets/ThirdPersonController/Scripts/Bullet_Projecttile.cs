using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Projecttile : MonoBehaviour
{
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    private Rigidbody Bulletrigidbody;

    private void Awake()
    {
        Bulletrigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float speed = 50f;
        Bulletrigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletTarget>() != null)
        {
            Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);


        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Vuruldu");
            other.GetComponent<Enemy>().GetHit(1);
            Destroy(gameObject);
        }

    }
}
