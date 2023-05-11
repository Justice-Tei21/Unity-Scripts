using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangBall : PlayerAbility
{

    GameObject bigball;
    readonly float radius = 2;
    Collider[] colls = new Collider[20];

    Vector3 rot;

    float vel=5;
    LayerMask layer;


    
    public override void Beginning(Vector3 playerpos, Vector3 otherpos,AbilityData data)
    {
        layer = 13;

        rot = Vector3.Normalize(otherpos - playerpos);
        transform.position = playerpos+rot;

        bigball.transform.SetParent(gameObject.transform);
        bigball = Instantiate(data.gfxprefab);
        bigball.AddComponent<SphereCollider>();
        bigball.GetComponent<SphereCollider>().radius = radius;

        StartCoroutine(LifeSpan());
    }

    public override void AllUpdate()
    {
        


        Physics.OverlapSphereNonAlloc(bigball.transform.position, radius,colls,layer);
        transform.position += vel*Time.deltaTime*rot;
        for (int i = 0; i < colls.Length; i++)
        {
            if (colls[i].gameObject.CompareTag("enemy"))
            {
                Logging.Log("hit it");
                Ending();
            }
            
        }

    }



    public override void Oncollision()
    {
        base.Oncollision();
    }
    public override void Ending()
    {
        base.Ending();
        Destroy(bigball);
        schema.RemoveActive(this);
        Destroy(gameObject);
    }



    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(5f);

        Ending();
    }

}
