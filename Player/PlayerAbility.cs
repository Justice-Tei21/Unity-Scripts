using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility:MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]protected AbilitySystem schema;
    public virtual void Beginning(){ }
    public virtual void Beginning(Vector3 playerpos, Vector3 otherpos, AbilityData data) { }

    public virtual void AllUpdate() { }

    public virtual void Oncollision() { }
    public virtual void Ending() { }
}
