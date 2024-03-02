using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioClip[] gunSounds;
    [SerializeField]
    private AudioClip meleeSound;

    [SerializeField]
    private AudioSource playerAttack_AudioSource;

    [SerializeField]
    private AudioSource zombie_Attack_AudioSource;
    [SerializeField]
    private AudioSource zombie_Rise_AudioSource;
    [SerializeField]
    private AudioSource zombie_Die_AudioSource;

    [SerializeField]
    private AudioClip zombieRise_Clip, zombieDie_Clip;
    [SerializeField]
    private AudioClip[] zombieAttack_Clips;

    [SerializeField]
    private AudioSource fence_Explosion_AudioSource;
    [SerializeField]
    private AudioClip fence_Explosion_Clip;

    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GunSound(int index)
    {
        playerAttack_AudioSource.PlayOneShot(gunSounds[index], 1.0f);
    }

    public void MeleeAttackSound()
    {
        playerAttack_AudioSource.PlayOneShot(meleeSound, 1.0f);
    }

    public void ZombieRiseSound()
    {
        zombie_Rise_AudioSource.PlayOneShot(zombieRise_Clip, 1.0f);
    }

    public void ZombieDieSound()
    {
        zombie_Die_AudioSource.PlayOneShot(zombieDie_Clip, 1.0f);
    }

    public void ZombieAttackSound()
    {
        int index = Random.Range(0, zombieAttack_Clips.Length);
        zombie_Attack_AudioSource.PlayOneShot(zombieAttack_Clips[index], 1.0f);
    }

    public void FenceExplosion()
    {
        fence_Explosion_AudioSource.PlayOneShot(fence_Explosion_Clip, 1.0f);
    }
}
