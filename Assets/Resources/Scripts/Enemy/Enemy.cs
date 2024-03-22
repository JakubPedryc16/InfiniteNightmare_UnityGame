using System.Collections;
using System.Collections.Generic;
using Resources.Scenes.Scripts.States;
using UnityEngine;

public class Enemy : MonoBehaviour, DamageHandler
{
    public Movement Movement { get; set; }
    public Rotation Rotation { get; set; }
    Health health;
    private State[] states;

    private Animator animator;

    public float movementSpeed;
    public float rotationSpeed;
    public float maxHealth;

    public float ContactDamage { get; set; } = 10f;

    void Start()
    {
        Movement = new MovementForward(movementSpeed, this.transform);
        Rotation = new RotationTowardsHero(rotationSpeed, this.transform);
        health = new EnemyHealth(maxHealth);
        states = new State[2];
        for (int i = 0; i < states.Length; i++)
        {
            states[i] = new UnaffectedState(this);
        }

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement.Move();
        Rotation.rotate();
        for (int i = 0; i < states.Length; i++)
        {
            states[i].UpdateState();
        }

        if(health.GetHealth() <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetState(State state, int index)
    {
        this.states[index] = state;
    }

    public void RefreshState(int index)
    {
        states[index].RefreshState();
    }

    public void LoseHealth(float damage)
    {
        health.LoseHealth(damage);
    }

    void UpdateState(Bullet bullet)
    {
        var state = bullet.state;
        switch (state)
        {
            case "":
                return;
            case "burn":
                if (state[0].GetType() == typeof(BurnState))
                {
                    RefreshState(0);
                }
                else SetState(new BurnState(this, animator), 0);
                break;
            case "freeze":
                if (state[1].GetType() == typeof(FreezeState))
                {
                    RefreshState(1);
                }
                else SetState(new FreezeState(this, animator), 1);
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            DamageHandler damageHandler = collision.GetComponent<DamageHandler>();
            if (damageHandler != null)
            {
                LoseHealth(damageHandler.ContactDamage);
                animator.SetTrigger("onHit");
                FindObjectOfType<AudioManager>().Play("HitSound");

                var bullet = collision.GetComponent<Bullet>();
                if ( bullet == null)
                {
                    return;
                }
                UpdateState(bullet);

            }
        }
    }
}
