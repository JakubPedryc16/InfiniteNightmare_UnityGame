using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedShotsAbility : Ability
{
    float cooldown = 5f;
    public void UseAbility(GunHero gun)
    {
        float delay = 0f;
        PrepareBullet(gun);
        for (int i = 0; i < 10; i++)
        {
            gun.Invoke("ShootBullet", delay);
            delay += 0.05f + (0.5f / (float)(i+1) );
        }
    }
    public float GetCooldown()
    {
        return this.cooldown;
    }
    void PrepareBullet(GunHero gun)
    {
        GameObject bullet = UnityEngine.Resources.Load<GameObject>("Prefabs/Bullets/bullet_hero1");
        gun.SetBullet(bullet, 5);
    }
}
