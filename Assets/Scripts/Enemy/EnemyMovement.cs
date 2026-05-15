using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public float speed = 3f;
        public float stopDistance = 3f;
        public float rotationSpeed = 3f;
        public Transform player;

        public void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

        }
        public void MoveToPlayer()
        {
            if (Vector3.Distance(transform.position, player.position) > stopDistance)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                direction.y = 0; // Ignore vertical component
                transform.position += direction * speed * Time.deltaTime;
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
