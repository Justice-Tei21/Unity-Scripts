using UnityEngine;


class IdleState:BaseState
    {
        MashStateMachine mash;
        public IdleState(MashStateMachine stateMachine) : base("approach", stateMachine) 
        {
        mash = stateMachine;
        }


    public override void Enter()
    {

        mash.animator.Play(name);
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }

}

