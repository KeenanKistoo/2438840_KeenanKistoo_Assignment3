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
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        mousePos =  cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        playerTrans.position = controllerTrans.position;

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        if (angle >= 0 && angle < 60f)
        {
            
            anim.Play("right");
        } else if (angle >= 60f && angle < 120f)
        {
            anim.Play("back");
        }else if(angle >= 120f && angle < 180f)
        {
            anim.Play("left");
        }else if(angle > -60f && angle <= 0)
        {
            anim.Play("right");
        }else if (angle > -120f && angle < -60f)
        {
            anim.Play("front");
        }else if(angle >= -180f && angle < -120f)
        {
            anim.Play("left");
        }
        else
        {
            anim.Play("idle");
        }
    }
}
