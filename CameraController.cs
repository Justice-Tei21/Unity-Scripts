
using Cinemachine;
using UnityEngine;
using UnityEngine.WSA;

public class CameraController : MonoBehaviour
{

    

    [SerializeField] Canvas recticanvas;
    
    [SerializeField] Transform lookobject;

    [SerializeField] Animator cinemachineanimator;

    [SerializeField] CinemachineVirtualCamera lookcam;

    
    
    
    

    [SerializeField] EventMaker eventmaker;





    /*private void Awake()
    {
        
        Logging.Log("<color=red> cameraa controler starts</color>");
        eventmaker.onlookattarget.AddListener(changetarget);
        eventmaker.ontargetfalse.AddListener(targetingOff);
        
        
    }*/

   



    //listens for the lock on and loch of events individualy
    private void OnEnable()
    {
        eventmaker.onlookattarget.AddListener(ChangeTarget);
        eventmaker.ontargetfalse.AddListener(TargetingOff);
        Logging.Log("yehaw!");
    }

    private void OnDisable()
    {
        eventmaker.onlookattarget.RemoveListener(ChangeTarget);
        eventmaker.ontargetfalse.RemoveListener(TargetingOff);
    }

    //change the target and and control the recticle
    public void ChangeTarget(GameObject lookat)
    {
        recticanvas.gameObject.SetActive(true);
        Logging.Log("yo angelo");

        lookobject = lookat.transform;
        
        lookcam.LookAt = lookobject;
        cinemachineanimator.Play("lock on camera");              
    }

    //switch to regular camera and turn of recticle
    public void TargetingOff(GameObject player)
    {
        recticanvas.gameObject.SetActive(false);
        lookobject = player.transform;
        cinemachineanimator.Play("free look camera");        
    }
}
