using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangBall : PlayerAbility
{
    public override void Beginning()
    {
        base.Beginning();
        GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

}
