using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    Gamestate currentstate;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        Destroy(this);
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentstate)
        {
            case Gamestate.menu:
                break;
            case Gamestate.cutscene:
                break;
            case Gamestate.mainscene:
                break;
            case Gamestate.bossroom:
                break;
            case Gamestate.startmenu:
                Menufunc();
                break;
            default:
                break;
        }
    }


    private void Menufunc()
    {
        SceneManager.LoadScene("StartMenu");

    }




    enum Gamestate
    {
        startmenu,
        cutscene,
        menu,
        mainscene,
        bossroom,


    }

}
