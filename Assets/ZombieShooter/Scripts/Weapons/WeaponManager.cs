using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private List<WeaponController> weapons_Unlocked;
    [SerializeField]
    WeaponController[] total_Weapons;

    [HideInInspector]
    public WeaponController current_Weapon;
    private int current_Weapon_Index;

    private TypeControlAttack current_Type_Control;

    private PlayerArmController[] armControllers;

    private PlayerAnimations playerAnimations;

    private bool isShooting;

    [SerializeField]
    private GameObject meleeDamagePoint;

    void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();

        LoadActiveWeapons();

        current_Weapon_Index = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        armControllers = GetComponentsInChildren<PlayerArmController>();

        // set the first weapon to be pistol
        ChangeWeapon(weapons_Unlocked[1]);

        playerAnimations
        .SwitchWeaponAnimation((int)weapons_Unlocked[current_Weapon_Index].defaultConfig.typeWeapon);
    }

    void LoadActiveWeapons()
    {
        weapons_Unlocked.Add(total_Weapons[0]);

        for (int i = 1; i < total_Weapons.Length; i++)
        {
            weapons_Unlocked.Add(total_Weapons[i]);
        }
    }

    public void SwitchWeapon()
    {
        current_Weapon_Index++;

        current_Weapon_Index = (current_Weapon_Index >= weapons_Unlocked.Count) ? 0 : current_Weapon_Index;

        playerAnimations.SwitchWeaponAnimation((int)weapons_Unlocked[current_Weapon_Index].defaultConfig.typeWeapon);

        ChangeWeapon(weapons_Unlocked[current_Weapon_Index]);
    }

    void ChangeWeapon(WeaponController newWeapon)
    {
        if (current_Weapon)
            current_Weapon.gameObject.SetActive(false);

        current_Weapon = newWeapon;
        current_Type_Control = newWeapon.defaultConfig.typeControlAttack;

        newWeapon.gameObject.SetActive(true);

        if (newWeapon.defaultConfig.typeWeapon == TypeWeapon.TwoHand)
        {
            for (int i = 0; i < armControllers.Length; i++)
            {
                armControllers[i].ChangeToTwoHand();
            }
        }
        else
        {
            for (int i = 0; i < armControllers.Length; i++)
            {
                armControllers[i].ChangeToOneHand();
            }
        }
    }

    public void Attack()
    {
        if (current_Type_Control == TypeControlAttack.Hold)
        {
            current_Weapon.CallAttack();
        }
        else if (current_Type_Control == TypeControlAttack.Click)
        {
            if (!isShooting)
            {
                current_Weapon.CallAttack();
                isShooting = true;
            }
        }
    }

    public void ResetAttack()
    {
        isShooting = false;
    }

    void AllowCollisionDetection()
    {
        meleeDamagePoint.SetActive(true);
    }

    void DenyCollisionDetection()
    {
        meleeDamagePoint.SetActive(false);
    }
}
