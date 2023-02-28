using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovePlayer : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;

    public Transform ground;
    public float distance = 0.3f;

    public float speed;
    public float jumpHeight;
    public float gravity;

    public LayerMask mask;

    private void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    private void Update()
    {
        #region Movemnet
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);
        #endregion

        #region Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight *  -3.0f * gravity);
        }
        #endregion

        #region Gravity

        isGrounded = Physics.CheckSphere(ground.position, distance, mask);
    
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        #endregion
    }
}
