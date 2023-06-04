using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

//not in use yet
    public class EnemyManager: NetworkBehaviour
    {



    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        Destroy(this);
    }

    


    [SerializeField] int enemiestospawn;
    
    int mashtactors;


    [SerializeField]  GameObject mash;


    List<GameObject> enemyobjects = new ();
    List<ActorMachine> machines = new();

    


    [SerializeField]Vector3[] spawnpoints = new Vector3[4];
    [SerializeField] Dictionary<string,ActorData> enemydata = new ();

    private void Start()
    {
        for (int i = 0; i < mashtactors; i++) {
            enemyobjects.Add(mash);
        }
    }
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

