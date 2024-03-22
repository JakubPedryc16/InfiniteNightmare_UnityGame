using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandler
{
    Ability ability;
    float cooldown = 5f;
    float _cooldown;

    public void SetAbility(Ability ability)
    {
        this.ability = ability;
        this.cooldown = this.ability.GetCooldown();
    }
    public void UpdateCooldown()
    {
        _cooldown -= Time.deltaTime;
    }
    public void UseAbility(GunHero gun)
    {
        if (_cooldown <= 0)
        {
            this._cooldown = cooldown;
            this.ability.UseAbility(gun);
        }
    }
}
