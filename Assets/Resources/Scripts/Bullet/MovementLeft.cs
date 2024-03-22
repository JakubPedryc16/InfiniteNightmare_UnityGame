using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLeft : Movement
{
    public float MvModifier { get; set; } = 1;
    public float MvAmplifier { get; set; } = 1;
    public float MovementSpeed { get; set; }
    Transform bulletPosition;
    public MovementLeft(float movementSpeed, Transform bulletPosition)
    {
        this.MovementSpeed = movementSpeed;
        this.bulletPosition = bulletPosition;
    }
    public void Move()
    {
        bulletPosition.position -= MvModifier * MvAmplifier * MovementSpeed * Time.deltaTime * bulletPosition.right;
    }


}
