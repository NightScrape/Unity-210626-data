using UnityEngine;
/// <summary>
/// �{�Ѵ���
/// </summary>
public class learnLerp : MonoBehaviour
{
    public float a = 0, b = 10;
    public float result;

    public float c = 0, d = 100;

    public Vector2 V2A = Vector2.zero;
    public Vector2 V2B = Vector2.one*100;

    //����Lerp:���o���I��������
    private void Start()
    {
        //���G=�ƾ�.����(a�I,b�I,�ʤ���0-1)
        result = Mathf.Lerp(a, b, 0.5f);
    }
    private void Update()
    {
        c = Mathf.Lerp(c, d, 0.5f *Time.deltaTime);
        V2A = Vector2.Lerp(V2A, V2B, 0.8f * Time.deltaTime);
    }
}
