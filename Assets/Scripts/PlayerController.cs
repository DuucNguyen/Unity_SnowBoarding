using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 100f;
    [SerializeField] float normalSpeed = 10f;
    [SerializeField] float boostSpeed = 60f;

    PlayerScore playerScore;
    Rigidbody2D rb2d;
    //SurfaceEffector2D surfaceEffector2D;
    private bool canMove = true;
    private SurfaceEffector2D[] effectors;

    private float totalRotation = 0f;  // Tracks accumulated rotation
    private float lastRotation = 0f;   // Tracks previous frame's rotation

    [SerializeField] TextMeshProUGUI speedText;

    public int trickCount;

    // Start is called before the first frame update
    void Start()
    {
        trickCount = 0;
        playerScore = GetComponent<PlayerScore>();
        rb2d = GetComponent<Rigidbody2D>();
        //surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        lastRotation = rb2d.rotation;  // Initialize with the starting rotation

        effectors = FindObjectsOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var surface in effectors)
        {
            speedText.text = surface.speed.ToString();
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            RotatePlayer();
            Boost();
        }
        if (CheckFullRotation())
        {
            trickCount++;
            playerScore.IncreaseScore(200);
        }
    }


    public void DisableControls()
    {
        canMove = false;
    }

    void Boost()
    {
        foreach (var surface in effectors)
        {
            surface.speed = normalSpeed;
            var vertical = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.UpArrow))
            {
                surface.speed = Mathf.Clamp(surface.speed + vertical * normalSpeed, normalSpeed, boostSpeed);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                surface.speed = Mathf.Clamp(surface.speed - vertical * normalSpeed, 0, normalSpeed);
            }
        }

    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount, ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount, ForceMode2D.Force);
        }
    }


    bool CheckFullRotation()
    {
        // Calculate the change in rotation since the last frame
        float currentRotation = rb2d.rotation;
        float rotationDelta = Mathf.DeltaAngle(lastRotation, currentRotation);

        // Accumulate the total rotation
        totalRotation += rotationDelta;

        // Update the last rotation value
        lastRotation = currentRotation;

        // Check if we've rotated 360 degrees
        if (Mathf.Abs(totalRotation) >= 360f)
        {

            totalRotation = 0f; // Reset the accumulated rotation for the next cycle
            return true;
        }
        return false;
    }


}
