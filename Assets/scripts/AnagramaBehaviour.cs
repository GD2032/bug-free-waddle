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
    private RaycastHit2D ray;
    private List<Word> chosen = new List<Word>();

    void Awake() 
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
            transform.GetChild(i).GetChild(0).gameObject.GetComponent<TextMeshPro>().text = word[s].ToString();   
            transform.GetChild(i).gameObject.name = i.ToString();     
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < word.Length; i++)
        {
            chosen.Add(new Word(transform.GetChild(i).gameObject, transform.GetChild(i).localPosition));
        }        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
        if(Input.GetKeyDown(KeyCode.Mouse0) && ray && ray.collider.gameObject.tag == "Word")
        {
            if(!Word.picks.Contains(ray.collider.gameObject))
            {                
                ray.collider.gameObject.transform.position = new Vector3(-3 + (2 * Word.picks.Count), 0.7f);
                Word.picks.Add(ray.collider.gameObject);
            }
            else
            {
                ray.collider.gameObject.transform.localPosition = chosen[int.Parse(ray.collider.gameObject.name)].initPos;
                Word.picks.Remove(ray.collider.gameObject);
                Reorg();
            }
        }
    }
    public void Reorg()
    {
        for(int i = 0; i < Word.picks.Count; i++)
        {
            Word.picks[i].transform.position = new Vector3(-3 + (2 * i), 0.7f);
        }
    }
}

public struct Word
{
    static public List<GameObject> picks = new List<GameObject>();
    public GameObject obj;
    public Vector3 initPos;
    public Word(GameObject go, Vector3 pos)
    {        
        obj = go;
        initPos = pos;
    }
}
