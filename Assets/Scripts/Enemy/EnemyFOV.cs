using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    [Header("Настройки FOV")]
    public float viewRadius = 20f;
    [Range(0, 360)]
    public float viewAngle = 100f;

    [Header("Настройки слоев")]
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    [Header("Состояние")]
    public bool canSeePlayer;
    public Transform playerRef;
    public Transform eyeTransform;

    void Start()
    {
        if (playerRef == null)
            playerRef = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(FOVRoutine());
    }

    private System.Collections.IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FOVCheck();
        }
    }

    private void FOVCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(eyeTransform.position, viewRadius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - eyeTransform.position).normalized;

            if (Vector3.Angle(eyeTransform.forward, directionToTarget) < viewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(eyeTransform.position, target.position);

                if (!Physics.Raycast(eyeTransform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    Debug.Log("Игрок замечен!");
                }
                else
                {
                    canSeePlayer = false;
                }
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }
    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(eyeTransform.position, viewRadius);

        Vector3 viewAngleA = DirFromAngle(-viewAngle / 2, false);
        Vector3 viewAngleB = DirFromAngle(viewAngle / 2, false);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(eyeTransform.position, eyeTransform.position + viewAngleA * viewRadius);
        Gizmos.DrawLine(eyeTransform.position, eyeTransform.position + viewAngleB * viewRadius);

        if (canSeePlayer)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(eyeTransform.position, playerRef.position);
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += eyeTransform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }  */
}