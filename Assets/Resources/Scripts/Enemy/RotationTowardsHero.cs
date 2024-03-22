using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTowardsHero : Rotation
{
    public float RotationSpeed { get; set; } = 90f;
    Transform hero;
    Transform thisEnemy;
    public RotationTowardsHero(float rotationSpeed, Transform thisEnemy)
    {
        this.RotationSpeed = rotationSpeed;
        this.thisEnemy = thisEnemy;

        hero = GameObject.Find("Hero").transform;
    }
    public void rotate()
    {
        Vector2 direction = hero.position - thisEnemy.position;
        direction.Normalize();

        float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -180f;
        Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);
        if (thisEnemy.transform.rotation.z > 0.5f || thisEnemy.transform.rotation.z < -0.5f)
        {
            thisEnemy.localScale = new Vector3(1, -1, 1); 
        }
        else
        {
            thisEnemy.localScale = new Vector3(1, 1, 1);
        }
        thisEnemy.rotation = Quaternion.RotateTowards(thisEnemy.transform.rotation, desiredRotation, RotationSpeed * Time.deltaTime);
    }
}
