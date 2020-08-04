using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class Reaction
{
    [SerializeField]
    [Header("Описание реакции")]
    private String reactionDescription;

    [SerializeField]
    [Header("Настроение после действия")]
    private int afterMood;

    public int AfterMood { get => afterMood;}
    public string ReactionDescription { get => reactionDescription;}
}
