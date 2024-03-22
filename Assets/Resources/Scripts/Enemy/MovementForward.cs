using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementForward : Movement
{
    public float MvModifier { get; set; } = 1;
    public float MvAmplifier { get; set; } = 1;
    public float MovementSpeed { get; set; } = 5f;
    Transform thisEnemy;

    public MovementForward(float movementSpeed, Transform thisEnemy)
    {
        this.MovementSpeed = movementSpeed;
        this.thisEnemy = thisEnemy;
    }
    public void Move()
    {
        var transform = thisEnemy.transform;
        transform.position -= MvModifier * MvAmplifier * MovementSpeed * Time.deltaTime * transform.right;
    }
}
