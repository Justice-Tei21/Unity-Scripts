


using UnityEngine;

class Statistics: MonoBehaviour
{
    float health;

   readonly  ActorMachine stateMachine;
    [SerializeField] ActorData data;

    private void Start()
    {
        health=data.health;
    }


    public void HealthChanged(int damage)
    {

        health -= damage;
        if (health<=0)
        {
            stateMachine.ChangeState(stateMachine.death);
        }
    }



}