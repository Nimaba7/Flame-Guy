using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public CharacterController charCon;
    private CameraController cam;
    private Vector3 moveAmount;
    public float jumpForce, gravityScale;
    private float yStore;
    public bool isGrounded;
    public float rptateSpeed = 10f;
    public Animator anim;
    public GameObject jumpParticle;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = charCon.isGrounded;
        
        yStore = moveAmount.y;
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        //transform.Translate(moveX*moveSpeed*Time.deltaTime,transform.position.y,moveZ*moveSpeed*Time.deltaTime);
        moveAmount = cam.transform.forward * Input.GetAxisRaw("Vertical") +
                     cam.transform.right * Input.GetAxisRaw("Horizontal");
        moveAmount.y = 0f;
        moveAmount = moveAmount.normalized;

        if (moveAmount.magnitude > 0.1f)
        {
            if (moveAmount != Vector3.zero)
            {
                Quaternion newRot = Quaternion.LookRotation(moveAmount);
                transform.rotation = Quaternion.Slerp(transform.rotation, newRot, rptateSpeed * Time.deltaTime);
            }
        }
        moveAmount.y = yStore;

        if (charCon.isGrounded)
        {
            jumpParticle.SetActive(false);
            if (Input.GetButtonDown("Jump"))
            {
                moveAmount.y = jumpForce;
                jumpParticle.SetActive(true);
            }
        }
        charCon.Move(new Vector3(moveAmount.x*moveSpeed,moveAmount.y,moveAmount.z*moveSpeed)* Time.deltaTime);

        float moveVel = new Vector3(moveAmount.x, 0f, moveAmount.z).magnitude * moveSpeed;
        anim.SetFloat("speed",moveVel);
        anim.SetBool("isGrounded",charCon.isGrounded);
        anim.SetFloat("yVel",moveAmount.y);
    }
    
    private void FixedUpdate()
    {

        if (!charCon.isGrounded)
        {
            moveAmount.y = moveAmount.y + Physics.gravity.y*gravityScale * Time.fixedDeltaTime;
        }
        else
        {
            moveAmount.y = Physics.gravity.y *gravityScale* Time.deltaTime;
        }
    }
}