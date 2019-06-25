using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VariableController : MonoBehaviour
{
    [SerializeField] private GameObject nameText;
    [SerializeField] private GameObject dataText;

    public void SetName(string name)
    {
        transform.Find("Canvas").transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;
    }

    public void SetData(int data)
    {
        transform.Find("Canvas").transform.Find("Out").GetComponent<VariableEject>().data = data;
    }

    public void SetNameAndData(string name, int data)
    {
        transform.Find("Canvas").transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;
        transform.Find("Canvas").transform.Find("Out").GetComponent<VariableEject>().data = data;
    }
}
