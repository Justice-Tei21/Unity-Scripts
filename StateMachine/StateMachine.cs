using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//simple state machine abstract for other machines to extrapolate on
public class StateMachine : MonoBehaviour
{
    

    public BaseState currentstate;


    //start what is defined as the initial state
    void Start()
    {

        currentstate = GetInitState();
        if (currentstate!=null)
        {
            currentstate.Enter();
        }

    }

    //Update that state
    
    private void Update()
    { 
        currentstate.UpdateAll();
    }

    //when changing state, end current state, change the current state, begin the state
    public void ChangeState(BaseState newstate) 
    {
        currentstate.Exit();
        currentstate = newstate;
        currentstate.Enter();
    
    }

    
    //returns the initial state, should be overwrittem
    protected virtual BaseState GetInitState()
    {
        return null;
    }
}
