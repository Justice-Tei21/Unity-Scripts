using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalZZero : MonoBehaviour
{
    

    //springanimationen fortsatte att röra spelaren fram
    void Update()
    {
        transform.localPosition = Vector3.zero;
    }
}
