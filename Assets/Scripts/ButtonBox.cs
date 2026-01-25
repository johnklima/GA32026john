using FMOD;
using UnityEditor.EventSystems;
using UnityEngine;

public class ButtonBox : MonoBehaviour
{
    public TheStory story;
    public int nodeNum;
    public Transform friend;
   
    public Material[] mats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Renderer>().material = mats[Random.Range(0, 4)]; //

        //move the box to it's object
        transform.position = friend.position;
        
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
        trigged = true;

        UnityEngine.Debug.Log("HIT " + other.name);

        //Animation anim = GetComponent<Animation>();
        //anim.Play();

        foreach (Transform nextT in transform)
        {
            nextT.gameObject.SetActive(true);
        }
        story.OnClick(nodeNum);

    }

    private void OnEnable()
    {
        friend.gameObject.SetActive(true);
    }
}
