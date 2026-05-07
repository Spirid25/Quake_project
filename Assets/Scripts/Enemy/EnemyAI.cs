using Assets.Scripts;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum State { Idle, Chase, Attack }

    float attackTimer;
    public Health pHealth;
    public float damage = 10f;
    public int attackCooldown = 1;

    public float speed = 4f;
    public float rotationSpeed = 8f;
    public float aggroDistance = 15f;
    public float attackDistance = 2f;
    public float stopDistance = 1f;
    Transform player;
    Rigidbody rb;

    State currentState;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        currentState = State.Idle;
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;

        float dist = Vector3.Distance(transform.position, player.position);

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
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector3 dir = (player.position - transform.position);
        dir.y = 0;

        // Плавный поворот
        Quaternion targetRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRot,
            rotationSpeed * Time.fixedDeltaTime
        );

        float dist = Vector3.Distance(transform.position, player.position);

        // Движение только в состоянии Chase
        if (currentState == State.Chase)
        {
            if (dist > stopDistance)
            {
                rb.MovePosition(
                    rb.position + transform.forward * speed * Time.fixedDeltaTime
                );
            }
        }
        if (currentState == State.Attack)
        {
            if (attackTimer > 0f) return;

            attackTimer = attackCooldown;
            if (pHealth != null)
            {
                pHealth.TakeDamage(damage);
            }
        }
    }
}