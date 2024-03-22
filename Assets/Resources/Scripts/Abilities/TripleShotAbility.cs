
using UnityEngine;

public class TripleShotAbility : Ability
{
    float cooldown = 2f;
    public void UseAbility(GunHero gun)
    {
        PrepareBullet(gun);
        gun.ShootBullets(3, 20f);
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
