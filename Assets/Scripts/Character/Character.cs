using UnityEngine;
using System.Collections;
using UnityEngine.TextCore.Text;

public class Character : MonoBehaviour
{
    /*
	private Animator animator;
	private Rigidbody rigibody;

	private bool running;
    */

    private Rigidbody rb;
    private Animator animator;

    private bool canJump;

	// Use this for initialization
	void Start()
	{
        //TODO : Intégrer une animation
        /*
		animator = GetComponent<Animator>();
		rigibody = GetComponent<Rigidbody>();
		running = false;
        */
        canJump = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

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

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * Constantes.fallMutiplier * Time.deltaTime;
        }
    }

    private void ConfigKeyBoard()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Left();
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            Forward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Backward();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Right();
        }
        else if (Input.GetKey(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector3(0, Constantes.baseForceJump, 0), ForceMode.Impulse);
            animator.SetBool("isJumping", true);
            canJump = false;
        }
    }

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
    }

    private void Forward()
    {
        transform.Translate(Vector3.forward * Constantes.baseSpeedCharacter);
    }

    private void Backward()
    {
        transform.Translate(Vector3.back * Constantes.baseSpeedCharacter);
    }
    private void Left()
    {
        transform.Translate(Vector3.left * Constantes.baseSpeedCharacter);
    }
    private void Right()
    {
        transform.Translate(Vector3.right * Constantes.baseSpeedCharacter);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canJump = true;
            animator.SetBool("isJumping", false);
        }
    }
}

