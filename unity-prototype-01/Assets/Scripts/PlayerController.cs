using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    // [SerializeField] private float speed = 10.8F;
    [SerializeField] private float horsePower = 0;
    [SerializeField] private float turnSpeed = 50;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

    void Start(){
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

        // Moves the vehicle forward based on vertical input
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotates the vehicle forward based on vertical input
        transform.Rotate(new Vector3(0, turnSpeed * horizontalInput * Time.deltaTime, 0));

        speed = Mathf.Round(playerRb.velocity.magnitude * 3.6F);
        speedometerText.SetText("Speed: " + speed + "Km/h");

        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.SetText("RPM: " + rpm);
    }
}
