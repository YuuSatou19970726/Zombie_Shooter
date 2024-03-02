using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMZombieDead : StateMachineBehaviour
{
    [SerializeField]
    private int index;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.GetComponent<ZombieController>().ActivateDeadEffect(index);
    }
}
