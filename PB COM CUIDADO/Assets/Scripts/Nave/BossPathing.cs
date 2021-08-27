using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPathing : MonoBehaviour
{
    BossConfig bossConfig;
    List<Transform> bosspoints;
    int bosspointIndex = 0;

    void Start()
    {
        bosspoints = bossConfig.GetWaypoints();
        transform.position = bosspoints[bosspointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetBossConfig(BossConfig bossConfig)
    {
        this.bossConfig = bossConfig;
    }

    private void Move()
    {
        if (bosspointIndex <= bosspoints.Count - 1)
        {
            var targetPosition = bosspoints[bosspointIndex].transform.position;
            var movementThisFrame = bossConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                bosspointIndex++;

            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
