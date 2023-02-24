using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{
    protected string name;
    StateMachine stateMachine;





    public BaseState(string name, StateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }



    public virtual void Enter()
    {

    }
    public virtual void UpdateAll()
    {


    }
    public virtual void Exit() { }

}
