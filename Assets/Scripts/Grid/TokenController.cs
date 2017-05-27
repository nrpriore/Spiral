using UnityEngine;
using System.Collections;

public class TokenController : MonoBehaviour {

    private GameController gc;
    private int _index;
    private bool _spawnable;

    private bool _willfocus;

    void Awake() {
        // Set Game Controller for access to game variables
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    #region Setters and Getters
    public int Index {
        get {
            return _index;
        }
        set {
            _index = value;
        }
    }
    public bool Spawnable {
        set {
            _spawnable = value;
        }
    }
    #endregion

    void Update () {
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z - gc.Speed);
        //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + gc.Speed,gameObject.transform.localScale.y + gc.Speed,gameObject.transform.localScale.z);
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * gc.Speed,gameObject.transform.localScale.y * gc.Speed,gameObject.transform.localScale.z);
        if(gameObject.transform.localScale.x > 120) {
            Destroy(gameObject);
        } else if(gameObject.transform.localScale.x > 35 && _willfocus) {
            GameObject.Find("GameCamera").GetComponent<CameraController>().FocusedIndex = _index;
        } else if(gameObject.transform.localScale.x > 1.5 && _spawnable) {
            _spawnable = false;
            _willfocus = true;
            gc.GetComponent<GridController>().GetNextToken(_index);
        }
    }
}
