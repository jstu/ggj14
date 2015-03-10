using UnityEngine;
using System.Collections;


public class Finish : MonoBehaviour {
    public GameObject joy;
    public GameObject angry;
    public GameObject sad;
    int randomi;
	// Use this for initialization
	void Start () {
        randomi = Random.Range(0, 2);

        if (randomi == 0)
        {
            Instantiate(joy, transform.position, transform.rotation);
        }
        if (randomi == 1)
        {
            Instantiate(angry, transform.position, transform.rotation);
        }
        if (randomi == 2)
        {
            Instantiate(sad, transform.position, transform.rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
