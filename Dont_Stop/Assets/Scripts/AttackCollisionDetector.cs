using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollisionDetector : MonoBehaviour
{
    public GameObject HitParticle;
    public int damage = 20;
    public WeaponController wc;
    Collider myCollider;

    private void Start() 
    {
        myCollider = GetComponent<Collider>();
    }
    void EnableCollider()
    {
        myCollider.enabled = true;
    }
    void DisableCollider()
    {
        myCollider.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        Collider myCollider = GetComponent<Collider>();
        GameObject particleObject = GameObject.FindGameObjectWithTag("HitParticle");
        if (other.tag == "Enemy" && wc.attacking && enemy != null)
        {
            Instantiate(HitParticle, new Vector3(
            other.transform.position.x,
            transform.position.y,
            other.transform.position.z),
            other.transform.rotation);
            enemy.TakeDamage(damage);
            DisableCollider();
            Invoke("EnableCollider", wc.AttackCoolDown);
            Destroy(particleObject);


        }


    }

private void OnTriggerStay2D(Collider2D other) {
    
}

}
