using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VariableController : MonoBehaviour
{
    private string variableName;
    public int data;

    [SerializeField] private GameObject nameText;
    [SerializeField] private GameObject dataText;

    public void SetName(string name)
    {
        variableName = name;
        transform.Find("Canvas").transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;
    }

    public void SetData(int data)
    {
        this.data = data;
        dataText.GetComponent<TextMeshPro>().text = data.ToString();
    }

    public void SetNameAndData(string name, int data)
    {
        variableName = name;
        this.data = data;
        transform.Find("Canvas").transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name;
        dataText.GetComponent<TextMeshPro>().text = data.ToString();
    }
}
