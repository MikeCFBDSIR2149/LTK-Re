using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoSingleton<PlayersManager>
{
    [HideInInspector]
    public Dictionary<int,PlayerBasic> players;
    [HideInInspector]
    public Dictionary<Vector2, int> distanceSearch;
    protected override void Awake()
    {
        base.Awake();
        distanceSearch = new Dictionary<Vector2, int>();
    }
    private void Start()
    {
        for (int i = 1; i <= players.Count; i++)
        {
            for(int j = 1; j <= distanceSearch.Count; j++)
            {
                if (i != j)
                {
                    distanceSearch.Add(new Vector2(i, j), Mathf.Abs(i - j));
                }
            }
        }
    }
    public void ReCalculateDistance(PlayerBasic player)
    {
        for (int i = 1; i <= players.Count; i++)
        {
            for (int j = 1; j <= distanceSearch.Count; j++)
            {
                if (i != j && i == player.seatNum)
                {
                    distanceSearch[new Vector2(i, j)] = Mathf.Abs(i - j) - player.distanceMinus; 
                }
                if (i != j && j == player.seatNum)
                {
                    distanceSearch[new Vector2(i, j)] = Mathf.Abs(i - j) + player.distancePlus;
                }
            }
        }
    }
}
