using UnityEngine;

public class GameStart : MonoBehaviour
{

    public Transform theStory;
    public Transform menu3d;
    public GameObject theCanvas;
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
        if (other.tag != "Player")
            return;

        theStory.gameObject.SetActive(true);
        menu3d.gameObject.SetActive(true);
        theCanvas.SetActive(true);
        

    }
}
