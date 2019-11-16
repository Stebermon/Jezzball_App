using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int colNum, rowNum;
    public GameObject blocks;
    private float xStart, yStart;
    private float xSpace, ySpace;
    // Start is called before the first frame update
    void Start()
    {
        xSpace = 1f;
        ySpace = 1f;
        var cam = Camera.main;
        var topLeft = (Vector2)cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
        var topRight = (Vector2)cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));

        // Add half the size of the block to topLeft coordinate to position the sprite perfectly at the edge
        xStart = topLeft.x + xSpace / 2;
        yStart = topLeft.y + ySpace / 2;


        Debug.Log(xSpace);
        Debug.Log(blocks.GetComponent<SpriteRenderer>().bounds.size);
        for (int i = 0; i < colNum * rowNum; i++)
        {
            Instantiate(blocks, new Vector3(xStart + (xSpace * (i % colNum)), yStart + (-ySpace * (i / colNum))), Quaternion.identity);
            //block.transform.localScale = new Vector2(1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
