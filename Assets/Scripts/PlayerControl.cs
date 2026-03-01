using UnityEngine;

public class PlayerControl: MonoBehaviour
{
    public float speed = 5.0f;           
    public float sensitivity = 2.0f;       
    public float jumpHeight = 2.0f;         
    public float gravity = -9.81f;          

    private CharacterController characterController;
    private Camera playerCamera;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;

        MovePlayer();

        LookAround();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");   

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        characterController.Move(move * speed * Time.deltaTime);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        playerCamera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }
}
