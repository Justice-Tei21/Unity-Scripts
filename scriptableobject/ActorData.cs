using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName ="MyThings/enemy")]
public class ActorData : ScriptableObject
{
    public string type;
    public int health;
    public int Energy;

    public float actioncooldown;
    ActorData()
    {
        
    }

    

    

}
