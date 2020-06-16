using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 會竄逃的人類
/// </summary>
public class PeopleRun : People
{
    /// <summary>
    /// 最終座標
    /// </summary>
    private Vector3 final;
    [Header("半徑"),Range(1,30)]
    public float radis = 5;
    
    private void Update()
    {
        Flee();
    }
    /// <summary>
    /// 竄逃
    /// </summary>
    private void Flee()
    {
        if(agent.remainingDistance<1.5f)
        {
        // 隨機座標 = 隨機.球內隨機點 *半徑 + 中心點
        Vector3 pointPan = Random.insideUnitSphere * radis + transform.position;

        //導覽網格碰撞 碰撞點
        NavMeshHit hit;

        // 導覽網格.樣本座標(座標,碰撞點,半徑,圖層)
        // out 執行方法會將結果直接儲存到傳入的參數內
        // 執行後會將取得的隨機點儲存在hit參數內
        NavMesh.SamplePosition(pointPan, out hit, 5, 1);

        //最終座標 = 碰撞點.座標
        final = hit.position;
        }
        

        agent.SetDestination(final);
    }
}
