using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateFX : MonoBehaviour
{

    // called every time when game object is activated
    void OnEnable()
    {
        Invoke(nameof(DeactivateGameObject), 2.0f);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}
