using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : DamageHandler
{
    float shotCooldown = 0.5f;
    float reloadTime = 1f;

    float _cooldown = 0f;

    float clipSize = 10;
    float leftAmmo;

    public float ContactDamage { get; set; } = 5f;
    
    GameObject gun;

    [SerializeField]
    GameObject bullet;

    Mediator mediator;

    private bool isReloading = false;

    public Ammo(float shotCooldown, float reloadTime, float clipSize, float damage, GameObject gun, Mediator mediator)
    {
        this.shotCooldown = shotCooldown;
        this.reloadTime = reloadTime;
        this.clipSize = clipSize;
        this.ContactDamage = damage;
        this.gun = gun;
        this.mediator = mediator;
        bullet = UnityEngine.Resources.Load<GameObject>("Prefabs/Bullets/bullet_hero0");
        bullet.layer = 6;
        leftAmmo = clipSize;
    }
    public bool IsShotAvailable()
    {
        if (leftAmmo <= 0)
        {
            Reload();
            return false;
        }
        return (_cooldown <= 0f);
    }
    public GameObject GetBullet()
    {
        leftAmmo--;
        _cooldown = shotCooldown;
        mediator.Notify("updateReload", leftAmmo, clipSize);

        bullet.transform.position = new Vector2(
            gun.transform.position.x + Random.Range(-0.1f, 0.1f),
            gun.transform.position.y + Random.Range(-0.1f, 0.1f));

        bullet.transform.rotation = gun.transform.rotation;
        bullet.transform.position += bullet.transform.TransformDirection(Vector3.right * 0.6f);
        bullet.GetComponent<Bullet>().ContactDamage = ContactDamage;
        bullet.GetComponent<Bullet>().BulletSpeed = 10f;
        return bullet;
    }
    public void UpdateCooldown()
    {
        _cooldown -= Time.deltaTime;
        if (isReloading && _cooldown > 0f)
        {
            mediator.Notify("reloading", _cooldown, reloadTime);
        }
        else if (isReloading)
        {
            mediator.Notify("updateReload", leftAmmo, clipSize);
            isReloading = false;
        }
        
    }
    public void Reload()
    {
        _cooldown = reloadTime;
        leftAmmo = clipSize;
        isReloading = true;
    }

    public float GetDamage()
    {
        return ContactDamage;
    }
}
