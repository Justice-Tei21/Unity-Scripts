using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class SimpLockOn : MonoBehaviour
{
    [SerializeField]Transform targetobject;

    [SerializeField] EventMaker eventus;
    Vector3 targetangle;
    [SerializeField]Camera cam;

   
    //wants to find the target object
    private void Start()
    {
        cam = Camera.main;
        eventus.onlookattarget.AddListener(FindTransform);
    }

   
    private void OnEnable()
    {
        if(targetobject==null)
        targetobject=Camera.main.transform;
        StartCoroutine(LookAtTarget());
        
    }

    /*private void Update()
    {
        transform.position = targetobject.transform.position;

        LookAtCamTransform();
    }*/

    //moves the recticle to target
    private IEnumerator LookAtTarget()
    {
        while (gameObject.activeInHierarchy)
        {

            transform.position=targetobject.position;

            targetangle = cam.transform.position - transform.position;

            transform.rotation=Quaternion.LookRotation(targetangle);
            yield return null;
        }
    }

    void FindTransform(GameObject target)
    {
        targetobject = target.transform;
    }


}
