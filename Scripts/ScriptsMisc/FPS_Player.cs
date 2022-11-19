using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Player : MonoBehaviour
{
    private Rigidbody _rb;
    public LayerMask groundMask;
    public float jumpForce = 6f;
    public bool isSprinting = false;
    public float sprintingMultiplier;
    public bool isCrouching = false;

    #region Camera
    public Camera _cam;
    private Vector3 camFwd;
    #endregion


    #region Movement
    [Range(1.0f, 10.0f)]
    public float walk_speed = 5f;
    [Range(1.0f, 10.0f)]
    public float backwards_walk_speed = 5f;
    [Range(1.0f, 10.0f)]
    public float strafe_speed = 5f;

    [Range(2.0f, 10.0f)]
    public float jump_force = 5f;
    #endregion


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        _rb = GetComponent<Rigidbody>();

        Save save = SaveManager.LoadSave();
        if (save != null)
        {
            transform.position = new Vector3(save.position[0], save.position[1], save.position[2]);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        SaveManager.SavePlayerData(this);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }


    }
    void Jump()
    {
        if (IsTouchingTheGround())
        {
            _rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        }
    }


    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        camFwd = Vector3.Scale(_cam.transform.forward, new Vector3(1, 1, 1)).normalized;
        Vector3 camFlatFwd = Vector3.Scale(_cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 flatRight = new Vector3(_cam.transform.right.x, 0, _cam.transform.right.z);

        Vector3 m_CharForward = Vector3.Scale(camFlatFwd, new Vector3(1, 0, 1)).normalized;
        Vector3 m_CharRight = Vector3.Scale(flatRight, new Vector3(1, 0, 1)).normalized;


        Debug.DrawLine(transform.position, transform.position + camFwd * 5f, Color.red);

        float w_speed = (v > 0) ? walk_speed : backwards_walk_speed;
        Vector3 move = v * m_CharForward * w_speed + h * m_CharRight * strafe_speed;
        transform.position += move * Time.deltaTime;

        /*if (isSprinting == true && isCrouching == false)
        {
            _rb.velocity = move * sprintingMultiplier;


        }
        else
        {
            transform.position += move * Time.deltaTime;
        }*/
        if (isCrouching == true)
        {
            transform.localScale = new Vector3(1f, 0.75f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }


    }
    bool IsTouchingTheGround()
    {
        if (Physics.Raycast(this.transform.position, Vector2.down, 1.5f, groundMask))
        {
            Debug.Log("true");
            return true;
        }
        else
        {
            Debug.Log("false");
            return false;
        }
    }
}
