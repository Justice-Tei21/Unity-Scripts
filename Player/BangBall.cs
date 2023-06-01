using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BangBall : PlayerAbility
{

    GameObject bigball ;
    readonly float radius = 2;
    int damage = 40;
    Collider[] colls = new Collider[15];

    Vector3 rot;
    Vector3 other;
    float vel=20;
    LayerMask layer;


    
    public override void Beginning()
    {
        
        layer = 13;
        
        gameObject.AddComponent<SphereCollider>();
        gameObject.GetComponent<SphereCollider>().radius = radius;

        StartCoroutine(LifeSpan());
    }

    public override void AllUpdate()
    {
        
        
        Physics.OverlapSphereNonAlloc(bigball.transform.position,radius,colls,layer);
        bigball.transform.position += vel*Time.deltaTime*transform.forward;

        for (int i = 0; i < colls.Length; i++)
        {
            if (colls[i] != null) break;

            

            

            if (colls[i].gameObject.layer == layer )
            {
                Logging.Log("hit it");
                colls[i].gameObject.GetComponent<Damageable>().HitThis(damage);
                Ending();
            }
            

        }

    }

    public override void Oncollision()
    {
        base.Oncollision();
    }


    public override bool Ending()
    {
        base.Ending();   
        schema.RemoveActive(this);
        return true;
    }



    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(1f);

        yield return this.Ending();
    }

    public static Vector3 Align(Vector3 start, Vector3 end)
    {

        return Vector3.Normalize(end - start);
    }

}
