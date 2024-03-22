using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GunHandler
{
    public bool IsShotAvailable();
    public GameObject GetBullet();
    public void UpdateCooldown();
}
