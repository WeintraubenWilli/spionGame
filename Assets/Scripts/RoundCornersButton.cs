using UnityEngine;
using UnityEngine.UI;

public class RoundCornersButton : MonoBehaviour
{
    void Start()
    {
        // Rufe die Methode auf, um die Ecken abzurunden
        RoundCorners(GetComponent<Button>());
    }

    void RoundCorners(Button button)
    {
        // Stelle die Radien der abgerundeten Ecken ein
        float cornerRadius = 10f;

        // Erstelle eine neue Grafik mit abgerundeten Ecken
        Sprite roundedSprite = CreateRoundedSprite(button.image.sprite, cornerRadius);

        // Weise die neue Grafik dem Button zu
        button.image.sprite = roundedSprite;
    }

    Sprite CreateRoundedSprite(Sprite sourceSprite, float cornerRadius)
    {
        // Kopiere die Einstellungen der Quell-Grafik
        Texture2D texture = sourceSprite.texture;
        Rect rect = sourceSprite.rect;
        Vector2 pivot = sourceSprite.pivot;
        float pixelsPerUnit = sourceSprite.pixelsPerUnit;

        // Erstelle eine Textur für die abgerundeten Ecken
        Texture2D roundedTexture = new Texture2D(texture.width, texture.height);
        roundedTexture.filterMode = FilterMode.Bilinear;

        // Gehe durch alle Pixel und runde die Ecken ab
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                Color pixelColor = texture.GetPixel(x, y);
                Color roundedColor = RoundCorners(pixelColor, x, y, cornerRadius, rect.width, rect.height, pivot, pixelsPerUnit);
                roundedTexture.SetPixel(x, y, roundedColor);
            }
        }

        // Wende die Änderungen an und erstelle einen neuen Sprite
        roundedTexture.Apply();
        return Sprite.Create(roundedTexture, rect, pivot, pixelsPerUnit);
    }

    Color RoundCorners(Color originalColor, int x, int y, float cornerRadius, float width, float height, Vector2 pivot, float pixelsPerUnit)
    {
        // Berechne die Position relativ zum Pivot
        float offsetX = (x / pixelsPerUnit - pivot.x) / width;
        float offsetY = (y / pixelsPerUnit - pivot.y) / height;

        // Berechne die Entfernung zum Pivot
        float distanceToPivot = Mathf.Sqrt(offsetX * offsetX + offsetY * offsetY);

        // Runde die Ecken ab, wenn die Entfernung zum Pivot größer als der Radius ist
        if (distanceToPivot > cornerRadius / pixelsPerUnit)
        {
            return Color.clear; // Transparente Farbe für abgerundete Ecken
        }
        else
        {
            return originalColor;
        }
    }
}
