using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Unity.Netcode;

public class PlayerManager : NetworkBehaviour
{
    GameObject playerobject;
    PlayerController movescript;
    Targeting targetingscript;

    

    // Start is called before the first frame update
    void Start()
    {
        
        if (!IsOwner) Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

