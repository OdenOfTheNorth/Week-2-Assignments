using UnityEngine;

[CreateAssetMenu(fileName = "Wall", menuName = "Walls/Hp And Materials")]
public class Wall_Info : ScriptableObject
{
    public float maxHealth = 100.0f;
    public Material material;
    public AudioClip damageSound;
    public AudioClip deathSound;
}
