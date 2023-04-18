using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachState : ActorState
{
    readonly MashStateMachine mash;
    float prefoffset = 2;
    
    

    public ApproachState(MashStateMachine stateMachine) : base("approach", stateMachine) {
    mash=stateMachine;
    }
    
    public override void Enter()
    {  
        if (mash != null) 
        { 
        //mash.animator.Play(name);
        mash.navmesh.SetDestination(PrefDistance());
        }
        base.Enter();
    }

    // Update is called once per frame
    public override void UpdateAll()
    {

        if (!mash.navmesh.hasPath)
        {
            mash.ChangeState(mash.idle);
        }
        base.UpdateAll();

    }

    public override void Exit()
    {
        mash.navmesh.SetDestination(mash.transform.position);
        base.Exit();
    }


    Vector3 PrefDistance()
    {
        Vector3 targetpoint = mash.transform.position - mash.tarplayer.transform.position;
        targetpoint = mash.tarplayer.transform.position + targetpoint.normalized * prefoffset;
        return targetpoint;
    }
}
