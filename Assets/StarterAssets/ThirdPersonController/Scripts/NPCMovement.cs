using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Transform pointA; // -1 noktas�
    public Transform pointB; // 1 noktas�
    public float speed = 1.5f; // Hareket h�z�

    private Transform currentTarget;
    private Transform otherTarget;

    void Start()
    {
        // Ba�lang��ta hedef olarak pointA'y� belirle
        currentTarget = pointA;
        otherTarget = pointB;
    }

    void Update()
    {
        // NPC'nin hedefe do�ru hareket etmesini sa�la
        MoveTowardsTarget();

        // E�er NPC hedefe �ok yak�nsa, hedefi de�i�tir
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            SwapTargets();
        }
    }

    void MoveTowardsTarget()
    {
        // NPC'nin hedefe do�ru y�n�n� �evir
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        transform.forward = direction;

        // NPC'nin hedefe do�ru hareket etmesini sa�la
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
    }

    void SwapTargets()
    {
        // Hedefleri de�i�tir
        Transform temp = currentTarget;
        currentTarget = otherTarget;
        otherTarget = temp;
    }
}
