using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInverseGOActive : MonoBehaviour
{
    public void Inverse( GameObject ObjToInverse)
    {
        ObjToInverse.SetActive(!ObjToInverse.activeSelf);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
