using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;


    public class EnemyManager: NetworkBehaviour
    {



    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        Destroy(this);
    }


    private void Start()
    {
        for (int i = 0; i < mashtactors; i++) {
            enemyobjects.Add(mash);
        }
    }

    [SerializeField] int mashtactors;


    [SerializeField]  GameObject mash;


    List<GameObject> enemyobjects = new ();
    List<ActorMachine> machines = new();


    Vector3[] spawnpoints = new Vector3[4];
    [SerializeField] Dictionary<string,ActorData> enemydata = new ();

    public ActorData GetActorData(string name)
    {
        return enemydata[name];
    }

    public void DeactivateActor(ActorMachine actor)
    {
        if(machines.Contains(actor))
        {
            actor.gameObject.SetActive(false);
        }
    }

}

