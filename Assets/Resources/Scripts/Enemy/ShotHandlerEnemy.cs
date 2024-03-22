using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHandlerEnemy : GunHandler
{
    float cooldown;
    float _cooldown;
    float damage;
    private float bulletSpeed;

    GameObject bullet;
    Transform location;
    public ShotHandlerEnemy(float cooldown, float damage, float bulletSpeed, Transform location)
    {
        this.cooldown = cooldown;
        this._cooldown = cooldown;
        this.damage = damage;
        this.location = location;
        this.bulletSpeed = bulletSpeed;
        
        
        bullet = UnityEngine.Resources.Load<GameObject>("Prefabs/Bullets/bullet_enemy0");
        bullet.layer = 7;

    }
    public void UpdateCooldown()
    {
        _cooldown -= Time.deltaTime;
    }
    public bool IsShotAvailable()
    {
        return (_cooldown <= 0f);
    }
    public GameObject GetBullet()
    {
        _cooldown = Random.Range(cooldown * 0.5f, cooldown * 2f);

        bullet.transform.position = new Vector2(
            location.position.x - Random.Range(-0.1f, 0.1f),
            location.position.y - Random.Range(-0.1f, 0.1f));

        bullet.transform.rotation = location.rotation;
        bullet.transform.position -= bullet.transform.TransformDirection(Vector3.right * 0.6f);
        bullet.GetComponent<Bullet>().ContactDamage = damage;
        bullet.GetComponent<Bullet>().BulletSpeed = bulletSpeed;
        return bullet;

    }
}
