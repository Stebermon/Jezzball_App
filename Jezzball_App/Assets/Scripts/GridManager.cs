using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int colLen, rowLen;
    public float xSpace, ySpace;
    public GameObject blocks;
    public float xStart, yStart;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(blocks.GetComponent<SpriteRenderer>().bounds.size);
        for (int i = 0; i < colLen * rowLen; i++)
        {
            Instantiate(blocks, new Vector3(xStart + (xSpace * (i % colLen)), yStart + (-ySpace * (i / colLen))), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
