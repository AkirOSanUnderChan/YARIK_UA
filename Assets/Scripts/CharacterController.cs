using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterController : MonoBehaviour
{

    public int TESTING = 23;
    public RuntimeAnimatorController NormalAnimCntrl; // Аніматор контролер з анімаціями ходьби.

    private float horizontalMovement;
    private float verticalMovement;

    public float FUCKING_RAYKAST = 1.5f;

    public Vector3 jumpInt;
    // A field for the player's speed multiplier while jumping
    public float airMultiplier = 0.5f;
    public float jumpForce = 2.0f;
    public bool isOnGround;
    // A field for the player's running speed
    public float runningSpeed = 15f;
    public float speed = 5.0f;
    public float drag = 5f;

    private Rigidbody rb;
    private Animator anim;



    public bool WeaponIsActive = false;
    public int WeaponNum = 1;


    public GameObject FirstWeapon;
    public GameObject SecondWeapon;
    public GameObject ThirdWeapon;

    void Start()
    {
        WeaponIsActive = false;

        Animator anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = NormalAnimCntrl;
        Debug.Log("COLLISION ENTERED");

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        jumpInt = new Vector3(0.0f, 2.0f, 0.0f);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponNum = 1;
            WeaponIsActive = !WeaponIsActive;
            if (!WeaponIsActive)
            {
                idle();
            }
        }

        if (WeaponIsActive)
        {
            if (WeaponNum >= 1)
            {
                
                Gun1Things();
                FirstWeapon.SetActive(true);
                SecondWeapon.SetActive(false);
                ThirdWeapon.SetActive(false);
            }
        }
        else
        {
            WeaponIsActive = false;
            FirstWeapon.SetActive(false);
            SecondWeapon.SetActive(false);
            ThirdWeapon.SetActive(false);
            MovementAndAnimationUpdate();
        }


        float gameObjectHeight = gameObject.transform.localScale.y;
        isOnGround = Physics.Raycast(transform.position, Vector3.down, gameObjectHeight - FUCKING_RAYKAST);
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        Vector3 movementDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
        if (isOnGround)
        {
            rb.drag = 5f;
        }
        else
        {
            movementDirection *= airMultiplier;
            rb.drag = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(movementDirection * runningSpeed, ForceMode.Force);
        }
        else
        {
            rb.AddForce(movementDirection * speed, ForceMode.Force);
        }
        rb.drag = drag;
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            jump();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    public void Gun1Things()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            gun_walkForward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            gun_walkLeft();
        }
        if (Input.GetKey(KeyCode.S))
        {
            gun_walkBack();
        }
        if (Input.GetKey(KeyCode.D))
        {
            gun_walkRight();
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            shoot_11();
        }
        if (WeaponIsActive)
        {
            if (!Input.anyKey)
            {
                gun_idle();
            }
        }
        
    }


    public void MovementAndAnimationUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run();
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                walkForward();
            }
            else
            {
                run();
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            walkLeft();
        }
        if (Input.GetKey(KeyCode.S))
        {
            walkBack();
        }
        if (Input.GetKey(KeyCode.D))
        {
            walkRight();
        }
        if (!Input.anyKey)
        {
            idle();
        }
    }
    public void idle()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("sh", false);

        anim.SetBool("gun_idle", false);
        anim.SetBool("gun_walkL", false);
        anim.SetBool("gun_walkR", false);
        anim.SetBool("gun_walkF", false);
        anim.SetBool("gun_walkB", false);

        anim.SetBool("idle", true);
        anim.SetBool("walkF", false);
        anim.SetBool("walkB", false);
        anim.SetBool("walkL", false);
        anim.SetBool("walkR", false);
        anim.SetBool("jump", false);
        anim.SetBool("run", false);

    }
    public void walkForward()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("sh", false);

        anim.SetBool("gun_idle", false);
        anim.SetBool("gun_walkL", false);
        anim.SetBool("gun_walkR", false);
        anim.SetBool("gun_walkF", false);
        anim.SetBool("gun_walkB", false);

        anim.SetBool("idle", false);
        anim.SetBool("walkF", true);
        anim.SetBool("walkB", false);
        anim.SetBool("walkL", false);
        anim.SetBool("walkR", false);
        anim.SetBool("jump", false);
        anim.SetBool("run", false);

    }
    public void walkBack()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("sh", false);

        anim.SetBool("gun_idle", false);
        anim.SetBool("gun_walkL", false);
        anim.SetBool("gun_walkR", false);
        anim.SetBool("gun_walkF", false);
        anim.SetBool("gun_walkB", false);

        anim.SetBool("idle", false);
        anim.SetBool("walkF", false);
        anim.SetBool("walkB", true);
        anim.SetBool("walkL", false);
        anim.SetBool("walkR", false);
        anim.SetBool("jump", false);
        anim.SetBool("run", false);


    }
    public void walkLeft()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("sh", false);

        anim.SetBool("gun_idle", false);
        anim.SetBool("gun_walkL", false);
        anim.SetBool("gun_walkR", false);
        anim.SetBool("gun_walkF", false);
        anim.SetBool("gun_walkB", false);

        anim.SetBool("idle", false);
        anim.SetBool("walkF", false);
        anim.SetBool("walkB", false);
        anim.SetBool("walkL", true);
        anim.SetBool("walkR", false);
        anim.SetBool("jump", false);
        anim.SetBool("run", false);

    }
    public void walkRight()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("sh", false);

        anim.SetBool("gun_idle", false);
        anim.SetBool("gun_walkL", false);
        anim.SetBool("gun_walkR", false);
        anim.SetBool("gun_walkF", false);
        anim.SetBool("gun_walkB", false);

        anim.SetBool("idle", false);
        anim.SetBool("walkF", false);
        anim.SetBool("walkB", false);
        anim.SetBool("walkL", false);
        anim.SetBool("walkR", true);
        anim.SetBool("jump", false);
        anim.SetBool("run", false);

    }
    public void jump()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("sh", false);

        anim.SetBool("gun_idle", false);
        anim.SetBool("gun_walkL", false);
        anim.SetBool("gun_walkR", false);
        anim.SetBool("gun_walkF", false);
        anim.SetBool("gun_walkB", false);

        anim.SetBool("idle", false);
        anim.SetBool("walkF", false);
        anim.SetBool("walkB", false);
        anim.SetBool("walkL", false);
        anim.SetBool("walkR", false);
        anim.SetBool("jump", true);
        anim.SetBool("run", false);


    }
    public void run()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("sh", false);

        anim.SetBool("gun_idle", false);
        anim.SetBool("gun_walkL", false);
        anim.SetBool("gun_walkR", false);
        anim.SetBool("gun_walkF", false);
        anim.SetBool("gun_walkB", false);

        anim.SetBool("idle", false);
        anim.SetBool("walkF", false);
        anim.SetBool("walkB", false);
        anim.SetBool("walkL", false);
        anim.SetBool("walkR", false);
        anim.SetBool("jump", false);
        anim.SetBool("run", true);

    }


    /// ///////////////////////////////////////////////////////////////////////////////// GUN ANIMATIONS _+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_+_
  

    public void gun_idle()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("sh", false);

        anim.SetBool("gun_idle", true);
        anim.SetBool("gun_walkL", false);
        anim.SetBool("gun_walkR", false);
        anim.SetBool("gun_walkF", false);
        anim.SetBool("gun_walkB", false);

        anim.SetBool("idle", false);
        anim.SetBool("walkF", false);
        anim.SetBool("walkB", false);
        anim.SetBool("walkL", false);
        anim.SetBool("walkR", false);
        anim.SetBool("jump", false);
        anim.SetBool("run", false);

    }
    public void gun_walkForward()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("sh", false);

        anim.SetBool("gun_idle", false);
        anim.SetBool("gun_walkL", false);
        anim.SetBool("gun_walkR", false);
        anim.SetBool("gun_walkF", true);
        anim.SetBool("gun_walkB", false);

        anim.SetBool("idle", false);
        anim.SetBool("walkF", false);
        anim.SetBool("walkB", false);
        anim.SetBool("walkL", false);
        anim.SetBool("walkR", false);
        anim.SetBool("jump", false);
        anim.SetBool("run", false);

    }
    public void gun_walkBack()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("sh", false);

        anim.SetBool("gun_idle", false);
        anim.SetBool("gun_walkL", false);
        anim.SetBool("gun_walkR", false);
        anim.SetBool("gun_walkF", false);
        anim.SetBool("gun_walkB", true);

        anim.SetBool("idle", false);
        anim.SetBool("walkF", false);
        anim.SetBool("walkB", false);
        anim.SetBool("walkL", false);
        anim.SetBool("walkR", false);
        anim.SetBool("jump", false);
        anim.SetBool("run", false);


    }
    public void gun_walkLeft()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("sh", false);

        anim.SetBool("gun_idle", false);
        anim.SetBool("gun_walkL", true);
        anim.SetBool("gun_walkR", false);
        anim.SetBool("gun_walkF", false);
        anim.SetBool("gun_walkB", false);

        anim.SetBool("idle", false);
        anim.SetBool("walkF", false);
        anim.SetBool("walkB", false);
        anim.SetBool("walkL", false);
        anim.SetBool("walkR", false);
        anim.SetBool("jump", false);
        anim.SetBool("run", false);

    }
    public void gun_walkRight()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("sh", false);

        anim.SetBool("gun_idle", false);
        anim.SetBool("gun_walkL", false);
        anim.SetBool("gun_walkR", true);
        anim.SetBool("gun_walkF", false);
        anim.SetBool("gun_walkB", false);

        anim.SetBool("idle", false);
        anim.SetBool("walkF", false);
        anim.SetBool("walkB", false);
        anim.SetBool("walkL", false);
        anim.SetBool("walkR", false);
        anim.SetBool("jump", false);
        anim.SetBool("run", false);

    }
    public void shoot_11()
    {
        //anim.SetBool("sh", true);

        //anim.SetBool("gun_idle", false);
        //anim.SetBool("gun_walkL", false);
        //anim.SetBool("gun_walkR", false);
        //anim.SetBool("gun_walkF", false);
        //anim.SetBool("gun_walkB", false);

        //anim.SetBool("idle", false);
        //anim.SetBool("walkF", false);
        //anim.SetBool("walkB", false);
        //anim.SetBool("walkL", false);
        //anim.SetBool("walkR", false);
        //anim.SetBool("jump", false);
        //anim.SetBool("run", false);
    }



    private void OnCollisionEnter(Collision collision)
    {
        Animator anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = NormalAnimCntrl;
        Debug.Log("COLLISION ENTERED");


    }
}