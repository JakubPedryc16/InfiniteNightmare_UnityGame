using UnityEngine;


public class GunHero : MonoBehaviour
{
    Animator anim;
    AudioSource audioSource;
    Ammo ammo;
    void Start()
    {
        FactoryHero heroFactory = GameObject.Find("GameMaster")
            .GetComponent<GameMaster>()
            .GetHeroFactory();
        setUpVariables();
        ammo = heroFactory.GetGunHero();
    }

    void Update()
    {
        handleShot();
    }
    void SetUpVariables()
    {
        anim = GameObject.Find("BulletPos").gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    void handleShot()
    {
        ammo.UpdateCooldown();

        if (Input.GetKey(KeyCode.Mouse0) && ammo.IsShotAvailable())
        {
            anim.Play("gunShot");
            audioSource.Play();

            Instantiate(ammo.GetBullet());

        }
        if (Input.GetKey(KeyCode.R))
        {
            ammo.Reload();
        }
    }
    void SetAmmo(Ammo ammo)
    {
        this.ammo = ammo;
    }
}
