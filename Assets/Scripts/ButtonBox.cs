using UnityEngine;

public class ButtonBox : MonoBehaviour
{
    public TheStory story;
    public int nodeNum;


    public Material[] mats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Renderer>().material = mats[Random.Range(0, 4)]; //
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool trigged = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        if (trigged) return;

        Debug.Log("HIT " + other.name);

        //Animation anim = GetComponent<Animation>();
        //anim.Play();

        foreach(Transform nextT in transform)
        {
            nextT.gameObject.SetActive(true);
        }

        story.OnClick(nodeNum);
    }
}
