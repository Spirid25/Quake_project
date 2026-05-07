
using UnityEngine;

namespace Assets.Scripts
{
    internal class Medkit : MonoBehaviour
    {
        public Health health;
        void Start()
        {
            health = FindObjectOfType<Health>();
        }
        void OnTriggerEnter(Collider other)
        {
                health.Heal(20f);
                Destroy(gameObject);
        }
    }
}
