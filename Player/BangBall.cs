using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using UnityEngine;

public class BangBall : PlayerAbility
{

    
    readonly float radius = 2;
    int damage = 40;
    Collider[] colls = new Collider[15];

    Vector3 rot;
     public Vector3 other;
    float vel=20;
    LayerMask layer;
    

    
    public override void Beginning()
    {  
        
        layer = 13;

        rot = Align(transform.position, other);
        transform.position += rot * 2;
        
        //gameObject.AddComponent<SphereCollider>();
        
        //gameObject.GetComponent<SphereCollider>().radius = radius;

        


        StartCoroutine(LifeSpan());
    }

    //movement, detection and messaging is done here
    public override void AllUpdate()
    {
        Logging.Log("is updating");
        
        transform.position += vel*Time.deltaTime*rot;

        //which colliders it hits
        Physics.OverlapSphereNonAlloc(transform.position,radius,colls,layer);

        for (int i = 0; i < colls.Length; i++)
        {
            if (colls[i] == null) break;

            

            

            if (colls[i].gameObject.layer == layer )
            {
                Logging.Log("hit it");
                colls[i].gameObject.GetComponent<Damageable>().HitThis(damage);
                Ending();
            }
            

        }

    }

    //should probably do something here
    public override void Oncollision()
    {
        base.Oncollision();

    }

    //send a message to the ability system to kill it.
    public override bool Ending()
    {
        base.Ending();   
        schema.RemoveActive(this);
        return true;
    }


    //makes the object send an end message after the time is out
    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(1f);

        yield return this.Ending();
    }

    //create a unit vector from one object to another.
    public static Vector3 Align(Vector3 start, Vector3 end)
    {

        return Vector3.Normalize(end+Vector3.up - start);
    }

}
