using UnityEngine;

public class MovementRight : Movement
{
    public float MvModifier { get; set; } = 1f;
    public float MvAmplifier { get; set; } = 1;
    public float MovementSpeed { get; set; }
    
    Transform bulletPosition;
    public MovementRight(float movementSpeed, Transform bulletPosition)
    {
        this.MovementSpeed = movementSpeed; 
        this.bulletPosition = bulletPosition;
    }
    public void Move()
    {
        bulletPosition.position += MvModifier * MvAmplifier * MovementSpeed * Time.deltaTime * bulletPosition.right;
    }


}
