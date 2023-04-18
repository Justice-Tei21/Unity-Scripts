


class DeathState: ActorState
{
    MashStateMachine mash;

    EnemyManager enemyManager;

    public DeathState(MashStateMachine mashStateMachine) : base("Death", mashStateMachine)
    {

        this.mash = mashStateMachine;

    }



    public override void Enter()
    {
    mash.animator.CrossFade(name,0.1f);
        enemyManager.DeactivateActor(mash);

    }


    public override void UpdateAll()
    {
       
    }

    public override void Exit()
    {
        
    }


}