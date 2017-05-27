using UnityEngine;

public class GridController:MonoBehaviour {

    private float[] Zpos;

    private GameController gc;
    private GameObject _grid;

    void Awake() {
        // Z positions to load tokens in
        Zpos = new float[11] { -7.2f,-5.7f,-3.5f,0.0f,5.0f,13.0f,25.0f,44.0f,73.0f,118.0f,190.0f };
        // Set Game Controller for access to game variables
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Build the starting tokens/objects
    public void CreateLevel() {
        // Create the grid object for the editor Hierarchy
        _grid = new GameObject(); _grid.name = "Grid";

        // Create the initial tokens and assign "Grid" as the parent
        PlaceToken(0).Spawnable = true;
    }

    // Gets the next index and places tokens
    public void GetNextToken(int prevIndex) {
        int move = gc.Call.NextMove();
        PlaceNextToken(prevIndex,move);
    }

    // Takes the prev and next index to build next token and all connecting tokens
    private void PlaceNextToken(int prevIndex,int move) {
        if(move < 0) {
            for(int i = prevIndex;i > prevIndex + move;i--) {
                PlaceToken(i % gc.NumTokens);
            }
        } else if(move > 0) {
            for(int i = prevIndex;i < prevIndex + move;i++) {
                PlaceToken(i % gc.NumTokens);
            }
        }
        int index = (prevIndex + move) % gc.NumTokens;
        PlaceToken(index).Spawnable = true;
    }

    // Takes an index and places a token
    private TokenController PlaceToken(int index) {
        GameObject _token;
        _token = Instantiate(gc.Prefab.Token,new Vector3(0,0,Zpos[Zpos.Length-1]),Quaternion.identity) as GameObject;
        _token.transform.parent = _grid.transform;
        _token.transform.rotation = Quaternion.Euler(0,0,index * (360/gc.NumTokens));
        TokenController tc = _token.GetComponent<TokenController>();
        tc.Index = index;
        return tc;
    }

}

