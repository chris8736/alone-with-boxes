using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MasterController : MonoBehaviour
{
    public static MasterController instance;

    public Hashtable references;

    [SerializeField] private GameObject variable;
    [SerializeField] private TextMeshProUGUI historyText;
    [SerializeField] private GameObject parser;
    private float timer = 1;
    private GameObject input;
    private GameObject output;

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

        input = Instantiate(variable, new Vector3(-7, 0, 0), Quaternion.identity);
        input.GetComponent<VariableController>().SetNameAndData("input", 0);
        references.Add("input", input);
        output = Instantiate(variable, new Vector3(7, 0, 0), Quaternion.identity);
        output.GetComponent<VariableController>().SetNameAndData("output", 0);
        references.Add("output", output);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 1;

            //simulate temperature change
            if (SceneManager.GetActiveScene().buildIndex == 1) { 
                input.GetComponent<VariableController>().SetData((int)Random.Range(67, 72));
            }

            //run program
            string[] history = historyText.text.Split('\n');
            for (int i = 2; i < history.Length; i++)
            {
                parser.GetComponent<InputParser>().ParseAndUpdate(history[i]);
            }
        }
    }

}
