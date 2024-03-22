using UnityEngine;

public class GunHero : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    Transform gun;
    Ammo ammo;

    Animator anim;
    AudioSource audioSource;

    private void Start()
    {
        gun = GameObject.Find("Gun").transform;
        anim = GameObject.Find("BulletPos").gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public void ShootBaseBullet()
    {
        anim.Play("gunShot");
        audioSource.Play();
        Instantiate(ammo.GetBullet());
    }
    public void ShootBullet()
    {
        anim.Play("gunShot");
        audioSource.Play();
        SetBulletLocation();
        Instantiate(bullet);
    }
    public void ShootBullets(int num, float shotAngle = 0)
    {
        anim.Play("gunShot");
        audioSource.Play();
        float anglePart = shotAngle / num;
        float angleCurrent = -shotAngle / 2f;
        for (int i = 0; i < num; i++)
        {
            SetBulletLocation(angleCurrent);
            Instantiate(bullet);

            angleCurrent += anglePart;
        }
    }
    public void SetAmmo(Ammo ammo)
    {
        this.ammo = ammo;
    }
    public void SetBullet(GameObject bullet, float damage)
    {
        this.bullet = bullet;
        bullet.GetComponent<Bullet>().ContactDamage = damage;
    }
    void SetBulletLocation(float shotAngle = 0f)
    {
        bullet.transform.position = new Vector2(
        gun.transform.position.x + Random.Range(-0.1f, 0.1f),
        gun.transform.position.y + Random.Range(-0.1f, 0.1f)
        );

        bullet.transform.rotation = Quaternion.Euler(
            gun.transform.rotation.eulerAngles.x,
            gun.transform.rotation.eulerAngles.y,
            gun.transform.rotation.eulerAngles.z + shotAngle
            );

        bullet.transform.position += bullet.transform.TransformDirection(Vector3.right * 0.6f);
    }

}
