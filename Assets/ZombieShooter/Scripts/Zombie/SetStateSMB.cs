using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStateSMB : StateMachineBehaviour
{
    [SerializeField]
    private int numberAnimationRandom;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        int randomState = Random.Range(1, numberAnimationRandom + 1);
        animator.SetInteger(TagManager.RAMDOM_PARAMETER, randomState);
    }
}
