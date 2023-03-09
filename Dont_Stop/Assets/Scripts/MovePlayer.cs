using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovePlayer : MonoBehaviour
{
    CharacterController controller;
    public Vector3 velocity;
    public bool isGrounded;

    public Transform ground;
    public float distance = 0.3f;

    public float speed;
    public float jumpHeight;
    public float gravity;
    public Vector3 lastPosition;
    public float currentSpeed;

    public LayerMask mask;

    private void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    private void Update()
    {
        // Store the player's current position before moving
        lastPosition = transform.position;
        #region Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        move = Vector3.ClampMagnitude(move, 1f);
        controller.Move(move * speed * Time.deltaTime);

        // Calculate player's speed using the distance travelled during this frame
        currentSpeed = (transform.position - lastPosition).magnitude / Time.deltaTime;
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
