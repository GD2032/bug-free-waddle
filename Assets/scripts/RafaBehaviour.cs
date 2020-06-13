using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RafaBehaviour : MonoBehaviour
{
    [SerializeField]private int speed;
    private float hor, ver;
    private Rigidbody2D rb;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(hor * speed, rb.velocity.y);
    }
}
