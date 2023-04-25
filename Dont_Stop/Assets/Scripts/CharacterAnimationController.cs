using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            animator.SetBool("Walking", true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Running", true);
        }
        if(!Input.GetKey("w"))
        {
            animator.SetBool("Walking", false);
        }
        if(!Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Running", false);
        }
    }
}
