using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class HighlightedInteractable : MonoBehaviour
{
    public Color startColor;
    public Color mouseOverColor;

    public GameObject panel;
    public Text promptLocation;

    public dialogue_option dia_opt;

    public string locationName;
    bool mouseOver = false;

    public Button Option1;
    public Button Option2;

    Camera cam;
    public LayerMask groundLayer;
    public GameObject player;
    private UnityEngine.AI.NavMeshAgent playerAgent;

    public GameObject[] locations;

    public Vector3 point;

    #region Monobehavior API;

    private void Start()
    {
        panel.SetActive(false);
        playerAgent = player.GetComponent<NavMeshAgent>();
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
        if (this.gameObject.CompareTag("Location"))
        {
            panel.SetActive(true);
            playerAgent.SetDestination(gameObject.transform.position);
            promptLocation.text = locationName;

            Option1.onClick.RemoveAllListeners();
            Option2.onClick.RemoveAllListeners();

            Option1.onClick.AddListener(setLocationTagBack);
            Option2.onClick.AddListener(setLocationTagBack);

            Option1.onClick.AddListener(dia_opt.printOption_1_Result);
            Option2.onClick.AddListener(dia_opt.printOption_2_Result);

            setLocationTagToIgnore();
        }
    }

    // The three functions below are for the buttons on Canvas in the scene "Map"
    public void setLocationTagToIgnore()
    {
        foreach (GameObject location in locations)
        {
            location.tag = "Ignore";
        }
    }

    public void setLocationTagBack()
    {
        foreach (GameObject location in locations)
        {
            location.tag = "Location";
        }
    }

    public void disableCanvas()
    {
        panel.SetActive(false);
    }

    #endregion

}
