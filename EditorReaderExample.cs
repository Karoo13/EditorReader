using System;
using EditorReaderNamespace;

public class EditorReaderExample
{
    public static void Main()
    {
        EditorReader reader = new EditorReader();
        reader.SetProcess("osu!", 0);
        reader.SetEditor();
        reader.ReadAll();

        Console.WriteLine(reader.ContainingFolder);
        Console.WriteLine(reader.Filename);
        Console.WriteLine("HP" + reader.HPDrainRate);
        Console.WriteLine("CS" + reader.CircleSize);
        Console.WriteLine("AR" + reader.ApproachRate);
        Console.WriteLine("OD" + reader.OverallDifficulty);
        Console.WriteLine("SV" + reader.SliderMultiplier);
        Console.WriteLine("TR" + reader.SliderTickRate);

        Console.WriteLine("Current Time:");
        Console.WriteLine(reader.EditorTime());

        Console.WriteLine("Timing Points:");
        for (int i = 0; i < reader.numControlPoints; i++)
            Console.WriteLine(reader.controlPoints[i].ToString());

        Console.WriteLine("Selected Hit Objects:");
        for (int i = 0; i < reader.numObjects; i++)
            if (reader.hitObjects[i].IsSelected)
            {
                reader.hitObjects[i].DeStack(reader.stackOffset);
                Console.WriteLine(reader.hitObjects[i].ToString());
            }
    }
}