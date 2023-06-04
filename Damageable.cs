using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    

    Animator animator;
    [SerializeField] string hitanimation;
    [SerializeField] Statistics status;



    private void Start()
    {
        status=gameObject.GetComponent<Statistics>();
        this.animator = GetComponent<Animator>();
        
    }

    //will call yhe statistics to say that damage has been dealt
    public void HitThis(int damage)
    {
        
        status.HealthChanged(damage);

        animator.CrossFade(hitanimation,0.4f);

    }
    



}
