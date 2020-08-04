using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[System.Serializable]
public class Action
{
    [SerializeField]
    private String name;
    
    [Header("Реакции на действие")]
    [SerializeField]
    private Reaction[] reactions;

    public String getName() {
        return name;
    }    

    public Reaction getReaction(int mood) {
        return reactions[mood];
    }
}
