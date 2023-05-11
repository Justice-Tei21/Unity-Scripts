using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventMaker : MonoBehaviour
{
    
    bool targeting = true;
    public AbilitySystem abilities;
    public UnityEvent<GameObject> onlookattarget;

    public UnityEvent<GameObject> ontargetfalse;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilities.BulletAbility();
        }
    }

    public void ChangeTargetstate(GameObject target, GameObject player)
    {
        targeting = !targeting;
        if (targeting)
        {
            onlookattarget.Invoke(target);
            targeting = false;
        }

        else 
        { 
            ontargetfalse.Invoke(player); 
            targeting = true;
        }

    }

    public void Istargeting(GameObject target)
    {
        onlookattarget.Invoke(target);
    }

    public void IsNotTargeting(GameObject player)
    {
        ontargetfalse.Invoke(player);
    }
}
