using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform mTarget;
    public float mSpeed = 10.0f;
    private Player player;
    private bool canDealDamage = true;
    public int damageAmount = 20;
    public float damageInterval = 1.0f;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        mTarget = GameObject.Find("PlayerObject").transform;
        transform.LookAt(mTarget);
        transform.Translate(0.0f, 0.0f, mSpeed * Time.deltaTime);
    }

    private IEnumerator DealDamage()
    {
        canDealDamage = false;
        player.TakeDamage(damageAmount);
        yield return new WaitForSeconds(damageInterval);
        canDealDamage = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && canDealDamage)
        {
            StartCoroutine(DealDamage());
        }
    }
}

