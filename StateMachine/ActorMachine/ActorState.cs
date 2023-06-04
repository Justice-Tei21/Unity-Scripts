using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorState : BaseState
{
    //same as basestate but a statemachine can now specify states
    //that work on actors and not managers or animations
    public ActorState(string name, StateMachine statemachine) : base(name, statemachine)
    {

    }

    
    
}
