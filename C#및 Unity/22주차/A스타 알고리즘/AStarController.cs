using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AStarController : MonoBehaviour
{
    int[,] tileMap;
    public Transform offsetTransform;
    public NodeComponent[,] nodeTiles;
    private LineRenderer lineRenderer;

    public NodeComponent costType;

    void Start()
    {
        tileMap = new int[10, 10]
            {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 1, 1, 0, 0, 1 },
                { 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 },
                { 1, 1, 0, 1, 0, 0, 1, 0, 2, 1 },
                { 1, 0, 0, 1, 1, 1, 1, 0, 0, 1 },
                { 1, 0, 2, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 0, 0, 1, 1, 1, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            };


        lineRenderer = GetComponent<LineRenderer>();

        nodeTiles = new NodeComponent[10, 10];

        var temp = offsetTransform.GetComponentsInChildren<NodeComponent>();

        for(int y=0; y<10; y++)
        {
            for(int x=0;x<10;x++)
            {
                nodeTiles[y, x] = temp[(y * 10) + x];
                nodeTiles[y, x].Set(y, x, tileMap[y, x]);
            }        
        }
    }

    public bool PathFinding(in Point start,in Point end, Queue<NodeComponent> pathQueue)
    {
        List<Point> path;
        pathQueue.Clear();
        if (AStar.PathFinding(nodeTiles, start, end, out path))
        {
            lineRenderer.positionCount = path.Count;
            int curIndex = 0;
            foreach (Point p in path)
            {
                pathQueue.Enqueue(nodeTiles[p.y, p.x]);
                lineRenderer.SetPosition(curIndex++, nodeTiles[p.y, p.x].transform.position);
            }
            return true;
        }    
        return false;
    }
}
