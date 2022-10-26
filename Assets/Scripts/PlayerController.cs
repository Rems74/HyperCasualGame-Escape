using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] DynamicJoystick joystick;

    Vector3 moveDirection;
    Vector3 aimDirection;
    float moveSpeed = 0;
    [SerializeField] float speedMax = 10f;
    [SerializeField] float acceleration = 0.1f;
    [SerializeField] float decceleration = 0.1f;
    [SerializeField] float smoothRotation = 0.1f;
    [SerializeField] LayerMask enviroLayerMask;

    //cache

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vecteur de direction

        if (joystick.Direction.magnitude > 0)
        {
            moveDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y).normalized;
            moveSpeed = Mathf.Lerp(moveSpeed, speedMax, acceleration) * joystick.Direction.magnitude;
        }

        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, decceleration);
        }
        aimDirection = moveDirection;
    }

    private void FixedUpdate()
    {
        //velocité=direction*vitesse*inclinaison du baton de joie
        rb.velocity = moveDirection * moveSpeed;

    }
}
