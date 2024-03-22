using System.Collections;
using System.Collections.Generic;
using Resources.Scenes.Scripts.States;
using UnityEngine;

public class Bullet : MonoBehaviour, DamageHandler
{
    public Movement Movement { get; set; }

    float disappearTime = 5f;

    [SerializeField] public float BulletSpeed { get; set; } = 8f;

    [SerializeField] public float ContactDamage { get; set; } = 5f;

    public int targetLayer = 7;
    public bool rightDirection = true;
    public string state;
   
    void Start()
    {
        if (rightDirection)
        {
            Movement = new MovementRight(BulletSpeed, transform);
        }
        else
        {
            Movement = new MovementLeft(BulletSpeed, transform);
        }
    }
    void Update()
    {
        disappearTime -= Time.deltaTime;
        if (disappearTime <= 0)
        {
            Destroy(this.gameObject);
        }

        Movement.Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == targetLayer)
        {
            Destroy (this.gameObject);
        }
    }
}
