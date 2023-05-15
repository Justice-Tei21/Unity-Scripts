using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BangBall : PlayerAbility
{

    GameObject bigball ;
    readonly float radius = 2;
    Collider[] colls = new Collider[20];

    Vector3 rot;

    float vel=5;
    LayerMask layer;


    
    public override void Beginning(Vector3 playerpos, Vector3 otherpos,AbilityData data)
    {
        Logging.Log("allive");
        layer = 13;

        rot = Vector3.Normalize(otherpos - playerpos);
        transform.position = playerpos+rot;

        
        
        bigball = Instantiate(data.gfxprefab,transform.position,quaternion.EulerXYZ(rot));
        bigball.transform.SetParent(gameObject.transform);
        
        
        bigball.AddComponent<SphereCollider>();
        bigball.GetComponent<SphereCollider>().radius = radius;

        StartCoroutine(LifeSpan());
    }

    public override void AllUpdate()
    {
        
        Physics.OverlapSphereNonAlloc(bigball.transform.position,radius,colls,layer);
        transform.position += vel*Time.deltaTime*rot;

        for (int i = 0; i < colls.Length; i++)
        {
            GameObject objecto = colls[i].gameObject;

            if (objecto != null) break;

            if (objecto.layer == layer)
            {
                Logging.Log("hit it");
                Ending();
            }
            
        }

        colls = null;
    }



    public override void Oncollision()
    {
        base.Oncollision();
    }
    public override bool Ending()
    {
        
        base.Ending();
        Destroy(bigball);
        schema.RemoveActive(this);
        return true;
    }



    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(1f);

        yield return this.Ending();
    }

}
