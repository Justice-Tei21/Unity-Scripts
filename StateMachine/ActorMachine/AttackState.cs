using UnityEngine;



//npt completely done. just made an animation for it but need some work.
class AttackState:ActorState
    {
        readonly MashStateMachine mash;
        public AttackState(MashStateMachine stateMachine) : base("attack", stateMachine) 
        {
        mash = stateMachine;
        }

    //just for confirmation that state state can be entered
    public override void Enter()
    {
        GameObject newt = GameObject.CreatePrimitive(PrimitiveType.Cube);
           newt.GetComponent<SpriteRenderer>().color=(Color.red);
        newt.transform.position = mash.transform.position;
        
        base.Enter();
        //mash.animator.Play(name);
    }

    public override void UpdateAll()
    {
        base.UpdateAll();

    }

    public override void Exit()
    {
        base.Exit();
    }


    


}

