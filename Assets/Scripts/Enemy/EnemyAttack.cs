using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    internal class EnemyAttack : MonoBehaviour
    {
        public float damage = 10f;
        public float cooldown = 1f;
        public float range = 3f;
        public float attackRate = 0.1f;
        public bool canAttack = true;
        public Transform eyeTransform;
        public void Attack()
        {
            if (Time.time >= cooldown && canAttack == true)
            {
                canAttack = false;
                if (Physics.Raycast(eyeTransform.position, transform.forward, out RaycastHit hit, range))
                {
                    Health hp = hit.collider.GetComponentInParent<Health>();
                    if (hp != null)
                    {
                        hp.TakeDamage(damage);
                    }
                }
                StartCoroutine(ResetAttack());
            }
        }

        private System.Collections.IEnumerator ResetAttack()
        {
            yield return new WaitForSeconds(cooldown);
            canAttack = true;
        }
    }
}
