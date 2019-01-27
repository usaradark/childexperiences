using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class highlight : MonoBehaviour
{
    public Color startColor;
    public Color mouseOverColor;

    public Canvas prompt;
    public Text promptLocation;

    public dialogue_option dia_opt;

    public string locationName;
    bool mouseOver = false;

    public Button Option1;
    public Button Option2;

    Camera cam;
    public LayerMask groundLayer;
    public UnityEngine.AI.NavMeshAgent playerAgent;

    public GameObject[] locations;

    #region Monobehavior API;

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
            prompt.gameObject.SetActive(true);
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



    #endregion

}
