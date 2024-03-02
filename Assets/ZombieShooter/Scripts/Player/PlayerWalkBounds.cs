using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkBounds : MonoBehaviour
{

    [SerializeField]
    private float min_X, max_X;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementBounds();
    }


    void MovementBounds()
    {
        Vector3 temp = transform.position;

        // we cannot go below the minimum x position
        if (temp.x < min_X)
        {
            temp.x = min_X;
        }

        // we cannot go above the maximum x position
        if (temp.x > max_X)
        {
            temp.x = max_X;
        }

        transform.position = temp;
    }
}
