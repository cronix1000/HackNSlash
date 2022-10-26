using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteGen : MonoBehaviour
{
    public GameObject chunk;

    public MeshRenderer chunkMesh;
    const float scale = 5f;

    const float viewerMoveThresholdForChunkUpdate = 5f;
    const float sqrViewerMoveThresholdForChunkUpdate = viewerMoveThresholdForChunkUpdate * viewerMoveThresholdForChunkUpdate;

    public Transform viewer;
    public Material mapMaterial;

    public static Vector2 viewerPosition;
    Vector2 oldViewerPosition;
    static MapGen mapGen;

    int chunkSide;
    int chunksVisibleInViewDst;

    Dictionary<Vector2, GameObject> chunkDictionary = new Dictionary<Vector2, GameObject                                                                                                                                                                                                                                                                                                                                                                                     >();
    List<GameObject> chunksVisibleLastUpdate = new List<GameObject>();
    private void Start()
    {
        //mesh = chunk.GetComponent<MeshRenderer>();
        chunksVisibleInViewDst = Mathf.RoundToInt(chunk.GetComponent<MeshRenderer>().bounds.size.x);
        UpdateVisibleChunks();
        RenderVisibleChunks();

    }

    private void RenderVisibleChunks()
    {
        for (int yOffset = -chunksVisibleInViewDst; yOffset <= chunksVisibleInViewDst; yOffset++)
        {
            for (int xOffset = -chunksVisibleInViewDst; xOffset <= chunksVisibleInViewDst; xOffset++)
            {
                
                //GameObject groundBlock = Instantiate(chunksVisibleLastUpdate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
            }
        }
    }

    private void UpdateVisibleChunks()
    {
        for (int i = 0; i < chunksVisibleLastUpdate.Count; i++)
        {
            chunksVisibleLastUpdate[i].SetActive(false);
        }
        chunksVisibleLastUpdate.Clear();

        int currentChunkCoordX = Mathf.RoundToInt(viewerPosition.x / chunk.GetComponent<MeshRenderer>().bounds.size.x - 1);
        int currentChunkCoordY = Mathf.RoundToInt(viewerPosition.y / chunk.GetComponent<MeshRenderer>().bounds.size.x - 1);

        for (int yOffset = -chunksVisibleInViewDst; yOffset <= chunksVisibleInViewDst; yOffset++)
        {
            for (int xOffset = -chunksVisibleInViewDst; xOffset <= chunksVisibleInViewDst; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);
                if (!(chunkDictionary.ContainsKey(viewedChunkCoord)))
                {
                    chunkDictionary.Add(viewedChunkCoord, chunk);
                }

            }
        }
    }

    private void Update()
    {

        viewerPosition = new Vector2(viewer.position.x, viewer.position.z) / scale;


        if ((oldViewerPosition - viewerPosition).sqrMagnitude > sqrViewerMoveThresholdForChunkUpdate)
        {
            oldViewerPosition = viewerPosition;
            UpdateVisibleChunks();
        }
    }

    private void UpdateChunk()
    {
        
    }
}
