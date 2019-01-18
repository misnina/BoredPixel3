﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private LerpHelper lerp;
    private Animator anim;
    private SpriteRenderer sp;

    private bool moveFinished = true;
    private bool falling;
    private float fallingSpeed;
    private float speed = 0.2f;
    private int dmg;
    public bool canMove = true;

    RaycastHit2D hitdown;
    RaycastHit2D hitup;
    RaycastHit2D hitright;
    RaycastHit2D hitleft;


    public Vector3 bottomLeft;
    public Vector3 topRight;

    public static PlayerController instance;


    void Awake()
    {
        instance = this;

        rb = GetComponent<Rigidbody2D>();
        lerp = GetComponent<LerpHelper>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();

        bottomLeft = new Vector3(0, 0, 0);
        topRight = new Vector3(50.5f, 110.5f, 0);
    }

    void Update()
    {
        if  (canMove)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeft.x, topRight.x), Mathf.Clamp(transform.position.y, bottomLeft.y, topRight.y), transform.position.z);

            hitdown = Physics2D.Raycast(transform.position, Vector2.down, 1);
            hitup = Physics2D.Raycast(transform.position, Vector2.up, 1);
            hitright = Physics2D.Raycast(transform.position, Vector2.right, 1);
            hitleft = Physics2D.Raycast(transform.position, Vector2.left, 1);

            //Animators

            if (Input.GetKey(KeyCode.W))
            {
                anim.SetTrigger("startflying");
                anim.SetBool("flying", true);
            }
            else
            {
                anim.SetBool("flying", false);
                anim.ResetTrigger("startflying");
            }

            if (Input.GetKey(KeyCode.D))
            {
                sp.flipX = false;
                anim.SetBool("digging", true);

            }
            else if (Input.GetKey(KeyCode.A))
            {
                sp.flipX = true;
                anim.SetBool("digging", true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool("downdigging", true);
            }
            else
            {
                anim.SetBool("downdigging", false);
                anim.SetBool("digging", false);
            }


            //Fly Up
            if (Input.GetKey(KeyCode.W) && moveFinished)
            {
                dmg = 0;
                if (hitup.collider == null)
                {
                    Inventory.instance.fuel--;
                    StartMove();
                    lerp.endPosition = transform.position + Vector3.up;
                    lerp.lerpTime = speed;
                    LerpSetup();

                }
            }
            //Dig Down
            if (Input.GetKey(KeyCode.S) && moveFinished && !falling)
            {

                if (hitdown.collider != null && hitdown.collider.gameObject.tag == "Block")
                {
                    Inventory.instance.fuel--;
                    hitdown.collider.GetComponent<Destroy>().destroyed = true;
                    MoveDown();
                }
                else if (hitdown.collider != null && hitdown.collider.gameObject.tag == "Mineral")
                {
                    Inventory.instance.fuel--;
                    Mineral.instance.Mine(hitdown.collider);
                    hitdown.collider.GetComponent<Destroy>().destroyed = true;
                    MoveDown();
                }

            }

            //Dig Right
            if (Input.GetKey(KeyCode.D) && moveFinished && !falling)
            {
                Inventory.instance.fuel--;
                if (hitright.collider != null && hitright.collider.gameObject.tag == "Block" && !falling)
                {
                    Inventory.instance.fuel--;
                    hitright.collider.GetComponent<Destroy>().destroyed = true;
                    StartMove();
                    lerp.endPosition = transform.position + Vector3.right;
                    lerp.lerpTime = speed;
                    LerpSetup();
                }
                else if (hitright.collider != null && hitright.collider.gameObject.tag == "Mineral" && !falling)
                {
                    Inventory.instance.fuel--;
                    Mineral.instance.Mine(hitright.collider);
                    hitright.collider.GetComponent<Destroy>().destroyed = true;
                    StartMove();
                    lerp.endPosition = transform.position + Vector3.right;
                    lerp.lerpTime = speed;
                    LerpSetup();
                }
                else if (hitright.collider == null)
                {
                    Inventory.instance.fuel--;
                    StartMove();
                    lerp.endPosition = transform.position + Vector3.right;
                    lerp.lerpTime = speed;
                    LerpSetup();
                }

            }

            //Dig left
            if (Input.GetKey(KeyCode.A) && moveFinished && !falling)
            {
                Inventory.instance.fuel--;
                if (hitleft.collider != null && hitleft.collider.gameObject.tag == "Block" && !falling)
                {
                    Inventory.instance.fuel--;
                    hitleft.collider.GetComponent<Destroy>().destroyed = true;
                    StartMove();
                    lerp.endPosition = transform.position + Vector3.left;
                    lerp.lerpTime = speed;
                    LerpSetup();
                }
                else if (hitleft.collider != null && hitleft.collider.gameObject.tag == "Mineral" && !falling)
                {
                    Inventory.instance.fuel--;
                    Mineral.instance.Mine(hitleft.collider);
                    hitleft.collider.GetComponent<Destroy>().destroyed = true;
                    StartMove();
                    lerp.endPosition = transform.position + Vector3.left;
                    lerp.lerpTime = speed;
                    LerpSetup();
                }
                else if (hitleft.collider == null)
                {
                    Inventory.instance.fuel--;
                    StartMove();
                    lerp.endPosition = transform.position + Vector3.left;
                    lerp.lerpTime = speed;
                    LerpSetup();
                }

            }

            //fall if nothing under you
            if (moveFinished)
            {
                if (hitdown.collider == null)
                {
                    falling = true;
                    fallingSpeed = 0.1f;
                    FallingMove();
                    lerp.endPosition = transform.position + Vector3.down;
                    lerp.lerpTime = fallingSpeed;
                    LerpSetup();
                    Debug.Log(dmg);
                    dmg++;

                } else
                {
                    if (dmg > 5)
                    {
                        Inventory.instance.health--;
                        dmg = 0;
                    } 
                }

            }
            else
            {
                falling = false;

            }
        }

    }

    private void MoveDown()
    {
        StartMove();
        lerp.endPosition = transform.position + Vector3.down;
        LerpSetup();
    }

    private void LerpSetup()
    {
        lerp.startPosition = transform.position;
        lerp.StartLerping();
    }

    private void StartMove()
    {
        moveFinished = false;
        Invoke("EndMove", 0.2f);
    }

    private void FallingMove()
    {
        moveFinished = false;
        Invoke("EndMove", fallingSpeed);
    }

    private void EndMove()
    {
        moveFinished = true;
    }
   
}
