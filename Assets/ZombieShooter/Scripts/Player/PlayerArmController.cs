using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmController : MonoBehaviour
{
    public Sprite one_Hand_Sprite, two_Hand_Sprite;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeToOneHand()
    {
        spriteRenderer.sprite = one_Hand_Sprite;
    }

    public void ChangeToTwoHand()
    {
        spriteRenderer.sprite = two_Hand_Sprite;
    }
}
