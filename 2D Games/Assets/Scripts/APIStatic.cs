using UnityEngine;
/// <summary>
/// �{��API�βĤ@�إΪk:�R�A
/// </summary>
public class APIStatic: MonoBehaviour
{
    //API������j��:�R�A�ΫD�R�A
    //�ݩ�:�i�z�Ѭ���� Properties
    //��k Methods
    private void Start()
    {
        //�R�A�ݩ�
        //1.���o  �y�k:���O.�R�A�ݩ�
        print("�H����:" + Random.value);
        print("�L���j:" + Mathf.Infinity);
        //2.�]�w  �y�k:���O.�R�A�ݩ�+���w+��
        Cursor.visible = false;  //������ܻP�_
        //��Ū�ݩ� Read Only:���ݩʤ��i�γ]�w���A�ȯ�Ū��
        Screen.fullScreen = true;
        //�R�A��k
        //3.�I�s 
        float r = Random.Range(7.2f, 10.6f);
        print("�H����{7.2-10.6:" + r); }

        public float hp = 70;
    private void Update()
    {
        
        hp = Mathf.Clamp(hp,0,100);  //Clamp����
        print("HP="+hp);
    }

}
