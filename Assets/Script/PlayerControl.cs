using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitiv = 3.5f;
    [SerializeField] float walkspeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField] [Range(0.0f, 0.5f)]float moveSmooth = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)]float mouseSmooth = 0.3f;
    [SerializeField] bool lockCursor = true;
    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
    private Vector2 targetDir;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
    }
    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmooth);
        cameraPitch -= currentMouseDelta.y * mouseSensitiv;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitiv);
    }
    void UpdateMovement()
    {
        Vector2 inputDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputDir.Normalize();

        currentDirVelocity = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmooth);

        if (controller.isGrounded)
        velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * inputDir.y + transform.right * inputDir.x) * walkspeed + Vector3.up *velocityY;
        controller.Move(velocity * Time.deltaTime);
    }
}
