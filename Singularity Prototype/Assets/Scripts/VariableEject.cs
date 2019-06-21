using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VariableEject : MonoBehaviour
{
    Vector2 startPosition = Vector2.zero;
    Vector2 targetPosition = new Vector2(2.3f, 0);
    Vector2 velocity = Vector2.zero;
    public float smoothTime = .3f;
    public int data = 1337;
    bool ejected, ejecting = false;
    public GameObject page;
    public GameObject variableDataText;

    // Start is called before the first frame update
    void Start()
    {
        variableDataText.GetComponent<MeshRenderer>().sortingOrder = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (ejecting)
        {
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
                variableDataText.GetComponent<TextMeshPro>().text = data.ToString();
            }
            ejecting = true;
        }
    }
}
