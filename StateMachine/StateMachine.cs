using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // Start is called before the first frame update

    public BaseState currentstate;



    void Start()
    {

        currentstate = GetInitState();
        if (currentstate!=null)
        {
            currentstate.Enter();
        }

    }

    // Update is called once per frame
    
    private void Update()
    { 
        currentstate.UpdateAll();
    }

    public void ChangeState(BaseState newstate) 
    {
        currentstate.Exit();
        currentstate = newstate;
        currentstate.Enter();
    
    }

    

    protected virtual BaseState GetInitState()
    {
        return null;
    }
}
