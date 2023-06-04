


class DeathState: ActorState
{
    MashStateMachine mash;

    EnemyManager enemyManager;


    public DeathState(MashStateMachine mashStateMachine) : base("Death", mashStateMachine)
    {

        this.mash = mashStateMachine;

    }


    //should probaly make it so that he doesn't instantly die
    public override void Enter()
    {
    mash.animator.Play(name);
        enemyManager.DeactivateActor(mash);

    }

    
    public override void UpdateAll()
    {
       
    }

    public override void Exit()
    {
        
    }


}