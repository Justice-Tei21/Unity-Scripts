using UnityEngine;
using Unity.Netcode;


public class PlayerController : NetworkBehaviour 
{

    private float jumpvel;
    private Vector3 flatmove;
    private bool isgrounded;
    public float speed=2;
    float yvel;

    [SerializeField] EnvironmentData enviroment;
    [SerializeField] float jumppowah;    
    [SerializeField] private EventMaker eventmaker;
    [SerializeField]Targeting targetsystem;
    [SerializeField] private CharacterController charcont;
    GameObject currenttarget;
    Camera cam;



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

        GroundCheck();

        if(Input.GetKeyDown(KeyCode.R))

        {


           
            LockOnTarget();
            eventmaker.Istargeting(currenttarget);
        
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            eventmaker.IsNotTargeting(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space)&& isgrounded)
        {
            Jump();
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

        flatmove = (cam.transform.right) * x + (cam.transform.forward) * y;

        flatmove.y = 0;

        flatmove=speed*Time.deltaTime*flatmove.normalized;
        
        return flatmove;
    }

   void Jump()
    {
        yvel = jumppowah;


    }


    void GroundCheck()
    {
        isgrounded = Physics.SphereCast(Vector3.down, 0.1f, Vector3.down, out _, (int)enviroment.environmentlayer, 1);

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
