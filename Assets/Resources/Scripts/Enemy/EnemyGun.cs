using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public float cooldown;
    public float damage;
    public float bulletSpeed;

    ShotHandlerEnemy shotHandler;
    void Start()
    {
        shotHandler = new ShotHandlerEnemy(cooldown, damage, bulletSpeed, transform);
    }
    void Update()
    {
        handleShot();
    }
    void handleShot()
    {
        shotHandler.UpdateCooldown();
        if (shotHandler.IsShotAvailable())
        {
            FindObjectOfType<AudioManager>().Play("ShotSound");
            Instantiate(shotHandler.GetBullet());
        }
    }
}
