using UnityEngine;

public class GameController : MonoBehaviour {

    private Functions _call;    // Class holding various value-returning functions
    private Prefabs _prefabs;   // Call holding instantiable game objects

    // Dynamic game settings
    private int _numTokens;
    private float _speed;

	void Start () {
        #region Initialize static variables
        _call = new Functions();
        _prefabs = gameObject.GetComponent<Prefabs>();
        #endregion

        // Call starting functions
        InitializeGameSettings();
        CreateLevel();
    }

    #region Setters and Getters
    public Functions Call {
        get {
            return _call;
        }
    }
    public Prefabs Prefab {
        get {
            return _prefabs;
        }
    }
    public int NumTokens {
        get {
            return _numTokens;
        }
        set {
            _numTokens = value;
        }
    }
    public float Speed {
        get {
            return _speed;
        }
        set {
            _speed = value;
        }
    }
    #endregion

    private void InitializeGameSettings() {
        _numTokens = 8;
        _speed = 1.02f;
    }

    public void CreateLevel() {
        GridController gc = gameObject.AddComponent<GridController>();
        gc.CreateLevel();
    }
}
