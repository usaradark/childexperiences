using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlight : MonoBehaviour
{
    public Color startColor;
    public Color mouseOverColor;
    bool mouseOver = false;

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
        Application.LoadLevel("Church");
        print("click");
    }
}
