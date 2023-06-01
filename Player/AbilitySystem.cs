using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AbilitySystem : MonoBehaviour
{

    
    [SerializeField] AbilityData balldata;
    


    //these might not be necessary
    PlayerAbility bangball;
    [SerializeField] PlayerAbility ability2;
    [SerializeField] PlayerAbility ability3;


    [SerializeField]  GameObject player;


    List<PlayerAbility> activeabilities = new ();

    

    public void BulletAbility()
    {
        Vector3 otherpos;
        if (player.GetComponent<PlayerController>().currenttarget  )
            otherpos = player.GetComponent<PlayerController>().currenttarget.transform.position;
        else otherpos = player.transform.position + player.transform.forward*100;

        
        

        GameObject b = Instantiate(balldata.gfxprefab, transform.position, quaternion.EulerXYZ(BangBall.Align(transform.position,otherpos)));

        b.AddComponent<BangBall>();

        BangBall ball = b.GetComponent<BangBall>();

        ball.SetSchema(this);
        activeabilities.Add(ball);
       

        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < activeabilities.Count; i++)
        {
            activeabilities[i].AllUpdate();
        }
        
    }


    public void RemoveActive(PlayerAbility tokill)
    {
        activeabilities.Remove(tokill);
        Destroy(tokill.gameObject);
    }
}
