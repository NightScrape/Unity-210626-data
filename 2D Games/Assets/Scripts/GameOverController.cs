using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*�C���������
 * 1.�����Ҧ��Ǫ���Ĳ�o�ǰe��
 * 2.�C������
 */
public class GameOverController : MonoBehaviour
{
    [Header("�����e���ʵe����")]
    public Animator aniFinal;
    [Header("�������D")]
    public Text textFinaltitle;
    [Header("�C���ӧQ�P���Ѥ�r")]
    //�r�ꤺ�Q��\n�i�洫��
    [TextArea(1, 3)]
    public string StringWin = "�A�w���\�����Ҧ��Ǫ�...\n�{�b�~�򩹫e�ڶi�a...";
    [TextArea(1, 3)]
    public string StringLose = "�D�ԥ���...\n�ЦA���A�F...";
    [Header("���s�P���}���s")]
    public KeyCode kcReplay = KeyCode.R;
    public KeyCode kcQuit = KeyCode.Q;
    /// <summary>
    /// �O�_�C������
    /// </summary>
    private bool isGameOver;

    private void Update()
    {
        Replay();
        Quit();
    }
    private void Replay()
    {
        if (isGameOver && Input.GetKeyDown(kcReplay)) SceneManager.LoadScene("�C������");
    }
    private void Quit()
    {
        if (isGameOver && Input.GetKeyDown(kcQuit)) Application.Quit();
    }
    /// <summary>
    /// ��ܹC�������e��
    /// </summary>
    /// <param name="win">�O�_���</param>
    public void ShowGameOverView(bool win)
    {
        isGameOver = true;
        aniFinal.enabled = true;
        if (win) textFinaltitle.text = StringWin;
        else textFinaltitle.text = StringLose;
    }
}
