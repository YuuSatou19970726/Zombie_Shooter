using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{
    [SerializeField]
    private LayerMask collisionLayer;
    [SerializeField]
    private float radius = 1f;

    [SerializeField]
    private int damage = 3;

    // private bool playerDead;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameplayController.instance.zombieGoal == ZombieGoal.PLAYER)
        {
            AttackPlayer();
        }

        if (GameplayController.instance.zombieGoal == ZombieGoal.FENCE)
        {
            AttackFence();
        }

    }

    // void OnEnable()
    // {
    //     PlayerHealth.playerDead += PlayerDeadListener;
    // }

    // void OnDisable()
    // {
    //     PlayerHealth.playerDead -= PlayerDeadListener;
    // }

    void AttackPlayer()
    {
        if (GameplayController.instance.playerAlive)
        {
            Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);

            if (target)
            {
                if (target.tag == TagManager.PLAYER_HEALTH_TAG)
                {
                    // print("Attacked Player");
                    target.GetComponent<PlayerHealth>().DealDamage(damage);
                }
            }
        }
    }

    // void PlayerDeadListener(bool dead)
    // {
    //     playerDead = dead;
    // }

    void AttackFence()
    {
        if (!GameplayController.instance.fenceDestroyed)
        {
            Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);

            if (target.tag == TagManager.FENCE_TAG)
            {
                target.GetComponent<FenceHealth>().DealDamage(damage);
            }
        }

    }
}
