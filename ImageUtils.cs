using System;
using System.IO;
using UnityEngine;

    public static class ImageUtils
    {
        public static Sprite LoadSprite(string FilePath, float PixelsPerUnit = 100f, SpriteMeshType spriteType = SpriteMeshType.Tight)
        {
            Texture2D texture2D = ImageUtils.LoadTexture(FilePath, TextureFormat.DXT5);
            if (!texture2D)
            {
                return null;
            }
            return Sprite.Create(texture2D, new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height), new Vector2(0f, 0f), PixelsPerUnit, 0u, spriteType);
        }

        public static Texture2D LoadTexture(string FilePath, TextureFormat format = TextureFormat.DXT5)
        {
            if (File.Exists(FilePath))
            {
                byte[] data = File.ReadAllBytes(FilePath);
                Texture2D texture2D = new Texture2D(2, 2, format, false);
                if (texture2D.LoadImage(data))
                {
                    return texture2D;
                }
            }
            else
            {
                Debug.Log("File not found " + FilePath);
            }
            return null;
        }

        public static Texture2D Render2Texture(RenderTexture rt, TextureFormat format = TextureFormat.DXT5)
        {
            RenderTexture.active = rt;
            Texture2D texture2D = new Texture2D(rt.width, rt.height, format, false);
            texture2D.ReadPixels(new Rect(0f, 0f, (float)rt.width, (float)rt.height), 0, 0, false);
            texture2D.Apply();
            RenderTexture.active = null;
            return texture2D;
        }

        public static Sprite Texture2Sprite(Texture2D tex)
        {
            return Sprite.Create(tex, new Rect(0f, 0f, (float)tex.width, (float)tex.height), new Vector2(0.5f, 0.5f), 100f, 0u, SpriteMeshType.Tight);
        }
    }