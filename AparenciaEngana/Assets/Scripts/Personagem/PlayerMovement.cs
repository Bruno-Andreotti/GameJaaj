using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller1;
    public Animator animator1;
    public CharacterController2D controller2;
    public Animator animator2;
    public AudioClip JumpClip;
    public AudioSource JumpSource;
    //public AudioClip LandClip;
    //public AudioSource LandSource;
    public float runSpeed = 40f;
    float HorizontalMove = 0f;
    bool jump=false;

    private void Start()
    {
        JumpSource.clip = JumpClip;
        //LandSource.clip = LandClip;
    }

    // Update is called once per frame
    void Update()
    {
        // GetComponent<Grab>().isHolding = true;
        HorizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator1.SetFloat("Speed",Mathf.Abs(HorizontalMove));
        animator2.SetFloat("Speed", Mathf.Abs(HorizontalMove));
        //if (HorizontalMove == 1f)
        //{
            
            
        //    WalkSource.Play();
            
        //}

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator1.SetBool("IsJumping", true);
            animator2.SetBool("IsJumping", true);

            //JumpSource.volume = 1.0f;
            //JumpSource.PlayOneShot(JumpClip);
            
        }
        /*if (GetComponent<Grab>().isHolding == true)
        {
            animator.SetBool("IsGrabbing", true);
        }
        else
        {
            animator.SetBool("IsGrabbing", false);
        }*/
    }

    public void OnLanding()
    {
        
            //LandSource.PlayOneShot(LandClip);
            animator1.SetBool("IsJumping", false);
            animator2.SetBool("IsJumping", false);
            
        
    }
    private void FixedUpdate()
    {
        //move character
        controller1.Move(HorizontalMove * Time.fixedDeltaTime, false, jump);
        controller2.Move(HorizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
