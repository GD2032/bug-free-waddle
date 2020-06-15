using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RafaBehaviour : MonoBehaviour
{        
    private Transform tr;
    private RaycastHit2D ray;
    private GameObject currentWp;
    public GameObject goBack;
    // Start is called before the first frame update
    void Start()
    {        
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
        if(Input.GetKeyDown(KeyCode.Mouse0) && ray && ray.collider.gameObject.tag == "WayPoint")
        {
            print(1);
            goBack.SetActive(true);
            currentWp = ray.collider.gameObject;
            currentWp.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0) && currentWp && ray && ray.collider.gameObject.name == "exit")
        {
            print(2);
            currentWp.transform.GetChild(0).gameObject.SetActive(false);
            currentWp = null;
            goBack.SetActive(false);
        }
    }
}
