using System;
using UnityEngine;

[Serializable]
public class Recipe 
{
    public bool CheckBit;
    [SerializeField]
        private Fruit _fruitOne;
    [SerializeField] 
        private Fruit _fruitTwo;
    [SerializeField]
        private Fruit _result;

        public Fruit FruitOne => _fruitOne;
        public Fruit FruitTwo => _fruitTwo;
        public Fruit Result => _result;
    
}
