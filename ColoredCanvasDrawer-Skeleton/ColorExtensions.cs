using System.Reflection;

namespace ColoredCanvasDrawer
{
    public static class ColorExtensions
    {
        public static string GetColorName(this Color color)
        {
            IEnumerable<PropertyInfo> colorProperties = typeof(Color)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(Color));

            foreach (PropertyInfo colorProperty in colorProperties)
            {
                Color colorPropertyValue = (Color)colorProperty.GetValue(null, null)!;
                if (colorPropertyValue.R == color.R
                    && colorPropertyValue.G == color.G
                    && colorPropertyValue.B == color.B)
                {
                    return colorPropertyValue.Name;
                }
            }

            return ColorTranslator.ToHtml(color);
        }
    }
}
