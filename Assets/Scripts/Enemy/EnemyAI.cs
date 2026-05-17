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

        private enum EnemyType
        {
            Melee,
            Ranged,
            Flying
        }

        public float aggroDistance = 15f;
        public float attackDistance = 2f;

        private Transform eyeTransform;
        private Transform playerTransform;
        public EnemyFOV fov;
        public EnemyMovement move;
        public EnemyAttack attack;

        private State currentState;

        void Update()
        {
            switch (currentState)
            {
                case State.Idle:
                    if (fov.canSeePlayer == true)
                    {
                        move.MoveToPlayer();
                        attack.Attack();
                        currentState = State.Chase;
                    }
                    break;
                case State.Chase:
                    if (fov.canSeePlayer == true)
                    {
                        move.MoveToPlayer();
                        attack.Attack();
                        currentState = State.Chase;
                    }
                    /*if (dist < attackDistance)
                        currentState = State.Attack;
                    else if (dist > aggroDistance)
                        currentState = State.Idle;*/
                    break;

                case State.Attack:
                    if (fov.canSeePlayer == true)
                    {
                        move.MoveToPlayer();
                        attack.Attack();
                        currentState = State.Chase;
                    }
                    /*if (dist > attackDistance)
                        currentState = State.Chase;*/
                    break;
            }
        }
    }
}