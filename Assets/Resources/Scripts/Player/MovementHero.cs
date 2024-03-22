using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHero
{
    public float MvModifier { get; set; } = 1f;
    float movementSpeed = 3f;
    private Rigidbody2D rigidbody;
    private Vector2 movementDirection;
    public MovementHero(float mevementSpeed, Rigidbody2D rigidbody)
    {
        this.movementSpeed = mevementSpeed;
        this.rigidbody = rigidbody;
    }
    public void Move()
    {
        movementDirection = new Vector2(
            Mathf.Clamp(Input.GetAxis("Horizontal"), -10.5f, 10.5f),
            Mathf.Clamp(Input.GetAxis("Vertical"), -4.6f, 4.6f)
            );
        rigidbody.velocity = movementDirection * (movementSpeed * MvModifier);
    }

}
