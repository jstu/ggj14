using UnityEngine;
using System.Collections;

public class CullingMasks : MonoBehaviour {

    public enum MoodLayer {Sad, Joy, Angry};
    public MoodLayer selected;
    private int skey;
    public Camera cam;
    private int rnd;
    
	void Start () 
    {
        rnd = Random.Range(0, 3);
        MoodLayer startLayer = (MoodLayer)rnd;
        Toggle(startLayer);
	}
	
	void Update () {
        if (cam.name == "Camera1")
        {
            if (Input.GetButtonDown("Square"))
            {
                cam.backgroundColor = Color.gray;
                Toggle(MoodLayer.Sad);
            }
            if (Input.GetButtonDown("Circle"))
            {
                cam.backgroundColor = Color.cyan;
                Toggle(MoodLayer.Joy);
            }

            if (Input.GetButtonDown("Triangle"))
            {
                cam.backgroundColor = Color.red;
                Toggle(MoodLayer.Angry);
            }
        }
        else if (cam.name == "Camera2")
        {
            if (Input.GetButtonDown("Square2"))
            {
                cam.backgroundColor = Color.gray;
                Toggle(MoodLayer.Sad);
            }

            if (Input.GetButtonDown("Circle2"))
            {
                cam.backgroundColor = Color.cyan;
                Toggle(MoodLayer.Joy);
            }

            if (Input.GetButtonDown("Triangle2"))
            {
                cam.backgroundColor = Color.red;
                Toggle(MoodLayer.Angry);
            }
        }
	}

    private void Toggle(MoodLayer l)
    {
        selected = l;
        cam.cullingMask = 1 << LayerMask.NameToLayer(l.ToString()) | 1 << LayerMask.NameToLayer("Normal") | 1 << LayerMask.NameToLayer("Ground") | 1 << LayerMask.NameToLayer("Player") | 1 << LayerMask.NameToLayer("Player2");
    }
}
