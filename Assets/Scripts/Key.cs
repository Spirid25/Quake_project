using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    internal class Key : MonoBehaviour
    {
        public Inventory inventory;
        private void OnTriggerEnter(Collider other)
        {
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioClip>());
            inventory.hasBlueKey = true;
            Destroy(gameObject);
            Debug.Log("You have picked up the blue key!");
        }
    }
}