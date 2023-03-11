using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionDetector : MonoBehaviour
{
    public int damage = 20;
    public WeaponController wc;
    //public GameObject HitParticle;
    public Player player;

    void EnableCollider()
    {
        Collider myCollider = GetComponent<Collider>();
        myCollider.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        Collider myCollider = GetComponent<Collider>();
        if (other.tag=="Enemy" && wc.isAttacking && enemy != null)
        {
            //Instantiate(HitParticle, new Vector3(
            //other.transform.position.x, 
            //    transform.position.y, 
            //  other.transform.position.z),
            //other.transform.rotation);
            enemy.TakeDamage(damage);
            myCollider.enabled = false;
            Invoke("EnableCollider", 1f);


        }

        
    }

   
}
