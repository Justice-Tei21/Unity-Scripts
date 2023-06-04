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
        currentstate = Gamestate.gamestart;

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        Destroy(this);


        
        
    }

    

    // supposed to be a super simple state changer, should use a state machine instead
    private void ChangeState()
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
                ChangeScene("StartMenu");
                break;
            case Gamestate.gamestart:
                break;
            default:
                break;
        }


    }


    private void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);

    }




    enum Gamestate
    {
        startmenu,
        gamestart,
        cutscene,
        menu,
        mainscene,
        bossroom,


    }

}
