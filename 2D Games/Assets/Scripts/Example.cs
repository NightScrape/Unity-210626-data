using UnityEngine;

public class Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("�Ҧ���v����" + Camera.allCamerasCount);
        print("2D���O�j�p"+Physics2D.gravity);
        print("��P�v:" + Mathf.PI);

        Physics2D.gravity = new Vector2(0,-20);
        Time.timeScale = 0.5f;

        float number = 9.99f;
        number = Mathf.Floor(number);
        print("9.99�h�p��:"  + number);

        Vector3 a = new Vector3(1, 1, 1);
        Vector3 b = new Vector3(22, 22, 22);
        float d = Vector3.Distance(a, b);
        print("a�Pb���Z��" + d);

       // Application.OpenURL("https://unity.com/");
    }

    // Update is called once per frame
    void Update()
    {
        print("�O�_���U���N��" + Input.anyKey);
        //print("�C���g�L�ɶ�" + Time.time);

        bool space = Input.GetKeyDown("space");
        print("�O�_���ť���"+space);
    }
}
