using UnityEngine;
using UnityEngine.AI;



/// <summary>
/// C# will absolutely never get any hoes. how can you get any vithches 
/// if you can't get a friend with access to their privates.
/// all of these publics are making me  nauseus.
/// 
/// C# ani't shit, use c++ you sad, pathetic,no balls, eunuch, scrum lord.
/// </summary>
public class MashStateMachine:StateMachine
    {


    public NavMeshAgent navmesh;
    public CapsuleCollider colbox;
    public GameObject tarplayer;
    public Animator animator;

    
     public BaseState approach;
     public BaseState idle;

    private void Awake()
    {
        approach = new ApproachState(this);
        idle = new IdleState(this); 
        
    }

    

    protected override BaseState GetInitState()
    {
        return idle;
    }

}

