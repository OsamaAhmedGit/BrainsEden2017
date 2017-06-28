using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevelGenerator : MonoBehaviour {

    public GameObject[] tiles;
    public GameObject wall;

    public List <Vector3> createdTiles;

    public int tileAmount;
    public int tileSize;

    public float delay;


    //Drawing Walls Around Level
    public float minY = 99999999;
    public float maxY = 0;
    public float minX = 99999999;
    public float maxX = 0;
    public float xAmount;
    public float yAmount;
    public float furtherWallsX;
    public float furtherWallsY;


	void Start () {
        StartCoroutine(GenerateLevel());
	}

    IEnumerator GenerateLevel()
    {
        for(int i = 0; i < tileAmount; i++)
        {
            int direction = Random.Range(0, 3);

            int tileType = Random.Range(0, tiles.Length);

            DrawTile(tileType);

            Move(direction);

            yield return new WaitForSeconds(delay);

            if(i == tileAmount - 1)
            {
                FinishedDrawing();
            }
        }

        yield return 0;
    }

    void Move(int direction)
    {
        switch(direction)
        {
            case 0:

                transform.position = new Vector3(transform.position.x, transform.position.y + tileSize, 0);

                break;

            case 1:

                transform.position = new Vector3(transform.position.x + tileSize, transform.position.y, 0);

                break;

            case 2:

                transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, 0);

                break;

            case 3:

                transform.position = new Vector3(transform.position.x - tileSize, transform.position.y, 0);

                break;
                
        }
    }

    void DrawTile(int TileType)
    {

        if (!createdTiles.Contains(transform.position))
        {
            GameObject tileObject;

            tileObject = Instantiate(tiles[TileType], transform.position, transform.rotation) as GameObject;

            createdTiles.Add(tileObject.transform.position);
        }
        else
            tileAmount++;
    }

    void FinishedDrawing()
    {
        CalculateWallValues();
        DrawWalls();
    }

    void CalculateWallValues()
    {
        for(int i = 0; i < createdTiles.Count; i++)
        {
            //Sets the min and max X and Y values of the map
            if(createdTiles[i].y < minY)
            {
                minY = createdTiles[i].y;
            }

            if (createdTiles[i].y > maxY)
            {
                maxY = createdTiles[i].y;
            }

            if (createdTiles[i].x < minX)
            {
                minX = createdTiles[i].x;
            }

            if (createdTiles[i].x > maxX)
            {
                maxX = createdTiles[i].x;
            }

            //Calculate the X distance between the min and max tiles on the map and draw the extra walls so the player cant see past
            xAmount = ((maxX - minX) / tileSize) + furtherWallsX;

            //Calculate the Y distance between the min and max tiles on the map and draw the extra walls so the player cant see past
            yAmount = ((maxY - minY) / tileSize) + furtherWallsY;
        }
    }

    void DrawWalls()
    {
        for(int x = 0; x < xAmount; x++)
        {
            for(int y = 0; y < yAmount; y++)
            {
                if(!createdTiles.Contains(new Vector3((minX - (furtherWallsX * tileSize) / 2) + (x * tileSize), (minY - (furtherWallsY * tileSize) / 2) + (y * tileSize))))
                {
                    Instantiate(wall, new Vector3((minX - (furtherWallsX * tileSize) / 2) + (x * tileSize), (minY - (furtherWallsY * tileSize) / 2) + (y * tileSize)), transform.rotation);
                }
            }
        }
    }
}
