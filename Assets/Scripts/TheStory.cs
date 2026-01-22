using UnityEngine;
using UnityEngine.UI;

public class TheStory : MonoBehaviour
{
    public Button[] button; //the buttons on the 2d gui, i wont more than 4

    public int depth = 0;   //current branch depth in dialog
    public Transform first; //current first in the dialog, the question

    public Animator anim; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        anim = GetComponent<Animator>();

        //TODO: generalize!!
        hideButtons();
        

        
        first = transform.GetChild(depth); //in my hierarchy of empties (Mary had a)
        
        

        //turn on first button, which is always the question
        button[0].gameObject.SetActive(true);
        //set the text based on the node name
        Text text = button[0].GetComponentInChildren<Text>();
        //must explcit to a string
        string narrate = (first.GetComponent<Narrative>().narration);
        text.text = narrate;

        //find it's children and fill out their narrative
        int ct = first.childCount  ;
        for (int i = 0; i < ct; i++)
        {
            //show button, plus 1, as  0 is always the question
            button[i+1].gameObject.SetActive(true);
            Text text2 = button[i+1].GetComponentInChildren<Text>();

            // CAN NOT DIRECTLY ASSIGN THE COMPONET PROPERT TO THE ui TEXT OBJECT
            string narrate2 = (first.GetChild(i).GetComponent<Narrative>().narration);

            //set the button text to the child node name
            //text2.text = first.GetChild(i).name;   //little () an/or bic (1)
            text2.text = narrate2;

            Narrative nar = first.GetChild(i).GetComponent<Narrative>();         


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
        Debug.Log("a click  " + first.name);

        hideButtons();

     
        first = first.GetChild(nodeNum);
        
        Debug.Log("a click" + nodeNum + " " + first.name);

        string parm = first.GetComponent<Narrative>().paramName;
        anim.SetTrigger(parm);

        if(first.childCount == 0)
        {
            depth++;
            first = transform.GetChild(depth);
            
        }
            


        //turn on first button, which is always the question
        button[0].gameObject.SetActive(true);
        //set the text based on the node name
        Text text = button[0].GetComponentInChildren<Text>();

        string narrate = (first.GetComponent<Narrative>().narration);
        text.text = narrate;

        int ct = first.childCount;
        for (int i = 0; i < ct; i++)
        {
            //show button, plus 1, as  0 is always the question
            button[i + 1].gameObject.SetActive(true);
            Text text2 = button[i + 1].GetComponentInChildren<Text>();

            // CAN NOT DIRECTLY ASSIGN THE COMPONET PROPERT TO THE ui TEXT OBJECT
            string narrate2 = (first.GetChild(i).GetComponent<Narrative>().narration);

            //set the button text to the child node name
            //text2.text = first.GetChild(i).name;   //little () an/or bic (1)
            text2.text = narrate2;

         
           


        }

    }

}
