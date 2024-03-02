using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponController : WeaponController
{
    public override void ProcessAttack()
    {
        // base.ProcessAttack();
        // print("Fires From MELEE");
        AudioManager.instance.MeleeAttackSound();
    }
}
