using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Scripts/Player Movement")]
public class PlayerMovement : MonoBehaviour
{
    private Vector3 movement = Vector3.zero;
    private CharacterController characterController;

    [SerializeField] private float speed = 4.0f;

    private void Start()
    {
        movement.y = -9.8f; // gravity
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // get user input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        
        movement *= MovingAdjustingValue();

        // clamping movement(especially diagonal) within speed value
        movement = Vector3.ClampMagnitude(movement, speed);

        // convert vector from local to global coordinates
        movement = transform.TransformDirection(movement);

        // charachterController have move a player
        characterController.Move(movement);
    }

    private float MovingAdjustingValue()
    {
        // adding speed and deltaTime for frame rate independent
        return speed * Time.deltaTime;
    }
}
