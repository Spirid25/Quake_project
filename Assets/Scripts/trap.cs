using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    internal class trap : MonoBehaviour
    {
        public GameObject wall;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("You have been caught in a trap!");
                Destroy(wall);
            }
        }
    }
}
