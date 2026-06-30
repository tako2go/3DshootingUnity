using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class Dialogue_UI_Data : MonoBehaviour
{
    [Serializable]
    public class charactor_Image
    {
        public Image charactor_Left;
        public Image charactor_Right;
        public Image chractor_Pet;
    }

    [Serializable]
    public class TextWindow
    {
        public Image TextArea;
        public TextMeshPro text;
    }
}
