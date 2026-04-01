using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;
    private float MaxRot = 45f;
    private float MinRot = -45f;
    public float PlayerHealth = 100;
    private float MaxHealth = 100;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask FloorMask; 
    [SerializeField] private LayerMask WallMask; 
    [SerializeField] private Image HealthBar; 
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float Jumpforce;
    [SerializeField] private bool InAir = false;
    [SerializeField] private bool CanWallJump = false;
    [SerializeField] private bool temp = true;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       UnityEngine.Cursor.lockState = CursorLockMode.Locked;  
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.CheckSphere(GroundCheck.position, 0.2f, FloorMask))
        {
            InAir = false;
        }
        else
        {
            InAir = true;
        }
            MovePlayer();
        MovePlayerCamera();
        
        HealthBar.fillAmount = PlayerHealth / MaxHealth;
    }

   

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
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
        if (InAir == false)
        {
            PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse);
            CanWallJump = true;


        } else if (Physics.CheckSphere(transform.position, 1f, WallMask) && CanWallJump)
        {
            PlayerBody.AddForce(Vector3.up * Jumpforce * 2, ForceMode.Impulse);
            CanWallJump = false;
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


   public void Heal()
    {
        PlayerHealth += 20;
        Debug.Log("Healed");
    }

}
