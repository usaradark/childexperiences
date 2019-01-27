using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float charaSpeed;

    private CharacterController myController;
    private ABHandler dialogueHandler;
    // Start is called before the first frame update
    void Start()
    {
        myController = GetComponent<CharacterController>();
        dialogueHandler = GetComponent<ABHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (dialogueHandler.canControl)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 playerMove = new Vector3(moveX, 0.0f, moveY);
            myController.SimpleMove(playerMove * charaSpeed);
        }
    }
}
