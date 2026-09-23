using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipperControl : MonoBehaviour
{

    Rigidbody2D myBody;
    InputAction flipButton;

    public string actionName;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        flipButton = InputSystem.actions.FindAction(actionName);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void FixedUpdate()
    {
        if (flipButton.IsPressed())
        {
            Debug.Log("hello");
            myBody.AddForceY(200f);
        }
    }
}
