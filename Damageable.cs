using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    // Start is called before the first frame update
    float maxhealth;
    float currenthealth;

    Animator animator;
    [SerializeField] string hitanimation;
    [SerializeField] Statistics status;



    private void Start()
    {
        status=gameObject.GetComponent<Statistics>();
        this.animator = GetComponent<Animator>();
    }

    public void HitThis(int damage)
    {

        status.HealthChanged(damage);

        animator.CrossFade(hitanimation,0.4f);

    }
    



}
