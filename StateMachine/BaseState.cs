using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public abstract class BaseState 
{
    public string name;
    StateMachine stateMachine;




    //just the constructor for basic variables
    public BaseState(string name, StateMachine stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }


    //what should happen at start
    public virtual void Enter()
    {

    }
    //whatt should happen every frame
    public virtual void UpdateAll()
    {


    }

    //what happens att end
    public virtual void Exit() { }

}
