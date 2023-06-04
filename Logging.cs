using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Logging :  MonoBehaviour
{

    public static Logging instance;


  

     static bool Islogging=true;


    //turns off and on the debug logs globallyyb by being static
    

    public static void Log(object msg) {
    if(Islogging)
    Debug.Log(msg);
    
    }
}
