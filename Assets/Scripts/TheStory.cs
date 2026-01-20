using UnityEngine;
using UnityEngine.UI;

public class TheStory : MonoBehaviour
{
    public Button[] button;

    public int depth = 0;
    public Transform first;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hideButtons();
        
         first = transform.GetChild(0); //in my hierarchy of empties (Mary had a)

        //turn on first button, which is always the question
        button[0].gameObject.SetActive(true);
        //set the text based on the node name
        Text text = button[0].GetComponentInChildren<Text>();
        text.text = first.name;

        

        int ct = first.childCount  ;
        for (int i = 0; i < ct; i++)
        {
            //show button, plus 1, as  0 is always the question
            button[i+1].gameObject.SetActive(true);
            Text text2 = button[i+1].GetComponentInChildren<Text>();

            //set the button text to the child node name
            text2.text = first.GetChild(i).name;   //little () an/or bic (1)
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hideButtons()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].gameObject.SetActive(false);

        }
    }

    public void OnClick(int nodeNum)
    {
        Debug.Log("a click" + nodeNum + " " + first.name);

        hideButtons();

        first = first.GetChild(nodeNum);

        //turn on first button, which is always the question
        button[0].gameObject.SetActive(true);
        //set the text based on the node name
        Text text = button[0].GetComponentInChildren<Text>();
        text.text = first.name;

        int ct = first.childCount;
        for (int i = 0; i < ct; i++)
        {
            //show button, plus 1, as  0 is always the question
            button[i + 1].gameObject.SetActive(true);
            Text text2 = button[i + 1].GetComponentInChildren<Text>();

            //set the button text to the child node name
            text2.text = first.GetChild(i).name;   //little () an/or bic (1)
        }

    }

}
