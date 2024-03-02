using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NameWeapon
{
    MELEE,
    PISTOL,
    MP5,
    M3,
    AK,
    AWP,
    FIRE,
    ROCKET
}

public class WeaponController : MonoBehaviour
{
    public DefaultConfig defaultConfig;
    public NameWeapon nameWeapon;

    protected PlayerAnimations playerAnimation;
    protected float lastShot;

    [SerializeField]
    private int gunIndex;
    [SerializeField]
    private int currentBullet;
    [SerializeField]
    private int bulletMax;

    void Awake()
    {
        playerAnimation = GetComponentInParent<PlayerAnimations>();
        currentBullet = bulletMax;
    }

    public void CallAttack()
    {
        if (Time.time > lastShot + defaultConfig.fireRate)
        {
            if (currentBullet > 0)
            {
                ProcessAttack();

                // ANIMATE SHOOT
                playerAnimation.AttackAnimation();

                lastShot = Time.time;
                currentBullet--;
            }
            else
            {
                // PLLAY NO AMMO SOUND
            }
        }
    }

    public virtual void ProcessAttack()
    {

    }
}
