using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItens : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private Vector2[] positionMatriz;
    private float random, cooldown, cooldownTime;
    private Vector2 position;
    private GameObject clone;
    void Start()
    {
        cooldown = 2;
        cooldownTime = Time.time;
    }
    void Update()
    {
        if(cooldownTime < Time.time)
        {
            random = Random.Range(0, 3);
            position = positionMatriz[(int)random];
            clone = Instantiate(item, position, Quaternion.identity);
            clone.GetComponent<ItemColetavel>().layer = (random == 0) ? 1 : (random == 1) ? 0 : -1;
            cooldownTime = Time.time + cooldown;
        }
    }
}
