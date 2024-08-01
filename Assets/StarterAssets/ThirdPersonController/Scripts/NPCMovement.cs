using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform pointA; // -1 noktasý
    public Transform pointB; // 1 noktasý
    public float speed = 1.5f; // Hareket hýzý

    private Transform currentTarget;
    private Transform otherTarget;

    void Start()
    {
        // Baþlangýçta hedef olarak pointA'yý belirle
        currentTarget = pointA;
        otherTarget = pointB;
    }

    void Update()
    {
        // NPC'nin hedefe doðru hareket etmesini saðla
        MoveTowardsTarget();

        // Eðer NPC hedefe çok yakýnsa, hedefi deðiþtir
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            SwapTargets();
        }
    }

    void MoveTowardsTarget()
    {
        // NPC'nin hedefe doðru yönünü çevir
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        transform.forward = direction;

        // NPC'nin hedefe doðru hareket etmesini saðla
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
    }

    void SwapTargets()
    {
        // Hedefleri deðiþtir
        Transform temp = currentTarget;
        currentTarget = otherTarget;
        otherTarget = temp;
    }
}
