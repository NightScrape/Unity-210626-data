using UnityEngine;

public class Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("所有攝影機數" + Camera.allCamerasCount);
        print("2D重力大小"+Physics2D.gravity);
        print("圓周率:" + Mathf.PI);

        Physics2D.gravity = new Vector2(0,-20);
        Time.timeScale = 0.5f;

        float number = 9.99f;
        number = Mathf.Floor(number);
        print("9.99去小數:"  + number);

        Vector3 a = new Vector3(1, 1, 1);
        Vector3 b = new Vector3(22, 22, 22);
        float d = Vector3.Distance(a, b);
        print("a與b的距離" + d);

       // Application.OpenURL("https://unity.com/");
    }

    // Update is called once per frame
    void Update()
    {
        print("是否按下任意鍵" + Input.anyKey);
        //print("遊戲經過時間" + Time.time);

        bool space = Input.GetKeyDown("space");
        print("是否按空白鍵"+space);
    }
}
