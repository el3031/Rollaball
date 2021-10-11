using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
   private Rigidbody rb;
   private float movementX;
   private float movementY;
   public float speed = 0f;

   private int count;
   public TextMeshProUGUI countText;
   public TextMeshProUGUI winText;
   
   public GameObject PickupParent;
   
   // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winText.gameObject.active = false;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.active = false;
            count++;

            SetCountText();
        }

        if (count >= PickupParent.transform.childCount)
        {
            winText.gameObject.SetActive(true);
        }
    }
}
