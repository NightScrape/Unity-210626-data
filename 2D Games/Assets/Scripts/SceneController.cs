using UnityEngine;
using UnityEngine.SceneManagement;  //�ޤJ�����޲zAPI

public class SceneController : MonoBehaviour
{
    //Unity ���s�p��P�}�����q
    //1.���}��k
    //2.�ݭn���骫�󱾦��}��

    /// <summary>
    /// ���J�C������
    /// </summary>
    public void LoadGameScene()
    {
        SceneManager.LoadScene("�C������");  //�����޲z.���J����(�����W��)-���J���w����
    }
    /// <summary>
    /// ���}�C��
    /// </summary>
    public void QuitGame()
    {
        Application.Quit(); //���ε{��.���}()-�����C��
        print("���}�C��");  //Quit�b�s�边���|����
    }

}
