using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class player_controller : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move_horizontal = Input.GetAxis("Horizontal");
        float move_vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(move_horizontal, 0f, move_vertical);

        rb.AddForce(movement * speed);
    }
}