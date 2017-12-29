using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPool : ObjectPool {

   
    
    
    public int changeDifficultNode = 8;//改变生成速率的节点，也就是改变游戏难度的一个值，时间/值 是改变难度的点

    private float timeOfDifficultChange = 0;

    public override void Update()
    {
        base.Update();
        ChangeDifficult();
    }

    
    
    /// <summary>
    /// 改变游戏难度
    /// </summary>
    void ChangeDifficult()
    {
        timeOfDifficultChange += Time.deltaTime;
        if (spawnRate >= 0.5)
        {
            if (timeOfDifficultChange == changeDifficultNode)
            {
                timeOfDifficultChange = 0;
                spawnRate -= 0.3f;
            }
        }
        
    }
    
}
