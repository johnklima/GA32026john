using UnityEngine;

public class ButtonBox : MonoBehaviour
{
    public TheStory story;
    public int nodeNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
