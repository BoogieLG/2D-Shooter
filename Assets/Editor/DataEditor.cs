using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

public class DataEditor : OdinMenuEditorWindow
{
    [MenuItem("My Windows/ScriptableObjects")]
    private static void OpenWindow()
    {
        GetWindow<DataEditor>().Show();
    }

    private CreateNewEnemyData createNewEnemyData;
    private CreateNewWeaponData createNewWeaponData;

    protected override void OnDestroy()
    {
        base.OnDestroy();

        if (createNewEnemyData != null)
        {
            DestroyImmediate(createNewEnemyData.enemies);
        }
        if (createNewWeaponData != null)
        {
            DestroyImmediate(createNewWeaponData.weapon);
        }
    }
    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();

        createNewEnemyData = new CreateNewEnemyData();
        tree.Add("Enemies/Create New Enemy", createNewEnemyData);
        tree.AddAllAssetsAtPath("Enemies", "Assets/ScriptableObjects/Enemies", typeof(EnemyScriptableObjects),true);

        createNewWeaponData = new CreateNewWeaponData();
        tree.Add("Weapons/Create New Weapon", createNewWeaponData);
        tree.AddAllAssetsAtPath("Weapons", "Assets/ScriptableObjects/Weapons", typeof(WeaponScriptableObject),true,true);

        return tree;
    }

    protected override void OnBeginDrawEditors()
    {
        OdinMenuTreeSelection selected = this.MenuTree.Selection;

        SirenixEditorGUI.BeginHorizontalToolbar();
        {
            GUILayout.FlexibleSpace();
            if (SirenixEditorGUI.ToolbarButton("Delete Current"))
            {
                ScriptableObject asset = selected.SelectedValue as ScriptableObject;
                string path = AssetDatabase.GetAssetPath(asset);
                AssetDatabase.DeleteAsset(path);
                AssetDatabase.SaveAssets();
            }
        }
        SirenixEditorGUI.EndHorizontalToolbar();
    }
    public class CreateNewEnemyData
    {
        public CreateNewEnemyData()
        {
            enemies = ScriptableObject.CreateInstance<EnemyScriptableObjects>();
            enemies.EnemyName = "New Enemy Data";
        }

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
        public EnemyScriptableObjects enemies;

        [Button("Add New Enemy Scriptable Object")]
        private void createNewData()
        {
            AssetDatabase.CreateAsset(enemies, "Assets/ScriptableObjects/Enemies/" + enemies.EnemyName + ".asset");
            AssetDatabase.SaveAssets();

            enemies = ScriptableObject.CreateInstance<EnemyScriptableObjects>();
            enemies.EnemyName = "New Enemy Data";
        }
    }

    public class CreateNewWeaponData
    {
        public CreateNewWeaponData()
        {
            weapon = ScriptableObject.CreateInstance<WeaponScriptableObject>();
            weapon.WeaponName = "New Weapon Data";
        }

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
        public WeaponScriptableObject weapon;

        [Button("Add New Enemy Scriptable Object")]
        private void createNewData()
        {
            AssetDatabase.CreateAsset(weapon, "Assets/ScriptableObjects/Weapons/" + weapon.WeaponName + ".asset");
            AssetDatabase.SaveAssets();

            weapon = ScriptableObject.CreateInstance<WeaponScriptableObject>();
            weapon.WeaponName = "New Weapon Data";
        }
    }
}
