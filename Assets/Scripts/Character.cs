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

	private float speed;

	// Use this for initialization
	void Start()
	{
		//TODO : Intégrer une animation
        /*
		animator = GetComponent<Animator>();
		rigibody = GetComponent<Rigidbody>();
		running = false;
        */


        speed = 0.02f * Shared.GetDifficulty();
        Debug.Log(speed);
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

    private void ConfigKeyBoard()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Forward();
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            Left();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Backward();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Right();
        }
    }

    private void ConfigArrow()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Forward();

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Left();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Backward();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Right();
        }
    }

    private void Forward()
    {
        transform.Translate(Vector3.forward * speed);
    }

    private void Backward()
    {
        transform.Translate(Vector3.back * speed);
    }
    private void Left()
    {
        transform.Translate(Vector3.left * speed);
    }
    private void Right()
    {
        transform.Translate(Vector3.right * speed);
    }
}

