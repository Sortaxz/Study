using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour
{
    public Tile tilePrefab;
    public TitleState[] titleStates;
    [SerializeField] private TileGrid grid;
    private List<Tile> tiles;

    private void Awake()
    {
        grid = GetComponentInChildren<TileGrid>();
        tiles =new List<Tile>(16);
    }
    void Start()
    {
        CreateTile();
        CreateTile();
    }

    private void CreateTile()
    {
        Tile tile = Instantiate(tilePrefab,grid.transform);
        tile.SetState(titleStates[0],2);
        tile.Spawn(grid.GetRandomEmptyCell());
    }

}
