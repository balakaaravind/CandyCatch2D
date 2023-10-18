using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    public bool canMove = true;

    [SerializeField] 
    float maxPos;

    [SerializeField]
    float moveSpeed;
    void Start()
    {

    }

    
    void Update()
    {
        if (canMove == true)
        {
            Move();
        }
        
    }

    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * xInput * moveSpeed * Time.deltaTime;


        float XPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);

        transform.position = new Vector3(XPos, transform.position.y, transform.position.z);
        

    }



}
