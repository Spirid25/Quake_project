using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    internal class Door : MonoBehaviour
    {
        public Inventory inventory;
        private void OnTriggerEnter(Collider other)
        {
                if (inventory.hasBlueKey)
                {
                    Debug.Log("You have opened the door!");
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("You need a blue key to open this door.");
                }
        }
    }
}
