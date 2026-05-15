using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    internal class EnemyAI : MonoBehaviour
    {
        private enum State {
            Idle,
            Chase,
            Attack
        }

        public float aggroDistance = 15f;
        public float attackDistance = 2f;

        private Transform eyeTransform;
        private Transform playerTransform;
        public EnemyFOV fov;
        public EnemyMovement move;
        public EnemyAttack attack;

        private State currentState;

        private void Update()
        {
            if (fov.canSeePlayer == true)
            {
                move.MoveToPlayer();
                attack.Attack();
            }
        }
        /*
        void Update()
        {
            switch (currentState)
            {
                case State.Idle:
                    if (dist < aggroDistance)
                        currentState = State.Chase;
                    break;

                case State.Chase:
                    if (dist < attackDistance)
                        currentState = State.Attack;
                    else if (dist > aggroDistance)
                        currentState = State.Idle;
                    break;

                case State.Attack:
                    if (dist > attackDistance)
                        currentState = State.Chase;
                    break;
            }
        }*/
    }
}