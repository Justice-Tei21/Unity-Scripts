using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventMaker : MonoBehaviour
{
    
    bool targeting = true;
    public AbilitySystem abilities;
    public Animator animator;
    public UnityEvent<GameObject> onlookattarget;

    public UnityEvent<GameObject> ontargetfalse;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilities.BulletAbility();
        }
    }


    // what happens when the target changes
    // unused 
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


    //camera cont uses this to switch camera
    public void Istargeting(GameObject target)
    {
        onlookattarget.Invoke(target);
    }

    // switches to freelook camera 
    public void IsNotTargeting(GameObject player)
    {
        ontargetfalse.Invoke(player);
    }
}
