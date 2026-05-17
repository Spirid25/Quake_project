using Assets.Scripts.Weapon;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShotgunFire : MonoBehaviour
{
    public GameObject impactFX;
    public GameObject bloodFX;
    public ParticleSystem muzzleFlash;
    public Camera cam;
    public GameObject weapon;
    public GameObject hands;
    public float range = 100f;
    public float spread = 1f;
    public int pellets = 15;
    private float nextFireTime = 0f;
    public float fireRate = 0.6f;
    public MouseMovement mouseMovement;
    public WeaponRecoil weaponRecoil;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; 
        }
    }
    void Shoot()
    {

        muzzleFlash.Play();
        for (int i = 0; i < pellets; i++)
        {
            Vector3 dir = cam.transform.forward;

            dir += cam.transform.right * Random.Range(-spread, spread) * 0.02f;
            dir += cam.transform.up * Random.Range(-spread, spread) * 0.02f;

            if (Physics.Raycast(cam.transform.position, dir, out RaycastHit hit, range))
            {
                Health hp = hit.collider.GetComponentInParent<Health>();

                if (hp != null)
                {
                    hp.TakeDamage(4f);
                    SpawnBloodFX(hit);
                }
                else
                {
                    SpawnFX(hit);
                }
            }
        }
        mouseMovement.AddRecoil();
        weaponRecoil.AddRecoil();
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
    void SpawnBloodFX(RaycastHit hit)
    {
        if (bloodFX == null) return;

        GameObject fx = Instantiate(
            bloodFX,
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