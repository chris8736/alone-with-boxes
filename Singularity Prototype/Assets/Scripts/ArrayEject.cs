using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrayEject : MonoBehaviour
{
    Vector2 startPosition = Vector2.zero;
    Vector2 targetPosition = new Vector2(2.3f, 0);
    Vector2 velocity = Vector2.zero;
    public float smoothTime = .3f;
    bool ejected, ejecting = false;
    public GameObject page;
    public TMP_InputField indexText;
    public GameObject arrayDataText;
    public List<int> data = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        arrayDataText.GetComponent<MeshRenderer>().sortingOrder = -1;
        for (var i = 0; i < 10; i++)
        {
            data.Add(i * i);
        }
    }

    void Update()
    {
        if (ejecting){
            if (!ejected)
            {
                if (page.transform.localPosition.x < targetPosition.x - .01)
                {
                    page.transform.localPosition = Vector2.SmoothDamp(page.transform.localPosition, targetPosition, ref velocity, smoothTime);
                }
                else
                {
                    ejected = true;
                    ejecting = false;
                }
            }
            else
            {
                if (page.transform.localPosition.x > startPosition.x + .01)
                {
                    page.transform.localPosition = Vector2.SmoothDamp(page.transform.localPosition, startPosition, ref velocity, smoothTime);
                }
                else
                {
                    ejected = false;
                    ejecting = false;
                }
            }
        }
    }

    public void Eject()
    {
        if (!ejecting)
        {
            transform.Rotate(0, 0, 180);
            if (!ejected)
            {
                arrayDataText.GetComponent<TextMeshPro>().text = data[int.Parse(indexText.text)].ToString();
            }
            ejecting = true;
        }
    }
}
