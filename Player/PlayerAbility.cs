using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility:MonoBehaviour
{


    // basicallly another basestate
    [SerializeField]protected AbilitySystem schema;

    public void SetSchema(AbilitySystem schema) { this.schema = schema; }

    public virtual void Beginning(){ }

    public virtual void AllUpdate() { }

    public virtual void Oncollision() { }

    public virtual bool Ending() { return false; }
}