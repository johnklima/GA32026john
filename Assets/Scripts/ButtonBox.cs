using UnityEngine;

public class ButtonBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        Debug.Log("HIT " + other.name);

        Animation anim = GetComponent<Animation>();
        anim.Play();

    }
}
