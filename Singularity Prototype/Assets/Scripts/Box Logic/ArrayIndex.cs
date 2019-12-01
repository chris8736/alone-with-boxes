using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrayIndex : MonoBehaviour
{
    int index = 0;
    TextMeshProUGUI tm;
    public List<int> data = new List<int>();

    void Start()
    {
        tm = GetComponent<TextMeshProUGUI>();
        tm.text = index.ToString();
    }

    public void changeText(int i)
    {
        Debug.Log(index);
        index = Mathf.Clamp(index + i, 0, data.Count - 1);
        tm.text = index.ToString();
    }

    public int getData()
    {
        return data[index];
    }
}
