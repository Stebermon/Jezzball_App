using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int colLen, rowLen;
    public GameObject blocks;
    private float xStart, yStart;
    private float xSpace, ySpace;
    // Start is called before the first frame update
    void Start()
    {
        xSpace = 1.5f;
        ySpace = 1.4f;
        var cam = Camera.main;
        var topLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        // Add half the size of the block to topLeft coordinate to position the sprite perfectly at the edge
        xStart = topLeft.x + xSpace / 2;
        yStart = topLeft.y + ySpace / 2;
        //transform.localScale

        Debug.Log(xStart);
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
