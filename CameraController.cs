
using Cinemachine;
using UnityEngine;



public class CameraController : MonoBehaviour
{

    [SerializeField] bool istargeting;

    [SerializeField] Canvas recticanvas;
    
    [SerializeField] Transform lookobject;

    [SerializeField] Animator cinemachineanimator;

    [SerializeField] CinemachineVirtualCamera lookcam;

    
    
    
    

    public EventMaker eventmaker;
    

    


    /*private void Awake()
    {
        
        Debug.Log("<color=red> cameraa controler starts</color>");
        eventmaker.onlookattarget.AddListener(changetarget);
        eventmaker.ontargetfalse.AddListener(targetingOff);
        
        
    }*/

    // Update is called once per frame
    

    private void OnEnable()
    {
        eventmaker.onlookattarget.AddListener(ChangeTarget);
        eventmaker.ontargetfalse.AddListener(TargetingOff);
        Debug.Log("yehaw!");
    }

    private void OnDisable()
    {
        eventmaker.onlookattarget.RemoveListener(ChangeTarget);
        eventmaker.ontargetfalse.RemoveListener(TargetingOff);
    }

    public void ChangeTarget(GameObject lookat)
    {
        recticanvas.gameObject.SetActive(true);
        Debug.Log("yo angelo");

        lookobject = lookat.transform;
        
        lookcam.LookAt = lookobject;
        cinemachineanimator.Play("lock on camera");

        
        
    }

    public void TargetingOff(GameObject player)
    {
        recticanvas.gameObject.SetActive(false);
        lookobject = player.transform;
        cinemachineanimator.Play("free look camera");
        
    }
}
