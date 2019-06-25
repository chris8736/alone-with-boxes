using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputParser : MonoBehaviour
{

    [SerializeField] private TMP_InputField tmpif;
    [SerializeField] private GameObject variable;
    [SerializeField] private GameObject array;
    Hashtable references;

    public void CreateBlock()
    {
        references = MasterController.instance.references;

        string input = tmpif.text;
        string name = trimOneWordFromString(ref input);
        bool isAssignment = trimOneWordFromString(ref input) == "=";

        //Assignment case (variable)
        if (isAssignment)
        {
            int evaluated = EvaluateString.Evaluate(input, references);
            if (!references.ContainsKey(name))
            {
                GameObject newBlock = Instantiate(variable, Vector3.zero, Quaternion.identity);
                newBlock.GetComponent<VariableController>().SetNameAndData(name, evaluated);
                references.Add(name, newBlock);
            }
            else
            {
                ((GameObject)references[name]).GetComponent<VariableController>().SetData(evaluated);
            }
        }
    }

    private string trimOneWordFromString(ref string word)
    {
        string firstWord = null;
        if (word.Length > 0)
        {
            int idx = word.IndexOf(" ");
            firstWord = word.Substring(0, idx);
            word = word.Substring(idx + 1);
        }
        return firstWord;
    }
}
