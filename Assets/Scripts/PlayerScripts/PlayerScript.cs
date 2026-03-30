using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;
    private float MaxRot = 45f;
    private float MinRot = -45f;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask FloorMask; 
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float Jumpforce;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       UnityEngine.Cursor.lockState = CursorLockMode.Locked;  
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        MovePlayerCamera();
    }

   private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        //Vector3 MoveVector = PlayerMovementInput * Speed;
        PlayerBody.linearVelocity = new Vector3(MoveVector.x, PlayerBody.linearVelocity.y, MoveVector.z);

    }

    private void MovePlayerCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;

        xRot = Mathf.Clamp(xRot, MinRot, MaxRot);
        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (Physics.CheckSphere(GroundCheck.position, 0.1f, FloorMask))
        {
            PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
        }
        

    }

    public void MoveInput(InputAction.CallbackContext ctx)
    {
        PlayerMovementInput = new Vector3(ctx.ReadValue<Vector2>().x, 0f, ctx.ReadValue<Vector2>().y);
    }

    public void MouseLookInput(InputAction.CallbackContext ctx)
    {
        PlayerMouseInput = new Vector2(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y);
    }

}
