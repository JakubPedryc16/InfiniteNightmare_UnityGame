using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediatorUI : MonoBehaviour, Mediator
{
    GameMaster gameMaster;
    GameObject canvas;

    Text healthBarText;
    Image healthBar;
    Image healthRedBar;

    Image powerBar;

    Text gunLeftAmmo;
    Image gunReloadBar;
    Image abilityReloadBar;

    float timeToDisappearHP;
    void Start()
    {
        gameMaster = GameMaster.getInstance();
        canvas = GameObject.Find("Canvas");

        healthBarText = canvas.transform.Find("HeroHealthBox/Text").GetComponent<Text>();
        healthBar = canvas.transform.Find("HeroHealthBox/HealthBar").GetComponent<Image>();
        healthRedBar = canvas.transform.Find("HeroHealthBox/LostHpBar").GetComponent<Image>();

        gunLeftAmmo = canvas.transform.Find("ReloadBox/BulletLeftText").GetComponent<Text>();
        gunReloadBar = canvas.transform.Find("ReloadBox/ReloadProgressShadow").GetComponent<Image>();
    }
    
    void Update()
    {
        timeToDisappearHP -= Time.deltaTime;
        if (timeToDisappearHP <= 0f && healthRedBar.fillAmount > healthBar.fillAmount)
        {
            healthRedBar.fillAmount -= 0.005f;
        }
    }
    public void Notify(string sender, float current, float max)
    {
        if (sender.Equals("updateHealth"))
        {
            UpdateHealthUI(current, max);
        }
        else if (sender.Equals("updateReload"))
        {
            UpdateReloadUI(current, max);
        }
        else if (sender.Equals("reloading"))
        {
            UpdateReloadingUI(current, max);
        }
        else if (sender.Equals("updateAbility"))
        {
            UpdateAbilityUI(current, max);
        }
    }
    void UpdateHealthUI(float current, float max)
    {
        healthBar.fillAmount = current / max;
        healthBarText.text = "" + (int)current;
        timeToDisappearHP = 0.75f;

    }
    void UpdateReloadUI(float current, float max)
    {
        gunReloadBar.fillAmount = current / max;
        gunLeftAmmo.text = "" + (int)current;

    }

    void UpdateReloadingUI(float current, float max)
    {
        gunReloadBar.fillAmount = 1f - current / max;
        gunLeftAmmo.text = "";
    }
    void UpdateAbilityUI(float current, float max)
    {

    }
}
