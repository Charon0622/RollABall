using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public float speed;

    public Text countText;
    public Text winText;

    // Hold the reference to the attached rigidbody
    private Rigidbody rb;

    private int count;

    // called on the first frame that the script is active
    // Often the very first frame of the game
    void Start()
    {
        // Get a reference to the attached rigidbody
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    // called just before performing any physics calculations
    void FixedUpdate()
    {
        // Grabs the input from player through the keyboard
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Pick Up"))
         {
             other.gameObject.SetActive(false);
             count = count + 1;
             setCountText();
         }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count == 12)
        {
            winText.text = "You Win!";
        }
    }
}
