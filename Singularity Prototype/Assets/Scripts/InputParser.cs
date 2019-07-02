using System;
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
        string name = trimVariableNameFromString(ref input);
        bool isAssignment = trimAssignmentFromString(ref input) == "=";

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

    private string trimVariableNameFromString(ref string word)
    {
        int i = 0;
        while (i < word.Length && ((Char.IsLetterOrDigit(word[i])) || word[i] == '_'))
        {
            i += 1;
        }
        string firstWord = word.Substring(0, i);
        word = word.Substring(i).Trim(' ');
        return firstWord;
    }

    private string trimAssignmentFromString(ref string word)
    {
        if (word.Length > 0 && word[0] == '=')
        {
            word = word.Substring(1);
            return "=";
        }
        else
        {
            return "";
        }
    }
}
