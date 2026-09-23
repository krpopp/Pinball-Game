using UnityEngine;
using UnityEngine.InputSystem;

public class BallControl : MonoBehaviour
{

    InputAction launchButton;
    Rigidbody2D myBody;

    SpriteRenderer myRenderer;

    float pressTime;
    bool launchBall = false;
    bool hasLaunched = false;

    Vector2 resetPosition;

    public float pressMax;
    public Color red, blue, green, yellow, purple;

    int score;

    int colorScore;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        launchButton = InputSystem.actions.FindAction("Launch");
        myBody = GetComponent<Rigidbody2D>();
        myRenderer = GetComponent<SpriteRenderer>();
        resetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLaunched)
        {
            if (launchButton.IsPressed() && pressTime < pressMax)
            {
                pressTime += Time.deltaTime;
            }
            else if (launchButton.WasReleasedThisFrame())
            {
                launchBall = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (launchBall)
        {
            myBody.AddForceY(2000f * pressTime);
            launchBall = false;
            hasLaunched = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Red"))
        {
            myRenderer.color = red;
            score += colorScore;
        } else if (other.gameObject.CompareTag("Blue"))
        {
            myRenderer.color = blue;
            score += colorScore;
        } else if (other.gameObject.CompareTag("Green"))
        {
            myRenderer.color = green;
            score += colorScore;
        } else if (other.gameObject.CompareTag("Yellow"))
        {
            myRenderer.color = yellow;
            score += colorScore;
        } else if (other.gameObject.CompareTag("Purple"))
        {
            myRenderer.color = purple;
            score += colorScore;
        } else if (other.gameObject.CompareTag("Bumper"))
        {
            Debug.Log(-other.GetContact(0).normal * 1000f);
            myBody.AddForce(-other.GetContact(0).normal * transform.up * 10000f, ForceMode2D.Force);
        } else if (other.gameObject.CompareTag("Reset"))
        {
            myBody.linearVelocity = Vector2.zero;
            transform.position = resetPosition;
            hasLaunched = false;
        }
    }
}
