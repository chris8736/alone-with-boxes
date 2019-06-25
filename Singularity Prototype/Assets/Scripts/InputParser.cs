using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputParser : MonoBehaviour
{

    public TMP_InputField tmpif;
    public GameObject variable;
    public GameObject array;
    Hashtable variables = new Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBlock()
    {
        string[] args = tmpif.text.Split(' ');

        //assignment case
        if (args.Length == 3 && args[1] == "=")
        {
            if (!variables.ContainsKey(args[0])){
                GameObject nb = Instantiate(variable, Vector3.zero, Quaternion.identity);
                Transform nb_canvas = nb.transform.Find("Canvas");
                nb_canvas.transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = args[0];
                variables.Add(args[0], nb);
                if (variables.ContainsKey(args[2]))
                {
                    nb_canvas.transform.Find("Out").GetComponent<VariableEject>().data = ((GameObject)variables[args[2]]).transform.Find("Canvas").transform.Find("Out").GetComponent<VariableEject>().data;
                }
                else
                {
                    nb_canvas.transform.Find("Out").GetComponent<VariableEject>().data = int.Parse(args[2]);
                }
            }
            else
            {
                if (variables.ContainsKey(args[2]))
                {
                    ((GameObject)variables[args[0]]).transform.Find("Canvas").transform.Find("Out").GetComponent<VariableEject>().data = ((GameObject)variables[args[2]]).transform.Find("Canvas").transform.Find("Out").GetComponent<VariableEject>().data;
                }
                else
                {
                    ((GameObject)variables[args[0]]).transform.Find("Canvas").transform.Find("Out").GetComponent<VariableEject>().data = int.Parse(args[2]);
                }
            }
        }

        //array case
        else if (args[1] == "=" && args[2] == "[" && args[args.Length - 1] == "]")
        {
            List<int> data = new List<int>();
            for(var i = 3; i < args.Length - 2; i++)
            {
                if(args[i] != "0")
                {
                }
            }
            GameObject nb = Instantiate(array, Vector3.zero, Quaternion.identity);
            Transform nb_canvas = nb.transform.Find("Canvas");
        }
    }
}
