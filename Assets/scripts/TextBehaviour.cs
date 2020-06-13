using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBehaviour : MonoBehaviour
{
    public GameObject texto, bGrnd;
    public string[] frases;
    private string display = "";
    private int ind = 0, frase = 0;

    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine("ShowText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Transit(bool black)
    {
        texto.GetComponent<Text>().text = "";
        print(2);
        if(black)
            bGrnd.SetActive(true);
        else
            bGrnd.SetActive(false);
    }    

    IEnumerator ShowText()
    {
        for(int i = 0; i < frases[frase].Length; i++)
        {        
            yield return new WaitForSeconds(0.1f);
            display += frases[frase][ind];
            texto.GetComponent<Text>().text = display;
            if(ind + 1 == frases[frase].Length)
            {
                frase++;
                this.ind = 0;
                display = "";
                print(1);
                yield return new WaitForSeconds(2);
                Transit(false);
            }
            else
                ind++;
        }
    }
}
