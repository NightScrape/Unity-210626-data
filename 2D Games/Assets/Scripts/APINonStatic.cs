using UnityEngine;

public class APINonStatic : MonoBehaviour
{
   
    public Transform traA;
    public Camera cam;
    public Transform traB;
    public Light lightA;
    public Camera camA;
    public SpriteRenderer sprA;
    public SpriteRenderer sprB;
    public Transform traC;
    public Rigidbody2D rig2D;
    //���o�D�R�A�ݩ�
    //1.�w�q���D�R�A�ݩʪ����O���
    //2.��쥲����J�n����T������  (���ର�ŭ�)
    private void Start()
    { 
        #region �{�ѫD�R�A�ݩ�
        //1.���o�D�R�A�ݩ�
        //print("���o�y��:" + Transform.position); ���~-�D�R�A�ݩʻݦ�����Ѧ�
        //�ϥΫD�R�A�ݩ�  �y�k ���.�D�R�A�ݩ�
        print("���o�ߤ���y��:"+traA.position);
        print("���o��v�����I���C��"+cam.backgroundColor);
        //2.�]�w�D�R�A�ݩ� �y�k ���.�D�R�A�ݩ�+���w+��
        cam.backgroundColor = new Color(0.8f, 0.5f, 0.6f);

        //3.�I�s�D�R�A�ݩ� �y�k ���.�D�R�A�ݩ�(�����޼�)
        traB.Translate(1, 0, 0);
        lightA.Reset();
        #endregion

        #region �m��
        print("��v���`��"+camA.depth);
        print("�Ϥ��C��" + sprA.color);
        camA.backgroundColor = Random.ColorHSV();
        sprB.flipY = true;
        #endregion
    }
    private void Update()
    {
        traC.Rotate(0,0,1);
        rig2D.AddForce(new Vector2(0,10));
    }
}
