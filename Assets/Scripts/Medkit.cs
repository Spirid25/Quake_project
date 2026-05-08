
using UnityEngine;

namespace Assets.Scripts
{
    internal class Medkit : MonoBehaviour
    {
        public GameObject player;
        public Health health;
        void Start()
        {
            health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

            Debug.Log(player);

            health = player.GetComponent<Health>();

            Debug.Log(health);
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                health.Heal(20f);
                Destroy(gameObject);
            }
        }
    }
}
