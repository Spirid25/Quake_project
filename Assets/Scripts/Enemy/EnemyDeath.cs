using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    void Start()
    {
        GetComponent<Health>().onDeath += Die;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}