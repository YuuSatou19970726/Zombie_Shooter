using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeaponController : WeaponController
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private ParticleSystem fx_Shoot;
    [SerializeField]
    private GameObject fx_BulletFall;

    private Collider2D fireCollider;

    private WaitForSeconds wait_Time = new WaitForSeconds(0.02f);
    private WaitForSeconds fire_ColliderWait = new WaitForSeconds(0.02f);

    // Start is called before the first frame update
    void Start()
    {
        // CREATE BULLET

        if (!GameplayController.instance.bullet_And_BulletFX_Created)
        {
            GameplayController.instance.bullet_And_BulletFX_Created = true;

            if (nameWeapon != NameWeapon.FIRE && nameWeapon != NameWeapon.ROCKET)
            {
                SmartPool.instance.CreateBulletAndBulletFall(bulletPrefab, fx_BulletFall, 100);
            }
        }

        if (!GameplayController.instance.rocket_Bullet_Created)
        {
            if (nameWeapon == NameWeapon.ROCKET)
            {
                GameplayController.instance.rocket_Bullet_Created = true;

                SmartPool.instance.CreateRocket(bulletPrefab, 100);
            }
        }


        if (nameWeapon == NameWeapon.FIRE)
        {
            fireCollider = spawnPoint.GetComponent<BoxCollider2D>();
        }
    }

    public override void ProcessAttack()
    {
        // base.ProcessAttack();

        switch (nameWeapon)
        {
            case NameWeapon.PISTOL:
                AudioManager.instance.GunSound(0);
                // print("Fired From PISTOL");
                break;
            case NameWeapon.MP5:
                AudioManager.instance.GunSound(1);
                // print("Fired From MP5");
                break;
            case NameWeapon.M3:
                AudioManager.instance.GunSound(2);
                // print("Fired From M3");
                break;
            case NameWeapon.AK:
                AudioManager.instance.GunSound(3);
                // print("Fired From AK47");
                break;
            case NameWeapon.AWP:
                AudioManager.instance.GunSound(4);
                // print("Fired From SNIPER");
                break;
            case NameWeapon.FIRE:
                AudioManager.instance.GunSound(5);
                // print("Fired From FIRE");
                break;
            case NameWeapon.ROCKET:
                AudioManager.instance.GunSound(6);
                // print("Fired From ROCKET LAUNCHER");
                break;
        }

        // SPAWN BULLET

        if ((transform != null) && (nameWeapon != NameWeapon.FIRE))
        {
            if (nameWeapon != NameWeapon.ROCKET)
            {
                GameObject bullet_FallFX =
                                            SmartPool.instance.SpawnBulletFallFX(spawnPoint.transform.position,
                                                                                 Quaternion.identity);

                bullet_FallFX.transform.localScale = (transform.root.eulerAngles.y > 1.0f) ?
                                                     new Vector3(-1f, 1f, 1f) : new Vector3(1f, 1f, 1f);

                StartCoroutine(WaitForShootEffect());

            }

            SmartPool.instance.SpawnBullet(spawnPoint.transform.position,
                                            new Vector3(-transform.root.localScale.x, 0f, 0f), spawnPoint.rotation, nameWeapon);
        }
        else
        {
            StartCoroutine(ActiveFireCollider());
        }
    }

    IEnumerator WaitForShootEffect()
    {
        yield return wait_Time;
        fx_Shoot.Play();
    }

    IEnumerator ActiveFireCollider()
    {
        fireCollider.enabled = true;
        fx_Shoot.Play();
        yield return fire_ColliderWait;
        fireCollider.enabled = false;
    }
}
