using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// �ǰe���޲z:�ˬd���a�O�_�i�J�C���Χ�������
/// </summary>
public class TeleportTrigger : MonoBehaviour
{
    /*
     * 1.�R�A���P���O���Ҧ�����@��(�G���O�M�ƼƦP���ϥ�
     * 2.���J���V�ᤣ��_�w�]��
     * 3.�R�A����ܩ��ݩʭ��O
     */
    public static int CountAllEnemy;
    /*UnityButton�ۦ�w�q�覡
     * 1.�ϥ�UnityEngine.Evets API
     * 2.�w�qUnityEvent���
     * 3.�b����B�ϥ�Invoke
     * 4.�ȭ��s�ѼƳf��ѼƤ���k
     */
    [Header("�q���ƥ�")]
    public UnityEvent OnPass;

    private void Start()
    {
        CountAllEnemy = GameObject.FindGameObjectsWithTag("�ĤH").Length;
    }
    /*Ĳ�o�ƥ� OnTriggerEnter
     * 1.����I�����趷�Ҧ�Collider
     * 2.�䤤�@�ӭn��rigidbody
     * 3.�䤤�@�Ӧ��Ŀ�is Trigger
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "���a" && CountAllEnemy == 0)
            OnPass.Invoke();
    }
}
