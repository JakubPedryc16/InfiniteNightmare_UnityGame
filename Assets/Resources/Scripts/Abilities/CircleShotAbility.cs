using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShotAbility : Ability
{
    float cooldown = 5f;
    public void UseAbility(GunHero gun)
    {
        PrepareBullet(gun);
        gun.ShootBullets(8, 360f);   
    }
    public float GetCooldown()
    {
        return this.cooldown;
    }
    void PrepareBullet(GunHero gun)
    {
        GameObject bullet = UnityEngine.Resources.Load<GameObject>("Prefabs/Bullets/bullet_hero2");
        gun.SetBullet(bullet, 10);
    }
}
