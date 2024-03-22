
using UnityEngine;

internal class RotationHero
{
    Transform hero;
    public RotationHero(Transform hero)
    {
        this.hero = hero;
    }

    public void rotate()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 objectPos = Camera.main.WorldToScreenPoint(hero.transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float zAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;


        if (zAngle > 90f || zAngle < -90f)
        {

            hero.rotation = Quaternion.Euler(new Vector3(180, 0, -zAngle));
        }
        else
        {

            hero.rotation = Quaternion.Euler(new Vector3(0, 0, zAngle));
        }
    }

}
