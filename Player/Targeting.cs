using ParrelSync.NonCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;





public class Targeting : MonoBehaviour
{
    
    public int totalnumberoftargets;
    private List<GameObject> m_candidatetargetsList = new();
    private List<GameObject> sorted_candidateList = new();
    private GameObject targetclosesettocamera;
    [SerializeField] private SphereCollider zone;

    
    


    // selects the gameobject closest to the centre of the camera
    public GameObject SelectnewTarget()
    {  
        //RemoveEmptyTargets();

        
        sorted_candidateList = m_candidatetargetsList.OrderBy(gameobjects =>
       { 
            /*imagine a line going from the camera to the way it's facing, imagine another line going
              from the camera to the nearest target. now measure the angle between them,
              */

            Vector3 tar_dir = gameobjects.transform.position - Camera.main.transform.position;

            Vector3 cam_dir = Camera.main.transform.forward;


            float angle =  Vector3.Angle(cam_dir, tar_dir);

            
            return angle;
        }).ToList();


        m_candidatetargetsList = sorted_candidateList;
        
        targetclosesettocamera = m_candidatetargetsList[0];
        return targetclosesettocamera;
    }


    //finds colliders in range with a spherecast
    private void Update()
    {

        m_candidatetargetsList.Clear();
        Collider[] hitthing = Physics.OverlapSphere(transform.position, zone.radius);
        
        
        for(int i = 0; i < hitthing.Length; i++)
        {
            GameObject objecto = hitthing[i].gameObject;

            if (objecto.CompareTag("targetable"))
            {
                m_candidatetargetsList.Add(objecto);
                totalnumberoftargets++;
                
            }
        }
        totalnumberoftargets = m_candidatetargetsList.Count;
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("targetable"))
        {
            m_candidatetargetsList.Add(other.gameObject);
            totalnumberoftargets++;
            Logging.Log("entered");
            
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("targetable"))
        {
            m_candidatetargetsList.Add(other.gameObject);
            totalnumberoftargets--;
        }        
    }*/

    /// <summary>
    /// This method will check for when a gameobject exits the targeting range without moving out
    /// .like when you kill or disble an enemy. 
    /// </summary>
    public bool RemoveEmptyTargets()

    {

        bool hasnulls= false;
        for(int i= 0; i < m_candidatetargetsList.Count; i++)
        {
            if (m_candidatetargetsList[i] == null || !m_candidatetargetsList[i].activeInHierarchy)
            {
                m_candidatetargetsList.RemoveAt(i);
                totalnumberoftargets--;
                hasnulls = true;
            }
        }
        return hasnulls;
    }


}
