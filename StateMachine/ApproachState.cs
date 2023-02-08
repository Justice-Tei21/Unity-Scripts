using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachState : BaseState
{
    MashStateMachine mash;

    public ApproachState(MashStateMachine stateMachine) : base("approach", stateMachine) {
    mash=stateMachine;
    }
    
    public override void Enter()
    {
        base.Enter();
        mash.animator.Play(name);
        mash.navmesh.Move(Vector3.left * 10);
        
        

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (!mash.navmesh.hasPath)
        {
            mash.ChangeState(mash.idle);
        }

    }

    public override void Exit()
    {
        base.Exit();
        mash.navmesh.SetDestination(mash.transform.position);
    }
}
