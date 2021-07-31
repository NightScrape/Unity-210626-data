using UnityEngine;
using UnityEngine.SceneManagement;  //�ޤJ�����޲zAPI

public class SceneController : MonoBehaviour
{
    //Unity ���s�p��P�}�����q
    //1.���}��k
    //2.�ݭn���骫�󱾦��}��
    //�����@�}��(�]�t���ҥ�)���������D�����O�P�ɦW���P���|��Unity�L�k���W�}��

    /// <summary>
    /// ���J�C������
    /// </summary>
    public void LoadGameScene()
    {
        //Invoke ������J-���ݫ��w�ɶ���I�s��k
        //����I�s(��k�W��,����ɶ�)
        Invoke("DelayLoadGameScene", 2);
    }
    //���ݤ@�q�ɶ�������k
    /// <summary>
    /// ������J����
    /// </summary>
    private void DelayLoadGameScene()
    {
        SceneManager.LoadScene("�C������");  //�����޲z.���J����(�����W��)-���J���w����
    }

    /// <summary>
    /// ���}�C��
    /// </summary>
    public void QuitGame()
    {
        Invoke("DelayQuitGame", 2);
    }
    /// <summary>
    /// �������}�C��
    /// </summary>
    private void DelayQuitGame()
    {
        Application.Quit(); //���ε{��.���}()-�����C��
        print("���}�C��");  //Quit�b�s�边���|����
    }
}
