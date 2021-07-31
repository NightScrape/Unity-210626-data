using UnityEngine;
using UnityEngine.SceneManagement;  //引入場景管理API

public class SceneController : MonoBehaviour
{
    //Unity 按鈕如何與腳本溝通
    //1.公開方法
    //2.需要實體物件掛此腳本
    //※任一腳本(包含未啟用)內部有問題或類別與檔名不同都會讓Unity無法掛上腳本

    /// <summary>
    /// 載入遊戲場景
    /// </summary>
    public void LoadGameScene()
    {
        //Invoke 延遲載入-等待指定時間後呼叫方法
        //延遲呼叫(方法名稱,延遲時間)
        Invoke("DelayLoadGameScene", 2);
    }
    //等待一段時間後執行方法
    /// <summary>
    /// 延遲載入場景
    /// </summary>
    private void DelayLoadGameScene()
    {
        SceneManager.LoadScene("遊戲場景");  //場景管理.載入場景(場景名稱)-載入指定場景
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        Invoke("DelayQuitGame", 2);
    }
    /// <summary>
    /// 延遲離開遊戲
    /// </summary>
    private void DelayQuitGame()
    {
        Application.Quit(); //應用程式.離開()-關閉遊戲
        print("離開遊戲");  //Quit在編輯器不會執行
    }
}
