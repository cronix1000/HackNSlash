using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGen : MonoBehaviour
{
    const float scale = 5f;

    const float viewerMoveThresholdForChunkUpdate = 5f;
    const float sqrViewerMoveThresholdForChunkUpdate = viewerMoveThresholdForChunkUpdate * viewerMoveThresholdForChunkUpdate;

    public static Vector2 viewerPosition;
    Vector2 oldViewerPosition;
    static MapGen mapGen;

    int chunkSide;
    int chunksVisibleInViewDst;
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }

    private void UpdateChunk()
    {
        
    }
}
