using System;
using UnityEngine;

[Serializable]
public class Recipe 
{

    [SerializeField]
        private FruitsConfig _fruitOne;
    [SerializeField] 
        private FruitsConfig _fruitTwo;
    [SerializeField]
        private FruitsConfig _result;

        public FruitsConfig FruitOne => _fruitOne;
        public FruitsConfig FruitTwo => _fruitTwo;
        public FruitsConfig Result => _result;
    
}
