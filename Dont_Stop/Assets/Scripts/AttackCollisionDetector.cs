using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionDetector : MonoBehaviour
{
    public int damage = 20;
    public WeaponController wc;
    //public GameObject HitParticle;
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (other.tag=="Enemy" && wc.isAttacking && enemy != null)
        {
            //Instantiate(HitParticle, new Vector3(
            //other.transform.position.x, 
            //    transform.position.y, 
            //  other.transform.position.z),
            //other.transform.rotation);
            enemy.TakeDamage(damage);

        }
    }

   
}
