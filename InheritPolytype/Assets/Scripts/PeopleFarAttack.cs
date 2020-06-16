using UnityEngine;

public class PeopleFarAttack : PeopleTrack
{
    [Header("停止距離"),Range(1,10)]
    public float stop = 3f;

    [Header("子彈")]
    public GameObject bullet;

    [Header("冷卻"),Range(0.1f,3f)]
    public float cd = 1.5f;

    private float timer;

    protected override void Start()
    {
        agent.stoppingDistance = stop;
        target = GameObject.Find("殭屍").transform;
    }

    protected override void Track()
    {
        agent.SetDestination(target.position);
        if (agent.remainingDistance <= stop) Attack(); //如果代理器.距離 < 停止距離就攻擊
    }

    private void Attack()
    {
        timer += Time.deltaTime;
        if (timer>=cd)
        {
            timer = 0;
            ani.SetTrigger("攻擊");
            GameObject temp = Instantiate(bullet, transform.position + transform.forward + transform.up, transform.rotation);
            Rigidbody rig = temp.AddComponent<Rigidbody>(); //添加元件
            rig.AddForce(transform.forward * 1500);
        }
    }

    
}
