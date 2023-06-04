using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ApproachState : ActorState
{
    readonly MashStateMachine mash;
    readonly float prefoffset = 1;
    
    

    public ApproachState(MashStateMachine stateMachine) : base("approach", stateMachine) {
    mash=stateMachine;
    }
    

    //finds the players position at one point and moses there with an offset
    public override void Enter()
    {  
        if (mash != null) 
        { 
        //mash.animator.Play(name);
        mash.navmesh.speed = 8;
        mash.navmesh.SetDestination(PrefDistance());
        }
        base.Enter();
    }

    //if it has nowhere to go it enters idle
    public override void UpdateAll()
    {

        if (!mash.navmesh.hasPath)
        {
            mash.ChangeState(mash.idle);
        }
        base.UpdateAll();

    }

    //just to make sure that it stays in the same place,
    //might not do anything
    public override void Exit()
    {
        mash.navmesh.SetDestination(mash.transform.position);
        base.Exit();
    }

    //sets a point a certain distance infront of the target
    Vector3 PrefDistance()
    {
        Vector3 targetpoint = mash.transform.position - mash.tarplayer.transform.position;
        targetpoint = mash.tarplayer.transform.position + targetpoint.normalized * prefoffset;
        return targetpoint;
    }
}
