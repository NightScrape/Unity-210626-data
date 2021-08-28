using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// 傳送門管理:檢查玩家是否進入遊戲或完成任務
/// </summary>
public class TeleportTrigger : MonoBehaviour
{
    /*
     * 1.靜態為同類別之所有物件共用(故不是和複數同類使用
     * 2.載入場頸後不恢復預設值
     * 3.靜態不顯示於屬性面板
     */
    public static int CountAllEnemy;
    /*UnityButton自行定義方式
     * 1.使用UnityEngine.Evets API
     * 2.定義UnityEvent欄位
     * 3.在執行處使用Invoke
     * 4.僅限零參數貨單參數之方法
     */
    [Header("通關事件")]
    public UnityEvent OnPass;

    private void Start()
    {
        CountAllEnemy = GameObject.FindGameObjectsWithTag("敵人").Length;
    }
    /*觸發事件 OnTriggerEnter
     * 1.執行碰撞雙方須皆有Collider
     * 2.其中一個要有rigidbody
     * 3.其中一個有勾選is Trigger
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "玩家" && CountAllEnemy == 0)
            OnPass.Invoke();
    }
}
