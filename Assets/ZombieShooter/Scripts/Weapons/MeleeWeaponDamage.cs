using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponDamage : MonoBehaviour
{
    [SerializeField]
    private LayerMask collisionLayer;
    [SerializeField]
    private float radius = 3f;

    [SerializeField]
    private int damage = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D target = Physics2D.OverlapCircle(transform.position, radius, collisionLayer);

        if (target)
        {
            if (target.tag == TagManager.ZOMBIE_HEALTH_TAG)
            {
                // print("We touched zombie");
                target.transform.root.GetComponent<ZombieController>().DealDamage(damage);
            }
        }
    }
}
