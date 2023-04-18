using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActorMachine : StateMachine
{
    protected Collider[] hitbox;


    public ActorState approach;
    public ActorState idle;
    public ActorState attack;
    public ActorState death;


}
