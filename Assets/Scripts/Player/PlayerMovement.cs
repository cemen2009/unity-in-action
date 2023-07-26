using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Scripts/Player Movement")]
public class PlayerMovement : MonoBehaviour
{
    private Vector3 movement = new Vector3();
    private CharacterController characterController;

    [SerializeField] private float speed = 4.0f;
    private float gravity = -9.8f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // get user input
        movement.x = Input.GetAxisRaw("Horizontal") * speed* Time.deltaTime;    
        movement.z = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        // clamping movement(especially diagonal) within speed value
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        // convert vector from local to global coordinates
        movement = transform.TransformDirection(movement);

        // charachterController have move a player
        characterController.Move(movement);
    }
}
