using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameplayController.instance.gameGoal != GameGoal.DEFEND_FENCE &&
        GameplayController.instance.gameGoal != GameGoal.GAME_OVER)
        {
            if (playerTransform)
            {
                Vector3 temp = transform.position;
                temp.x = playerTransform.position.x;
                transform.position = temp;
            }
        }
    }
}
