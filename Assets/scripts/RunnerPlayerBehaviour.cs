using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerPlayerBehaviour : MonoBehaviour
{
    private float layer;
    private float startTouchY, finalTouchY, axisY;
    [SerializeField] private Vector2[] position; 
    void Start()
    {
        layer = 0;      
    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
            axisY = 1;
        else if (Input.GetKeyDown("s"))
            axisY = -1;
        if (Input.GetMouseButtonDown(0))
        {
            startTouchY = Input.mousePosition.y;
        }
        if (Input.GetMouseButtonUp(0))
        {
            finalTouchY = Input.mousePosition.y;
            if (startTouchY - finalTouchY != 0)
                axisY = startTouchY - finalTouchY < 0 ? 1 : -1;
        }
        layer += axisY;
        axisY = 0;
        if (layer > 1)
            layer = 1;
        else if (layer < -1)
            layer = -1;
        switch (layer)
        {
            case 1:
                gameObject.transform.position = position[0];
                break;
            case 0:
                gameObject.transform.position = position[1];
                break;
            case -1:
                gameObject.transform.position = position[2];
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Item")
        {
            if (other.GetComponent<ItemColetavel>().layer == this.layer)
            {
                //coloca as interações quando coletar o objeto aqui
                Destroy(other.gameObject);
                print("hi");
            }
        }
    }
}
