using System.Collections.Generic;
using UnityEngine;

class MaxPet : MonoBehaviour, IRandomWalker
{
	//Add your own variables here.
	//Do not use processing variables like width or height
	private int arenaWidth;
	private int arenaHeight;
	private int ticks = 0;

	private GameObject holder;


	private Vector2 playerPosition;
	private List <Vector2> iveBeenHere;
	private List <Transform> otherPlayers;

   
    public string GetName()
	{
		return "Mackan"; 
	}

	public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
	{
		
		//Select a starting position or use a random one.
		float x = Random.Range(1, playAreaWidth/2);
		float y = Random.Range(1, playAreaHeight/2);

		arenaHeight = playAreaHeight;
		arenaWidth = playAreaWidth;
		

		iveBeenHere = new List<Vector2>();
		otherPlayers = new List<Transform>();

		

		playerPosition = new Vector2(x, y);
		//a PVector holds floats but make sure its whole numbers that are returned!
		return new Vector2(x, y);
	}

	public Vector2 Movement()
	{ 
		ticks++; // implement logic for ticks maybe a list that stores the last 100 steps youve taken
		Vector2 movement;

		switch (Random.Range(0, 4))
        {
			case 0:
				movement = new Vector2(1, 0);
				break;
			case 1:
				movement = new Vector2(-1, 0);
				break;
			case 2:
				movement = new Vector2(0, 1);
				break;
			default:
				movement = new Vector2(0, -1);
				break;
        }

		if(playerPosition.x > arenaWidth * 0.99)
        {
			switch (Random.Range(0, 3))
			{
				case 0:
					movement = new Vector2(-1, 0);
					break;
				case 1:
					movement = new Vector2(0, 1);
					break;
				default:
					movement = new Vector2(0, -1);
					break;
			}
		}

		if (playerPosition.x <= 0.99)
        {
			switch (Random.Range(0, 3))
			{
				case 0:
					movement = new Vector2(1, 0);
					break;
				case 1:
					movement = new Vector2(0, 1);
					break;
				default:
					movement = new Vector2(0, -1);
					break;
			}
		}

		if (playerPosition.y > arenaHeight * 0.99)
        {
			switch (Random.Range(0, 3))
			{
				case 0:
					movement = new Vector2(-1, 0);
					break;
				case 1:
					movement = new Vector2(1, 0);
					break;
				default:
					movement = new Vector2(0, -1);
					break;
			}
		}

		if(playerPosition.y < 0.99)
        {
			switch (Random.Range(0, 3))
			{
				case 0:
					movement = new Vector2(-1, 0);
					break;
				case 1:
					movement = new Vector2(0, 1);
					break;
				default:
					movement = new Vector2(1, 0);
					break;
			}
		}

		playerPosition += movement;

		if (ticks == 1)
		{
			holder = GameObject.Find("Holder");

			for (int i = 0; i < holder.transform.childCount; i++)
			{
				otherPlayers.Add(holder.transform.GetChild(i));

				if (playerPosition.x == holder.transform.GetChild(i).transform.position.x
					&& playerPosition.y == holder.transform.GetChild(i).transform.position.x)
				{
					otherPlayers.RemoveAt(i);
				}
			}

		}
		//iveBeenHere.Add(playerPosition);
		Debug.Log(otherPlayers.Count);
		return movement;
		
	}
    private int MoveDecision()
    {
		if (playerPosition.y < 0.99)
			return 0; // dont go down
		if (playerPosition.y > arenaHeight * 0.99)
			return 1; // dont go up
		if (playerPosition.x <= 0.99)
			return 2; // dont go left
		if (playerPosition.x > arenaWidth * 0.99)
			return 3; // dont go right

		return 4; // move randomly
    }
	private Vector2 Move(int decision)
    {
		if (decision == 0)
		{
			//dont go down
		}
		else if (decision == 1)
		{
			// dont go up
		}
		else if (decision == 2)
		{
			// dont go left
		}
		else if (decision == 3)
		{
			//dont go right
		}
        else
        {
			//move anywhere
        }

		return Vector2.zero;
    }
}

//All valid outputs:
// Vector2(-1, 0);
// Vector2(1, 0);
// Vector2(0, 1);
// Vector2(0, -1);

//Any other outputs will kill the walker!