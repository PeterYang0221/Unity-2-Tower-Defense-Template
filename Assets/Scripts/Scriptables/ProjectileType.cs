using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile" , menuName = "CustomObjects/Projectile")]

public class ProjectileType : ScriptableObject
{
    public int damage;
    public float speed = 0;
    public float size = 0;
    public Color color = Color.black;
    public Sprite sprite; 
}
