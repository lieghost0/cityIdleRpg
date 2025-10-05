using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : Singleton<LayerManager>
{
    public enum LayerType
    {
        level1 = 0,
        level2,
        level3,
    }

    public Transform[] layers;

    public void Init(Transform[] layers)
    {
        this.layers = layers;
    }

    public Transform GetLayerParent(LayerType layerType)
    {
        if(layers.Length > (int)layerType)
        {
            Transform layer = layers[(int)layerType];
            return layer;
        }
        else
        {
            Debug.LogError("未定义的层级类型：" + layerType);
            return null;
        }
    }
}
