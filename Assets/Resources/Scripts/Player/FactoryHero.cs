
using UnityEngine;

public class FactoryHero 
{
    Hero hero;
    GameObject gun;
    int heroType;

    public FactoryHero(int heroType, Hero hero, GameObject gun)
    {
        this.heroType = heroType;
        this.hero = hero;
        this.gun = gun;
    }

    HealthHero heroHealth;
    MovementHero heroMovement;
    Ammo ammo;

    float[] heroHealthVariants = new float[]
    {
        100f,
        100f,
        100f
    };

    float[] heroMovementVariants = new float[]
    {
        5f,
        5f,
        5f
    };

    float[][] shotHandlerVariants = new float[][]
    {
        new float[] {0.5f, 2f, 10f, 5f},
        new float[] {0.5f, 1f, 10f, 5f}
    };

    public HealthHero GetHeroHealth()
    {
        float health = heroHealthVariants[this.heroType];
        return new HealthHero(health);
    }

    public MovementHero GetHeroMovement()
    {
        float movementSpeed = heroMovementVariants[this.heroType];
        Rigidbody2D rigidbody = hero.GetComponent<Rigidbody2D>();
        return new MovementHero(movementSpeed, rigidbody);
    }

    public Ammo GetAmmo()
    {
        float shotCooldown = shotHandlerVariants[this.heroType][0];
        float clipSize = shotHandlerVariants[this.heroType][1];
        float leftAmmo = shotHandlerVariants[this.heroType][2];
        float damage = shotHandlerVariants[this.heroType][3];
        Mediator mediator = GameObject.Find("Mediator").GetComponent<Mediator>();

        return new Ammo(shotCooldown, clipSize, leftAmmo, damage, gun, mediator);
    }

}
