using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    // Start is called before the first frame update

    protected AbilitySystem schema;
    public virtual void Beginning(){ }

    public virtual void AllUpdate() { }

    public virtual void Oncollision() { }
    public virtual void Ending() { }
}
