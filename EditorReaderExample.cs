using System;
using Editor_Reader;

public class EditorReaderExample
{
    public static void Main()
    {
        EditorReader reader = new EditorReader();
        reader.FetchAll();
        
        Console.WriteLine(reader.ContainingFolder);
        Console.WriteLine(reader.Filename);
        Console.WriteLine("oR" + reader.objectRadius);
        Console.WriteLine("sO" + reader.stackOffset);
        Console.WriteLine("HP" + reader.HPDrainRate);
        Console.WriteLine("CS" + reader.CircleSize);
        Console.WriteLine("AR" + reader.ApproachRate);
        Console.WriteLine("OD" + reader.OverallDifficulty);
        Console.WriteLine("SV" + reader.SliderMultiplier);
        Console.WriteLine("TR" + reader.SliderTickRate);
        Console.WriteLine("CT" + reader.ComposeTool());
        Console.WriteLine("GS" + reader.GridSize());
        Console.WriteLine("BD" + reader.BeatDivisor());
        Console.WriteLine("TZ" + reader.TimelineZoom);
        Console.WriteLine("DS" + reader.DistanceSpacing());
        
        Console.WriteLine("Current Time:");
        Console.WriteLine(reader.EditorTime());
        
        Console.WriteLine("Timing Points:");
        for (int i = 0; i < reader.numControlPoints; i++)
            Console.WriteLine(reader.controlPoints[i].ToString());
        
        Console.WriteLine("Bookmarks:");
        for (int i = 0; i < reader.numBookmarks; i++)
            Console.WriteLine(reader.bookmarks[i]);
        
        Console.WriteLine("Hit Objects (selected):");
        for (int i = 0; i < reader.numObjects; i++)
            if (reader.hitObjects[i].IsSelected)
                Console.WriteLine(reader.hitObjects[i].ToString());
        
        while(true){
            Console.WriteLine(reader.SnapPosition());
            
            reader.FetchSelected();
            Console.WriteLine("Selected Hit Objects:");
            for (int i = 0; i < reader.numSelected; i++)
                Console.WriteLine(reader.selectedObjects[i].ToString());
            
            reader.FetchClipboard();
            Console.WriteLine("Copied Hit Objects:");
            for (int i = 0; i < reader.numClipboard; i++)
                Console.WriteLine(reader.clipboardObjects[i].ToString());
            
            Console.WriteLine("Hovered Hit Object:");
            if (reader.FetchHovered())
                Console.WriteLine(reader.hoveredObject.ToString());
            
            Console.ReadLine();
        }
    }
}