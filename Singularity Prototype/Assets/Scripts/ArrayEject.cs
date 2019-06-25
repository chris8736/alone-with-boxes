using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArrayEject : MonoBehaviour
{
    public float smoothTime = .3f;
    public List<int> data = new List<int>();

    [SerializeField]
    private GameObject page;
    [SerializeField]
    private TMP_InputField indexText;
    [SerializeField]
    private GameObject arrayDataText;

    private Vector2 startPosition = Vector2.zero;
    private Vector2 targetPosition = new Vector2(2.3f, 0);
    private Vector2 velocity = Vector2.zero;
    private bool ejected, ejecting = false;

    // Start is called before the first frame update
    void Start()
    {
        arrayDataText.GetComponent<MeshRenderer>().sortingOrder = -1;
        page.SetActive(false);
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
                    if (!page.activeSelf)
                        page.SetActive(true);
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
