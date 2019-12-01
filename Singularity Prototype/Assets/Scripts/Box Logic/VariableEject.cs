using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class VariableEject : MonoBehaviour
{
    public float smoothTime = .3f;
    [SerializeField] private GameObject page;
    [SerializeField] private GameObject variableDataText;

    private Vector2 startPosition = Vector2.zero;
    private Vector2 targetPosition = new Vector2(2.3f, 0);
    private Vector2 velocity = Vector2.zero;
    private bool ejected, ejecting = false;

    void Start()
    {
        variableDataText.GetComponent<MeshRenderer>().sortingOrder = -1;
    }

    void Update()
    {
        MoveToEjectPosition();
    }

    private void MoveToEjectPosition()
    {
        if (ejecting)
        {
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
                    page.SetActive(false);
                }
            }
        }
    }

    public void Eject()
    {
        if (!ejecting)
        {
            transform.Rotate(0, 0, 180);
            ejecting = true;
        }
    }
}
