using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float charaSpeed;

    private CharacterController myController;
    private ABHandler dialogueHandler;

    public AudioClip audioWalking;
    public AudioSource audioSource;
    public float audioDelay = 45.0f;
    public float maxAudioDelay = 45.0f;

    public Animator animator;
    private bool playerMoving;
    private Vector3 lastMove;

    public Text interText;

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
        playerMoving = false;
        if (dialogueHandler.canControl)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");
            Vector3 playerMove = new Vector3(moveX, 0.0f, moveY);
            myController.SimpleMove(playerMove * charaSpeed);

            if (Mathf.Abs(moveX) > 0 || Mathf.Abs(moveY) > 0)
            {
                playerMoving = true;

                if (audioDelay <= 0)
                {
                    audioDelay = maxAudioDelay;
                    audioSource.volume = Random.Range(1f, 2f);
                    audioSource.pitch = Random.Range(0.8f, 1.1f);
                    audioSource.PlayOneShot(audioWalking, 0.7f);

                    lastMove = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                }
            }
            if (audioDelay > 0)
                audioDelay--;

            myController.SimpleMove(playerMove * charaSpeed);
            animator.SetFloat("horizontal", moveX);
            animator.SetFloat("vertical", moveY);
            animator.SetBool("isMoving", playerMoving);
            animator.SetFloat("lastHorizontal", lastMove.x);
            animator.SetFloat("lastVertical", lastMove.y);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        interText.gameObject.SetActive(true);    
    }

    private void OnTriggerExit(Collider other)
    {
        interText.gameObject.SetActive(false);
    }
}
