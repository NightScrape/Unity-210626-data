using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*遊戲結束控制器
 * 1.擊殺所有怪物並觸發傳送門
 * 2.遊戲失敗
 */
public class GameOverController : MonoBehaviour
{
    [Header("結束畫面動畫元件")]
    public Animator aniFinal;
    [Header("結束標題")]
    public Text textFinaltitle;
    [Header("遊戲勝利與失敗文字")]
    //字串內利用\n進行換行
    [TextArea(1, 3)]
    public string StringWin = "你已成功擊殺所有怪物...\n現在繼續往前邁進吧...";
    [TextArea(1, 3)]
    public string StringLose = "挑戰失敗...\n請再接再厲...";
    [Header("重新與離開按鈕")]
    public KeyCode kcReplay = KeyCode.R;
    public KeyCode kcQuit = KeyCode.Q;
    /// <summary>
    /// 是否遊戲結束
    /// </summary>
    private bool isGameOver;

    private void Update()
    {
        Replay();
        Quit();
    }
    private void Replay()
    {
        if (isGameOver && Input.GetKeyDown(kcReplay)) SceneManager.LoadScene("遊戲場景");
    }
    private void Quit()
    {
        if (isGameOver && Input.GetKeyDown(kcQuit)) Application.Quit();
    }
    /// <summary>
    /// 顯示遊戲結束畫面
    /// </summary>
    /// <param name="win">是否獲勝</param>
    public void ShowGameOverView(bool win)
    {
        isGameOver = true;
        aniFinal.enabled = true;
        if (win) textFinaltitle.text = StringWin;
        else textFinaltitle.text = StringLose;
    }
}
