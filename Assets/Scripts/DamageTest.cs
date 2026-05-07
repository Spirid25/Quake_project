using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    internal class DamageTest : MonoBehaviour
    {
        public Health health;

        void Start()
        {
            health = FindObjectOfType<Health>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q) && Time.timeScale > 0f)
            {
                Debug.Log("Take damage: 10");
                health.TakeDamage(10f);
            }
        }
    }
}
