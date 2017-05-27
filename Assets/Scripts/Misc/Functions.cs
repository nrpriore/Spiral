using UnityEngine;

public class Functions {

    #region Variables for returning the index of the next token
    private int _minCount = 3;
    private int _maxCount = 5;
    private int _curCount = 1;

    private float _moveZero = 0.50f;
    private float _moveOne = 0.75f;
    private float _moveTwo = 0.90f;
    private float _moveThree = 1.00f;
    #endregion

    private GameController gc;

    void Awake() {
        // Set Game Controller for access to game variables
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Return the index of the next token
    public int NextIndex(int prevIndex) {
        // Adds next move to previous index and then find the remainder from the total num tokens
        int nextIndex = prevIndex + NextMove();
        nextIndex = nextIndex % gc.NumTokens; // ex: 4 % 8 = 4 // 10 % 8 = 2
                                           // Returns between 0 and numTokens - 1
        return nextIndex;
    }

    // Determine how far to rotate the next token
    public int NextMove() {
        // Declare var that will be returned
        int nextIndex = new int();

        // If current count is less than minimum count, return 0
        if(_curCount >= _minCount) {
            // Use random number to determine move
            float _rand = Random.value;

            // If current count equals max count, exclude adjust random number to exclude _moveZero chance
            if(_curCount == _maxCount) {
                _rand = _moveZero + Random.value * (1 - _moveZero);
            }

            // If rand is less than _moveZero chance, stay straight
            if(_rand <= _moveZero) {
                nextIndex = 0;
            }

            // Else if rand is less than _moveOne chance, move one
            else if(_rand <= _moveOne) {
                if(_rand < (_moveZero + _moveOne) / 2) {
                    nextIndex = -1; // Move left
                } else {
                    nextIndex = 1; // Move right
                }
            }

            // Else if rand is less than _moveTwo chance, move two
            else if(_rand <= _moveTwo) {
                if(_rand < (_moveOne + _moveTwo) / 2) {
                    nextIndex = -2; // Move left
                } else {
                    nextIndex = 2; // Move right
                }
            }

            // Else if rand is less than _moveThree chance, move three
            else if(_rand <= _moveThree) {
                if(_rand < (_moveTwo + _moveThree) / 2) {
                    nextIndex = -3; // Move left
                } else {
                    nextIndex = 3; // Move right
                }
            }
        } else {
            nextIndex = 0;
        }

        // If returning 0, add to current count, else reset it to 1
        if(nextIndex == 0) {
            _curCount++;
        } else {
            _curCount = 1;
        }

        // Returns between -3 to 3  
        return nextIndex;
    }

}
