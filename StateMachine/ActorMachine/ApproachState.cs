using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachState : ActorState
{
    MashStateMachine mash;


    public ApproachState(MashStateMachine stateMachine) : base("approach", stateMachine) {
    mash=stateMachine;
    }
    
    public override void Enter()
    {

        Debug.Log("yes");
        if (mash != null) 
        { 
        //mash.animator.Play(name);
        mash.navmesh.SetDestination(mash.transform.position+Vector3.left * 10);
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
}
