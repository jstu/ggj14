using UnityEngine;
using System.Collections;

public class FlagTimer : MonoBehaviour {


    private float BoyTimer = 20;
    private float GirlTimer = 20;
    private bool gameOver = false;
    public Texture win;
    public Texture lose;
    public GUISkin s;

    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (BoyTimer <= 0 || GirlTimer <= 0)
        {
            gameOver = true;   
        }
    }

    void OnTriggerStay2D(Collider2D c) 
    {
        if (c.gameObject.name == "Girl" && GirlTimer > 0)
            GirlTimer -= Time.deltaTime;

        if (c.gameObject.name == "Boy" && BoyTimer > 0)
            BoyTimer -= Time.deltaTime;

        Debug.Log("Girl: " + GirlTimer);
        Debug.Log("Boy: " + BoyTimer);
    }

     void OnGUI() {
         GUI.skin = s;

         GUI.Box(new Rect(Screen.width - 75, Screen.height - 25 , 100, 150), BoyTimer.ToString("F2"));
         GUI.Box(new Rect(0, Screen.height - 25, 100, 150), GirlTimer.ToString("F2"));

         if (gameOver == true)
         {
             if (GirlTimer <= 0)
             {
                 GUI.Label(new Rect(0 + Screen.width / 5, Screen.height / 2 - 100, 200, 200), "WIN");
                 GUI.Label(new Rect(Screen.width - Screen.width / 5 - 200, Screen.height / 2 - 100, 200, 200), "LOSE");
             }
             else if (BoyTimer <= 0)
             {
                 GUI.Label(new Rect(0 + Screen.width / 5, Screen.height / 2 - 100, 200, 200), "LOSE");
                 GUI.Label(new Rect(Screen.width - Screen.width / 5 - 200, Screen.height / 2 - 100, 200, 200), "WIN");
             }

             Time.timeScale = 0;
             if (GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 50, 150, 100), "Again?"))
                 Application.LoadLevel(0);
         }
        
    }
}
