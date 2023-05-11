using System.Collections;
using System.Collections.Generic;
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
        BangBall b = gameObject.AddComponent<BangBall>();
        activeabilities.Add(b);

        Vector3 otherpos;
        if (player.GetComponent<PlayerController>().currenttarget)
            otherpos = player.GetComponent<PlayerController>().currenttarget.transform.position;
        else otherpos = player.transform.position + player.transform.eulerAngles;
        b.Beginning(player.transform.position,otherpos);
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
        Destroy(tokill);
    }
}
