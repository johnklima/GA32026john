using FMOD;
using UnityEditor.EventSystems;
using UnityEngine;
using FMODUnity ;
using System.Diagnostics;

public class ButtonBox : MonoBehaviour
{
    public TheStory story;
    public int nodeNum;
    public Transform friend;
    public int trigged = 0;

    public Material[] mats;

    public StudioEventEmitter CameraEventEmitter;
    public string paramName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Renderer>().material = mats[2];// mats[Random.Range(0, 4)]; //

        //move the box to it's object
        //transform.position = friend.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigged == 1 && Input.GetKey(KeyCode.E))
        {
            story.OnClick(nodeNum);
            trigged = 2;

            

        }
    }
          

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        //play sound

        if (trigged > 0) return;
        trigged = 1;

        UnityEngine.Debug.Log(name + " HIT " + other.name);

        //Animation anim = GetComponent<Animation>();
        //anim.Play();

        foreach (Transform nextT in transform)
        {
            nextT.gameObject.SetActive(true);
        }
        if (CameraEventEmitter)
        {
            UnityEngine.Debug.Log("BBB");
            CameraEventEmitter.SetParameter(paramName, 1);
        }
    }

    private void OnEnable()
    {
        friend.gameObject.SetActive(true);
    }
}
