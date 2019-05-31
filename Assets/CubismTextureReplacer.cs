using System.Collections.Generic;
using Live2D.Cubism.Core;
using Live2D.Cubism.Rendering;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Replace active Live2D model texture(s) temporarily
/// at runtime or permanently in editor.
/// </summary>
public class CubismTextureReplacer : MonoBehaviour
{
    public CubismModel model;
    public List<Texture2D> newTextures;

#if UNITY_EDITOR
    [CustomEditor(typeof(CubismTextureReplacer))]
    public class LauncherEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var textureReplacer = target as CubismTextureReplacer;

            if (textureReplacer != null && GUILayout.Button("Replace model texture(s)"))
            {
                textureReplacer.Reload();
            }
        }
    }
#endif

    public void Reload()
    {
        if (model != null)
        {
            if (newTextures != null && newTextures.Count != 0)
            {
                int replacedCount = 0;

                foreach (var drawable in model.Drawables)
                {
                    CubismRenderer r = drawable.gameObject.GetComponent<CubismRenderer>();
                    bool hasTextureForDrawable = drawable.TextureIndex < newTextures.Count && newTextures[drawable.TextureIndex] != null;

                    if (r != null && hasTextureForDrawable) {
                        r.MainTexture = newTextures[drawable.TextureIndex];
                        replacedCount++;
                    }
                }

                Debug.Log("Replaced textures for model \"" + model.name + "\" (" + replacedCount + "/" + model.Drawables.Length + " drawables).");
            }
            else
            {
                Debug.Log("Set replacement texture(s) first.");
            }
        }
        else
        {
            Debug.Log("Set model first.");
        }
    }
}
