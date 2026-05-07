using UnityEngine;

public class ShotgunFire : MonoBehaviour
{
    public GameObject impactFX;
    public ParticleSystem muzzleFlash;
    public Camera cam;
    public float range = 100f;
    public float spread = 3f;
    public int pellets = 8;
    public MouseMovement mouseMovement;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();
        for (int i = 0; i < pellets; i++)
        {
            Vector3 dir = cam.transform.forward;

            dir += cam.transform.right * Random.Range(-spread, spread) * 0.01f;
            dir += cam.transform.up * Random.Range(-spread, spread) * 0.01f;

            if (Physics.Raycast(cam.transform.position, dir, out RaycastHit hit, range))
            {
                Health hp = hit.collider.GetComponentInParent<Health>();

                if (hp != null)
                {
                    hp.TakeDamage(10f);
                }

                SpawnFX(hit);
            }
        }
        mouseMovement.AddRecoil();
    }
    void SpawnFX(RaycastHit hit)
    {
        if (impactFX == null) return;

        GameObject fx = Instantiate(
            impactFX,
            hit.point + hit.normal * 0.02f,
            Quaternion.LookRotation(hit.normal)
        );

        ParticleSystem ps = fx.GetComponent<ParticleSystem>();

        if (ps != null)
        {
            ps.Play();
        }

        Destroy(fx, 2f);
    }
}