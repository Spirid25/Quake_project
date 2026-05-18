using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    void Start()
    {
        GetComponent<Health>().onDeath += Die;
    }

    void Die()
    {
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 0.4f);
    }
}