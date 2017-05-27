using UnityEngine;

public class CameraController : MonoBehaviour {

    private int _focusedIndex = 0;

    #region Setters and Getters
    public int FocusedIndex {
        get {
            return _focusedIndex;
        }
        set {
            _focusedIndex = value;
        }
    }
    #endregion

    void Update () {
        if(transform.rotation.z != _focusedIndex * 45) {
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(new Vector3(0,0,_focusedIndex * 45)),Time.deltaTime * 20);
                //Vector3.Lerp(transform.rotation.eulerAngles,new Vector3(0,0,_focusedIndex * 45),Time.deltaTime);
        }
    }
}
