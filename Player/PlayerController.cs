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

    //ig i turn it into multiplayer, this makes syre you only control your own controller
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
        //all the movement
        charcont.Move(GroundMove()*Time.deltaTime);
        charcont.Move(yvel* Vector3.up);
     

        GroundCheck();
        SetAnimation();

        //start targeting
        if(Input.GetKeyDown(KeyCode.R)&&LockOnTarget())

        { 
                eventmaker.Istargeting(currenttarget);        
        
        }
        
        //end targeting
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
            float rotangle = Mathf.Atan2(flatmove.x, flatmove.z);
            gfx.rotation = Quaternion.Euler(0, rotangle * Mathf.Rad2Deg, 0);
        }
        flatmove.y = 0;
        
        
        
        flatmove=speed*flatmove.normalized;


        return flatmove;
    }
    public void Jump()
    {
        yvel = jumppowah;
    }
    

    //spherecast on ground
    void GroundCheck()
    {
        isgrounded = Physics.SphereCast(gameObject.transform.position+Vector3.down, 0.02f, Vector3.down, out _, (int)enviroment.environmentlayer, 1);
        

        if( isgrounded&& yvel<0 )
            yvel = 0;
        
        else yvel-=  4f *Time.deltaTime;

        //yvel = Mathf.Clamp(yvel, -10, jumppowah);

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



            //this chunk will have to be made into part pg it's own attack 
            //SphereCollider sphere = currenttarget.GetComponent<SphereCollider>();

            //Vector3 targetpoint = transform.position - currenttarget.transform.position;
            //targetpoint = currenttarget.transform.position + targetpoint.normalized * sphere.radius;
            
            //transform.DOMove(targetpoint, 0.5f);

        }
        return hastar;
    }    


    //info for the animator, s for speed
    private void SetAnimation() 
    {
        animcont.SetFloat("S", flatmove.sqrMagnitude*64);

       

        //lines below are for attack strings,
        if (Input.GetKeyDown(KeyCode.Mouse0))  animcont.SetBool("attack", true); 


        //checks if animation is partially done
        if(animcont.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.4)
            animcont.SetBool("attack", false);


        
    }
}
