using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{

    public List<GameObject> groundList;
    public float offset = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        OrderGround();
    }

    private void OrderGround()
    {
        if(groundList != null)
        {
            groundList = groundList.OrderBy(g => g.transform.position.z).ToList();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGroundPosition()
    {
        GameObject tempGround = groundList[0];
        groundList.Remove(tempGround);
        float newZ = groundList[groundList.Count - 1].transform.position.z + offset;
        tempGround.transform.position = new Vector3(0, -0.5f, newZ);
        groundList.Add(tempGround);
    }

    public void ResetWorld()
    {
        float startZ = -offset;

        foreach(GameObject ground in groundList)
        {
            ground.transform.position = new Vector3(0, -0.5f, startZ);
            startZ += offset;
        }

    }


}
