
using UnityEngine;

namespace Assets.Scripts
{
    internal class Medkit : MonoBehaviour
    {
        public GameObject player;
        public Health health;
        float currHealth;
        void Start()
        {
            health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

            Debug.Log(player);

            health = player.GetComponent<Health>();

            Debug.Log(health);
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && health.CurrentHP < 100)
            {
                GetComponent<AudioSource>().Play();
                health.Heal(20f);
                Destroy(gameObject, 0.4f);
            }
        }
    }
}
