using UnityEngine;
using System.Collections;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;

    private bool canJump;

    private float speed;

	// Use this for initialization
	void Start()
	{
        canJump = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        speed = Utils.SpeedByDifficulty(Constantes.baseSpeedCharacter);

    }

	// Update is called once per frame
	void Update()
	{
        if (Shared.GetPause()) return;
        if (Shared.GetKeyboard())
        {
            ConfigKeyBoard();
        }
        else
        {
            ConfigArrow();
        }

    }

    //Try to add gravity at the end of jump
    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * Constantes.fallMutiplier * Time.deltaTime;
        }
    }

    //Deplacement with ZQSD
    private void ConfigKeyBoard()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Left();
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            Right();
        }

        if (Input.GetKey(KeyCode.Z) && canJump)
        {
            rb.AddForce(new Vector3(0, Constantes.baseForceJump, 0), ForceMode.Impulse);
            animator.SetBool("isJumping", true);
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    //Deplacement with arrow
    private void ConfigArrow()
    {
         if (Input.GetKey(KeyCode.LeftArrow))
        {
            Left();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Right();
        }

        if (Input.GetKey(KeyCode.UpArrow) && canJump)
        {
            rb.AddForce(new Vector3(0, Constantes.baseForceJump, 0), ForceMode.Impulse);
            animator.SetBool("isJumping", true);
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale = new Vector3(1, 0.5f, 1);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Left()
    {
        transform.Translate(Vector3.left * speed);
    }
    private void Right()
    {
        transform.Translate(Vector3.right * speed);
    }

    //When player tuch ground can jump again
    private void OnCollisionEnter(Collision collision)
    {
        var tag = collision.gameObject.tag;
        if ( tag == "ground")
        {
            canJump = true;
            animator.SetBool("isJumping", false);
        }
    }

}

