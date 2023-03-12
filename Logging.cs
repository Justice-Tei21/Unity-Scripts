using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Logging :  MonoBehaviour
{

    public static Logging instance;


  

    [SerializeField] static bool Islogging=true;


    // Start is called before the first frame update

    //void Start()
    //{

        
    //    if (instance==null)
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //     Destroy(this);   

    //    }
    //}

    // Update is called once per frame
    

    public static void Log(string msg) {
    if(Islogging)
    Debug.Log(msg);
    
    }
}
