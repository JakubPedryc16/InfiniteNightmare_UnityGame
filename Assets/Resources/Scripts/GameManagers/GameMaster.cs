using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster gameMaster;
    
    Hero hero;
    GameObject gun;
    FactoryHero heroFactory;

    bool paused = false;
    bool gameEnded = false;
    public GameObject pauseMenu;

    private void Awake()
    {
        gameMaster = this;
        
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        gun = GameObject.Find("HeroGun");
        heroFactory = new(0, hero, gun);

        pauseMenu = GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject;
    }
    void Update()
    {
        //Cursor.visible = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ManagePause();
        }

    }
    public FactoryHero GetHeroFactory() { return heroFactory; }
    public void YouWin()
    {
        gameEnded = true;
        Time.timeScale = 0f;
        GameObject.Find("Canvas").transform.Find("YouWonObject").gameObject.SetActive(true);

    }
    public void YouLost()
    {
        gameEnded = true;
        Time.timeScale = 0f;
        GameObject.Find("Canvas").transform.Find("YouLostObject").gameObject.SetActive(true);
    }
    public void ManagePause()
    {
        if (paused == false)
        { 
            Time.timeScale = 0f;
            paused = true;
            pauseMenu.SetActive(true);
        }
        else if (paused == true)
        {
            if (gameEnded == false)
            {
                Time.timeScale = 1f;
            }
            paused = false;
            pauseMenu.SetActive(false);

        }
    }

    public static GameMaster getInstance()
    {
        return gameMaster;
    }

}
