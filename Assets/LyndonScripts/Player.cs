using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 5.0f;
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        this.gameObject.transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
        this.gameObject.transform.Translate(Vector3.right * h * speed * Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            print("hey");
        }
    }
}
