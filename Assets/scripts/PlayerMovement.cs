using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Variables:")]
    public float moveSpeed = 5f;
    Vector2 moveDirection;
    Vector2 mousePos;

    [Header("Player Componenets:")]
    private Rigidbody2D rb;

    [Header("Camera:")]
    public Camera cam;

    [Header("Player Sprite:")]
    public Transform playerTrans;

    [Header("Controller Object:")]
    public Transform controllerTrans;

    [Header("Animator Controller:")]
    public Animator anim;

    public float rbAngle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        mousePos =  cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 player = new Vector3(playerTrans.position.x, playerTrans.position.y, playerTrans.position.z);

        cam.transform.position = new Vector3(player.x, player.y, -10f);
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        playerTrans.position = controllerTrans.position;

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rbAngle = angle;

        WalkCheck();

    }
     public void AnimCheck()
     {
        if(rbAngle <= 40f && rbAngle > -40f)
        {
            anim.Play("back");
        }else if (rbAngle > 40f && rbAngle <= 90f)
        {
            anim.Play("left");
        }else if( rbAngle >= -270f &&  rbAngle < -210f)
        {
            anim.Play("left");
        }else if(rbAngle >= -210f && rbAngle < -180f)
        {
            anim.Play("front");
        }else if(rbAngle >= -180f && rbAngle < 45f)
        {
            anim.Play("right");
        }
     }
    public void WalkCheck()
    {
        bool wPressed = Input.GetKey(KeyCode.W);
        bool aPressed = Input.GetKey(KeyCode.A);
        bool sPressed = Input.GetKey(KeyCode.S);
        bool dPressed = Input.GetKey(KeyCode.D);

        if(!wPressed && !aPressed && !sPressed && !dPressed)
        {
            anim.Play("idle");
        }else if (wPressed ||  aPressed || sPressed || dPressed)
        {
            AnimCheck();
        }
    }
}
