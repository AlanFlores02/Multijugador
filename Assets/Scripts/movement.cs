using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class movement : NetworkBehaviour
{
    public float speed = 50.0f;
    public bool funky = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (!IsOwner || !Application.isFocused) return;
        // Simple player movement
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector2 input = new Vector2(xInput, yInput);
        transform.Translate(input * speed * Time.deltaTime);
        // Loop to the other side when going out of bounds
        float xPos = transform.position.x;
        float yPos = transform.position.y;
        if(xPos < -10.0f) { xPos = 8.0f; }
        else if(xPos > 10.0f) { xPos = -8.0f; }
        if(yPos < -8.0f) { yPos = 6.0f; }
        else if(yPos > 8.0f) { yPos = -6.0f; }
        transform.position = new Vector2(xPos, yPos);
    }
}
