using UnityEngine;
using System.Linq;  //�ޥ�LinQ�d��API-�d��}�C���

public class LearnLinQ : MonoBehaviour
{
    public int[] scores = { 10, 80, 60, 30, 70, 99, 77, 0, 1 };
    public int[] result;
    public int[] resultEqualThan60;
    private void Start()
    {
        //�ˬd���S��0��
        //�H�ڹF Lambda C#3.0���᪺²�g�Ҧ�
        //�ˬd��e���L��0����
        //x ���N�W��, =>���]�w����
        result=scores.Where(x => x == 0 ).ToArray();

        //�ˬd���S���j�󵥩�60��
        resultEqualThan60=scores.Where(y => y >= 60).ToArray();
    }
}
