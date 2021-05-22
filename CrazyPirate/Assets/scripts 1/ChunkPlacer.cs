using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    private List<Chunk> spawnedChunks = new List<Chunk>();
    public Chunk FirstChunk;
    // Start is called before the first frame update
    void Start()
    {
        spawnedChunks.Add(FirstChunk);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.position.y - 20 < spawnedChunks[spawnedChunks.Count - 1].End.position.y)
        {
            SpawnChunk();
        }
    }
    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);
        if(spawnedChunks.Count >= 5)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }
    
}
