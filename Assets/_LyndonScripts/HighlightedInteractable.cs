using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class HighlightedInteractable : MonoBehaviour
{
    [Header("Mouse")]
    public Color startColor;
    public Color mouseOverColor;

    [Header("Canvas")]
    public GameObject panel;
    public Text promptLocation;
    public Text interact;

    public GameObject interText;

    public dialogue_option dia_opt;

    public string locationName;
    bool mouseOver = false;

    [Header("NavMesh")]
    Camera cam;
    public LayerMask groundLayer;
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent playerAgent;

    [Header("Animator")]
    public Animator animator;

    #region Monobehavior API;

    private void Start()
    {
        panel.SetActive(false);
        //interact.gameObject.SetActive(false);
        playerAgent = player.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float h = playerAgent.velocity.x;
        float v = playerAgent.velocity.z;
        animator.SetFloat("horizontal", h);
        animator.SetFloat("vertical", v);

        if (Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0)
            animator.SetBool("isMoving", true);
        else
            animator.SetBool("isMoving", false);


        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 0, player.transform.eulerAngles.z);
<<<<<<< HEAD:Assets/LyndonScripts/HighlightedInteractable.cs

=======
        print(playerAgent.velocity);
>>>>>>> c9cd429bdacd95c9c8c21a9aceb3e7d5f49657d4:Assets/_LyndonScripts/HighlightedInteractable.cs
    }

    // Start is called before the first frame update
    void OnMouseEnter()
    {
        mouseOver = true;
        GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }

    private void OnMouseDown()
    {
        playerAgent.SetDestination(gameObject.transform.position);
    }

    // The three functions below are for the buttons on Canvas in the scene "Map"

    public void disablePanel()
    {
        panel.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
<<<<<<< HEAD:Assets/LyndonScripts/HighlightedInteractable.cs
        isInLocation = true;
        //interact.gameObject.SetActive(true);
=======
        interact.gameObject.SetActive(true);
>>>>>>> c9cd429bdacd95c9c8c21a9aceb3e7d5f49657d4:Assets/_LyndonScripts/HighlightedInteractable.cs
        if (Input.GetKeyDown(KeyCode.E))
        {
            panel.SetActive(true);

            promptLocation.text = locationName;
        }
    }

    private void OnTriggerExit(Collider other)
    {
<<<<<<< HEAD:Assets/LyndonScripts/HighlightedInteractable.cs
        isInLocation = false;
        //interact.gameObject.SetActive(false);
=======
        interact.gameObject.SetActive(false);
>>>>>>> c9cd429bdacd95c9c8c21a9aceb3e7d5f49657d4:Assets/_LyndonScripts/HighlightedInteractable.cs
    }

    #endregion

    

}
