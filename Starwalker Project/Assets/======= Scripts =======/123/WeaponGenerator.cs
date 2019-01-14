using System.Collections.Generic;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{
    [Tooltip("Cписок оружия")]
    [SerializeField] private List<GameObject> Weapon;

    /// <summary>
    /// Даёт стартовое оружие
    /// </summary>
    public GameObject GetStartWeapon()
    {
        return Weapon[0];
    }
}
