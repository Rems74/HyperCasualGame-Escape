using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;

    private bool isDead = false;
    private Animator m_Animator;
    float moveSpeed = 0;

    Vector3 moveDirection;
    Vector3 aimDirection;

    [SerializeField] float speedMax = 10f;
    [SerializeField] float acceleration = 0.1f;
    [SerializeField] float decceleration = 0.1f;
    [SerializeField] LayerMask enviroLayerMask;
    [SerializeField] AudioClip music;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponentInChildren<Animator>();
        m_Animator.GetComponent<Animator>().enabled = false;
        GetComponent<AudioSource>().PlayOneShot(music);
    }

    // Update is called once per frame
    void Update()
    {
        //Vecteur de direction

        if (joystick.Direction.magnitude > 0)
        {
            moveDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y).normalized;
            moveSpeed = Mathf.Lerp(moveSpeed, speedMax, acceleration) * joystick.Direction.magnitude;
            m_Animator.GetComponent<Animator>().enabled = true;
            if (joystick.Direction.y >= 0)
            {
                transform.eulerAngles = new Vector3(0, joystick.Direction.x * 90, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, (joystick.Direction.x * -90) + 180, 0);
            }

            
            
        }

        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, decceleration);
            m_Animator.GetComponent<Animator>().enabled = false;

        }
        aimDirection = moveDirection;
    }

    private void FixedUpdate()
    {
        if(isDead == false)
        {
            //velocité=direction*vitesse*inclinaison du baton de joie
            rb.velocity = moveDirection * moveSpeed;
        }
    }

    public void GameOver()
    {
        isDead = true;
        rb.velocity = new Vector3 (0, 0, 0);
    }

}
