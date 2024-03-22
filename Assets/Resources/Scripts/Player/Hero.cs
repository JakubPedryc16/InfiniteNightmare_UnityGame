
using Resources.Scripts.Player;
using UnityEngine;

public class Hero : MonoBehaviour, DamageHandler
{
    HealthHero heroHealth;
    MovementHero heroMovement;
    Ammo ammo;
    AbilityHandler ability;

    GunHero gunHero;
    RotationHero heroRotation;
    private Dash dash;
    Mediator mediator;

    public float ContactDamage { get; set; } = 10f;

    private void Start()
    {
        LoadHero();
    }

    private void Update()
    {
        heroRotation.rotate();
        heroMovement.Move();
        ammo.UpdateCooldown();
        ability.UpdateCooldown();
        dash.UpdateCooldown();

        if (heroHealth.GetHealth() == 0f)
        {
            GameMaster.getInstance().YouLost();
        }

        if (Input.GetKey(KeyCode.Mouse0) && ammo.IsShotAvailable())
        {
            gunHero.ShootBaseBullet();
        }
        if (Input.GetKey(KeyCode.R))
        {
            ammo.Reload();
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            ability.UseAbility(gunHero);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            dash.Execute();
        }
    }

    void LoadHero()
    {
        FactoryHero heroFactory = GameMaster.getInstance()
            .GetHeroFactory();      

        heroHealth = heroFactory.GetHeroHealth();
        heroMovement = heroFactory.GetHeroMovement();
        ammo = heroFactory.GetAmmo();

        ability = new AbilityHandler();
        ability.SetAbility(new DelayedShotsAbility());

        dash = new Dash(heroMovement, 2f);

        gunHero = GetComponent<GunHero>();
        gunHero.SetAmmo(ammo);

        heroRotation = new RotationHero(this.transform);
        mediator = GameObject.Find("Mediator").GetComponent<Mediator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            DamageHandler damageHandler = collision.GetComponent<DamageHandler>();
            if(damageHandler != null)
            {
                heroHealth.LoseHealth(damageHandler.ContactDamage);
                mediator.Notify("updateHealth", heroHealth.GetHealth(), heroHealth.GetMaxHealth());
            }
        }
    }
}
