using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public static MasterController instance;

    public Hashtable references;

    [SerializeField] private GameObject variable;

    void Awake()
    {
        //Singleton
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        references = new Hashtable();

        GameObject input = Instantiate(variable, new Vector3(-7, 0, 0), Quaternion.identity);
        input.GetComponent<VariableController>().SetNameAndData("input", 0);
        references.Add("input", input);
        GameObject output = Instantiate(variable, new Vector3(7, 0, 0), Quaternion.identity);
        output.GetComponent<VariableController>().SetNameAndData("output", 0);
        references.Add("output", output);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
