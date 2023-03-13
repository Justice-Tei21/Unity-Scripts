using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour 
{

    private float jumpvel;
    private Vector3 flatmove;
    public float speed=2;
    
    

    Camera cam;
    
    [SerializeField]private EventMaker eventmaker;

    
    [SerializeField]Targeting targetsystem;

    GameObject currenttarget;

    [SerializeField] private CharacterController charcont;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(this);

    }

    private void Awake()
    {
        currenttarget = gameObject;
        cam = Camera.main;
    }

    void Update()
    {
        charcont.Move(GroundMove());

        if(Input.GetKeyDown(KeyCode.R))

        {
            
            LockOnTarget();
            eventmaker.Istargeting(currenttarget);
        
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            eventmaker.IsNotTargeting(gameObject);
        }

        
}
    /// <summary>
    /// a method specifically for the left/right, forward/backward movement. uses the inputAxis
    /// from the projectsettings for its behaviour. felt nice to modularize the controller a bit
    /// </summary>
    private Vector3 GroundMove()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        flatmove = (cam.transform.right+transform.right) * x + (cam.transform.forward+cam.transform.forward) * y;

        flatmove.y = 0;

        flatmove=speed*Time.deltaTime*flatmove.normalized;
        
        return flatmove;

    }




    //TODO:
    //will have to move this to the targeting script
    private void LockOnTarget()
    {
        if (targetsystem.totalnumberoftargets > 0)
        {
            //this is the gameobject of the target
            currenttarget = targetsystem.SelectnewTarget();
            
            Logging.Log("klicked");



            //this chunk will have to be made into it's own attack in an attack state machine
            //SphereCollider sphere = currenttarget.GetComponent<SphereCollider>();

            //Vector3 targetpoint = transform.position - currenttarget.transform.position;
            //targetpoint = currenttarget.transform.position + targetpoint.normalized * sphere.radius;
            
            //transform.DOMove(targetpoint, 0.5f);

        }

    }
    
}
