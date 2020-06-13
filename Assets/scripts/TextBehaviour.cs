using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBehaviour : MonoBehaviour
{
    public GameObject texto, textBox;
    public GameObject[] screens;
    public string[] frases;
    private string display = "";
    private int ind = 0, frase = 0, isc = 0;
    private float interval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine("ShowText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Transit(bool black)
    {
        if(!black)
        {
            texto.GetComponent<Text>().alignment = TextAnchor.UpperLeft;
            texto.GetComponent<Text>().fontSize = 45;
            texto.GetComponent<RectTransform>().localPosition = new Vector3(19.5f, -182);
            screens[0].SetActive(false);
            screens[isc].SetActive(false); 
            interval = 1.5f;
            isc++; 
        }
        else
        {
            texto.GetComponent<Text>().alignment = TextAnchor.UpperCenter;
            texto.GetComponent<Text>().fontSize = 55;
            texto.GetComponent<RectTransform>().localPosition = new Vector3(-1.6212f, -39);
            screens[0].SetActive(true);
            interval = 1f;
        }        
        textBox.SetActive(false);
        texto.GetComponent<Text>().text = "";
        print(2);          
        if(frase != 4)
        {
            yield return new WaitForSeconds(1.5f);
            textBox.SetActive(!black);
            StartCoroutine("ShowText");
        }      
        else
            SceneManager.LoadScene(2);
    }    

    IEnumerator ShowText()
    {        
        for(int i = 0; i < frases[frase].Length; i++)
        {        
            //frases[frase].Replace(";", "\n");
            yield return new WaitForSeconds(0.1f);
            display = (frases[frase][ind].Equals(';')) ? display + "\n" : display + frases[frase][ind];
            if(frases[frase][ind].Equals(';'))
                yield return new WaitForSeconds(interval);                
            texto.GetComponent<Text>().text = display;
            if(ind + 1 == frases[frase].Length)
            {
                frase++;
                this.ind = 0;
                display = "";
                print(1);
                yield return new WaitForSeconds(2);                
                StartCoroutine(Transit(frase == 2));
            }
            else
                ind++;
        }
    }
}
