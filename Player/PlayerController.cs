using UnityEngine;
using Unity.Netcode;
using UnityEditor.Animations;
using System.Collections;

public class PlayerController : NetworkBehaviour 
{

    private Vector3 flatmove;
    private bool isgrounded;
    public float speed=2;
    float yvel;

    [SerializeField] EnvironmentData enviroment;
    [SerializeField] float jumppowah;    
    [SerializeField] private EventMaker eventmaker;
    [SerializeField] Targeting targetsystem;
    [SerializeField] private CharacterController charcont;
    public GameObject currenttarget;
    [SerializeField] private Animator animcont;
    Camera cam;
    [SerializeField] Transform gfx;


    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(this);

    }

    private void Awake()
    {
        currenttarget = gameObject;

        cam = Camera.main;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(gameObject.transform.position+Vector3.down, 0.1f);
    }

    void Update()
    {

        charcont.Move(GroundMove()*Time.deltaTime);
        charcont.Move(yvel* Vector3.up);
     

        GroundCheck();

        SetAnimation();

        if(Input.GetKeyDown(KeyCode.R)&&LockOnTarget())

        { 
                eventmaker.Istargeting(currenttarget);        
        
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            eventmaker.IsNotTargeting(gameObject);
            currenttarget = null;
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

        if (flatmove.sqrMagnitude > 0.1)
        {
            float rotangle = Mathf.Atan2(flatmove.y, flatmove.x);
            gfx.rotation = Quaternion.Euler(0, rotangle * Mathf.Rad2Deg, 0);
        }
        flatmove.y = 0;
        
        
        
        flatmove=speed*flatmove.normalized;

        


        return flatmove;
    }

   void Jump()
    {
        yvel = jumppowah;


    }


    void GroundCheck()
    {
        isgrounded = Physics.SphereCast(gameObject.transform.position+Vector3.down, 0.02f, Vector3.down, out _, (int)enviroment.environmentlayer, 1);
        

        if( isgrounded&& yvel<0 )
            yvel = 0;
        
        else yvel-=  4f *Time.deltaTime;

        yvel = Mathf.Clamp(yvel, -10, jumppowah);

    }


    //TODO:
    //will have to move this to the targeting script
    private bool LockOnTarget()
    {
        bool hastar = false;
        if (targetsystem.totalnumberoftargets > 0)
        {
            //this is the gameobject of the target
            currenttarget = targetsystem.SelectnewTarget();
            hastar = true;
            Logging.Log("klicked");



            //this chunk will have to be made into it's own attack in an attack state machine
            //SphereCollider sphere = currenttarget.GetComponent<SphereCollider>();

            //Vector3 targetpoint = transform.position - currenttarget.transform.position;
            //targetpoint = currenttarget.transform.position + targetpoint.normalized * sphere.radius;
            
            //transform.DOMove(targetpoint, 0.5f);

        }
        return hastar;
    }    



    private void SetAnimation() 
    {
        animcont.SetFloat("S", flatmove.sqrMagnitude*64);

        //switch(flatmove.sqrMagnitude) 
        //{
        //    case 0:
        //        {animcont.CrossFade("Idle",0.2f); break; }
                
        //    default: { animcont.CrossFade("Run", 0.2f);break; }

        //}

        if (Input.GetKeyDown(KeyCode.Escape)) { animcont.CrossFade("Swing", 0.2f); }


        //if (Input.GetKey(KeyCode.W)) {
        //    animcont.CrossFade("Run",0.2f);
        //}

        //if(Input.GetKey(KeyCode.S))
        //{

        //}
    }
}
