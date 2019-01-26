using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCharacterController : MonoBehaviour
{
    public float charSpeed;

    private CharacterController myController;
    
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 playerMove = new Vector3(moveX, 0.0f, moveY);
        myController.SimpleMove(playerMove * charSpeed);
    }
}
