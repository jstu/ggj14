using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject window1;
    public GameObject window2;
    public GameObject window3;
    public GameObject window4;

    private int randomi;
	// Use this for initialization
	void Start () {
        randomi = Random.Range(0, 4);

        if (randomi == 0)
        {
            Instantiate(window4, transform.position, transform.rotation);
        }
        if (randomi == 1)
        {
            Instantiate(window1, transform.position + new Vector3(0, 2.5f, 0), transform.rotation);
        }
        if (randomi == 2)
        {
            Instantiate(window2, transform.position + new Vector3(0, 1.5f, 0), transform.rotation);
        }
        if (randomi == 3)
        {
            Instantiate(window3, transform.position + new Vector3(0, 3.2f, 0), transform.rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
      
	}
}
