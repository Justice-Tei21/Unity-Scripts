﻿


using UnityEngine;

class Statistics: MonoBehaviour
{
    public float health;

   readonly  ActorMachine stateMachine;
    [SerializeField] ActorData data;

    private void Start()
    {
        health=data.health;
    }

    //begins death of hp less than 0
    public void HealthChanged(int damage)
    {

        health -= damage;
        if (health<=0)
        {
            stateMachine.ChangeState(stateMachine.death);
        }
    }



}