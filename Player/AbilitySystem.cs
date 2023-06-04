using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AbilitySystem : MonoBehaviour
{

    
    [SerializeField] AbilityData balldata;
    


    //these might not be necessary
    [SerializeField] PlayerAbility ability2;
    [SerializeField] PlayerAbility ability3;


    [SerializeField]  GameObject player;


    List<PlayerAbility> activeabilities = new ();

    
    //of there is a target, use that pos otherwise, just somewhere infront
    public void BulletAbility()
    {
        Vector3 otherpos;
        if (player.GetComponent<PlayerController>().currenttarget  )
            otherpos = player.GetComponent<PlayerController>().currenttarget.transform.position;
        else otherpos = player.transform.position + player.transform.forward*100;

        
        //creation of the ability gameobject

        GameObject b = Instantiate(balldata.gfxprefab, transform.position,transform.rotation);

        b.AddComponent<BangBall>();
        BangBall ball = b.GetComponent<BangBall>();

        ball.SetSchema(this);
        ball.other = otherpos;
        ball.Beginning();
        activeabilities.Add(ball);
       

        
    }

   // Update every instance
    void Update()
    {
        for (int i = 0; i < activeabilities.Count; i++)
        {
            activeabilities[i].AllUpdate();
        }
        
    }

    //remove the instance from the list of active abilities
    //and then destroys it
    public void RemoveActive(PlayerAbility tokill)
    {
        activeabilities.Remove(tokill);
        Destroy(tokill.gameObject);
    }
}
