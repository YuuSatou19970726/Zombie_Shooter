using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    [SerializeField]
    private GameObject[] blood_FX;

    private PlayerAnimations playerAnim;

    // public delegate void PlayerDeadEvent(bool dead);
    // public static event PlayerDeadEvent playerDead;

    void Awake()
    {
        playerAnim = GetComponentInParent<PlayerAnimations>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DealDamage(int damage)
    {
        health -= damage;

        GameplayController.instance.PlayerLifeCounter(health);

        // playerAnim.Hurt();


        if (health <= 0)
        {
            // if (playerDead != null)
            // {
            //     playerDead(true);
            // }

            GameplayController.instance.playerAlive = false;

            GetComponent<Collider2D>().enabled = false;
            playerAnim.Dead();

            blood_FX[Random.Range(0, blood_FX.Length)].SetActive(true);

            GameplayController.instance.GameOver();
        }
    }
}
