using UnityEngine;

//�{�ѹB��l
//1.�ƾǹB��l
public class LearningOperator : MonoBehaviour
{
    public int a = 10;
    public int b = 3;
    public int c = 7;
    public int hp = 80;

    public float ScoreA = 99;
    public float ScoreB = 1;

    public int health = 50;
    public int key = 1;
    public int coin = 4;
    public int jewel = 3;

    void Start()
    {
        #region �ƾǹB��l
        print(a + b);  //13
        print(a - b);  //7
        print(a * b);  //30
        print(a / b);  //3
        print(a % b);  //1
        //���W
        c = c + 1;  // = �B��Ÿ��A���p��k��b�p�⥪
        c++;        //²�g
        print("c�B��᪺���G" + c);
        //����12
        hp = hp - 12;
        hp -= 12;
        //�^�_30(���w�L�W��
        hp += 30;
        #endregion
        #region ����B��l
        //> < >= <= == !=
        print("99�j��1:"+(ScoreA>ScoreB));
        print("99�p��1:" + (ScoreA < ScoreB));
        print("99�j�󵥩�1:" + (ScoreA >= ScoreB));
        print("99�p�󵥩�1:" + (ScoreA <= ScoreB));
        print("99����1:" + (ScoreA == ScoreB));
        print("99������1:" + (ScoreA != ScoreB));
        #endregion
        #region �޿�B��l
        print("�޿�B��l");

        print("�åB");
        //�����̸��
        //�åB &&
        //�u�n�@���L�Ȭ�false,�h���G��false
        print(true && true);
        print(false && true);
        print(true && false);
        print(false && false);
        print("�Ϊ�");
        //�Ϊ� ||
        //�u�n�@���L�Ȭ�true,�h���G��true
        print(true || true);
        print(false || true);
        print(true || false);
        print(false || false);
        //�q������:�֦�1���_�ͥB��q�j��0
        print("�O�_�q��" +(key==1&&health>0));
        //�q������:�֦�2���H�W(�j�󵥩�)�_�۩�5�ӥH�W����
        print("�O�_�q��" + (jewel >= 2 || coin >= 5));

        //�ۤ�
        print(!true);
        print(!false);
        #endregion
    }
}