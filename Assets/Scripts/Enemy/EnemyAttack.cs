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
        public float attackRate = 1f;
    }
}
