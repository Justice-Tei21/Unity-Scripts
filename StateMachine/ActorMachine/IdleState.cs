using UnityEngine;


class IdleState:ActorState
    {
        readonly MashStateMachine mash;
        public IdleState(MashStateMachine stateMachine) : base("approach", stateMachine) 
        {
        mash = stateMachine;
        }


    
    public override void Enter()
    {
        Logging.Log("now idle");
        base.Enter();
        //mash.animator.Play(name);
    }


    //sees if the player is close enough and exit the idle state
    public override void UpdateAll()
    {

        base.UpdateAll();


        if (Vector3.Distance(mash.gameObject.transform.position,mash.tarplayer.transform.position)<10)
        {
            mash.ChangeState(mash.approach);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}

