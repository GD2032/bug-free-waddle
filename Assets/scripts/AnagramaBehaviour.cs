using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnagramaBehaviour : MonoBehaviour
{
    public string word;
    private char[] letras;
    private List<int> sorteados = new List<int>();
    private int s;
    // Start is called before the first frame update
    void Start()
    {
        letras = word.ToCharArray();
        s = Random.Range(0, word.Length);
        for(int i = 0; i < word.Length; i++)
        {            
            while(sorteados.Contains(s))
            {
                s = Random.Range(0, word.Length);                
            }
            sorteados.Add(s);
            transform.GetChild(i).gameObject.GetComponent<TextMeshPro>().text = word[s].ToString();        
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
