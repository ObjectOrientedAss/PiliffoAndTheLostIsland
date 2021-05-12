using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehaviour : MonoBehaviour
{
    public int Damage = 5;
    [HideInInspector]
    public bool CanDamage;
    [SerializeField]ParticleSystem HitVfx;


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (CanDamage)
    //    {
    //        if (gameObject.CompareTag("Enemy") && other.CompareTag("DamageCollider") || gameObject.CompareTag("Player") && other.CompareTag("DamageCollider_enemy"))
    //        {
    //            CanDamage = false;
    //            other.GetComponentInParent<LifeManager>().AddDamage(Damage);
    //            HitVfx.transform.position = transform.position;
    //            HitVfx.Play();
    //        }
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (CanDamage)
        {
            if (gameObject.CompareTag("Enemy") && other.CompareTag("DamageCollider") || gameObject.CompareTag("Player") && other.CompareTag("DamageCollider_enemy"))
            {
                CanDamage = false;
                other.GetComponentInParent<LifeManager>().AddDamage(Damage);
                HitVfx.transform.position = transform.position;
                HitVfx.Play();
            }
        }
    }
}


  
