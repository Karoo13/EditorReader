# EditorReader
reads data from the osu! editor for use in mapping tools.

## how to use
```
namespace Editor_Reader

FetchHOM() for the current process, will find the editor and get the editor's hit object manager and composer.
  EditorTime() for the current editor, gets the timeline position.
  FetchObjects() for the current HOM, will get all hit objects.
  FetchBeatmap() for the current HOM, will get the beatmap properties.
    FetchControlPoints() for the current beatmap, will get all control (timing) points.
  FetchBookmarks() for the current HOM, will get the bookmarks.

FetchAll() will do the above fetch operations. since some fetch operations
  depend on others being up to date, it is safer but slower to fetch all.
  does not fetch clipboard, selected, or hovered.

if it is unclear how to use the reader, there is an example script included for your reference.
```
## public classes:
```
EditorReader
  autoDeStack defaults to true, when reading an object, destack it.
  autoRound defaults to false, when reading an object, round it.
  objectRadius
  stackOffset
  ContainingFolder
  Filename
  HPDrainRate
  CircleSize
  OverallDifficulty
  ApproachRate
  SliderMultiplier
  SliderTickRate
  PreviewTime
  StackLeniency
  TimelineZoom
  controlPoints
  numControlPoints
  hitObjects
  numObjects
  clipboardObjects
  numClipboard
  selectedObjects
  numSelected
  hoveredObject
  bookmarks
  numBookmarks

ControlPoint
  BeatLength
  Offset
  CustomSamples
  SampleSet
  TimeSignature
  Volume
  EffectFlags
  TimingChange
  ToString()

HitObject
  DeStack(stackOffset) move the object to its pre-stacking position.
  Round() round all coordinates to nearest integer.
  X
  Y
  StartTime
  EndTime
  Type
  SoundType
  SpatialLength
  SegmentCount
  StackCount
  SampleFile
  SampleVolume
  SampleSet
  SampleSetAdditions
  CustomSampleSet
  IsSelected
  unifiedSoundAddition
  IsCircle()
  IsSlider()
    CurveType
    X2
    Y2
    sliderCurvePoints
    SoundTypeList
    SampleSetList
    SampleSetAdditionsList
  IsNewCombo()
  IsSpinner()
  IsHoldNote()
  ToString()
```
## available methods:
```
SetProcess(n = 0) matches the nth process "osu!..." with module "osu!.exe". will throw an error if not in osu.
ProcessNeedsReload() checks if the current process does not exist.

SetEditor() detects the active editor within the current process. will throw an error if not in editor.
FetchEditor() sets process if needed, and then sets editor.
EditorNeedsReload() checks if the current editor is closed or does not exist.

SetHOM() finds the hit object manager and composer for the current editor.
ReadHOM() reads objectRadius, stackOffset, and objects lists for the current HOM and composer.
FetchHOM() fetches editor if needed, and then sets and reads HOM.

SetBeatmap() finds the beatmap for the current HOM.
ReadBeatmap() reads difficulty settings and filename for the current beatmap.
FetchBeatmap() finds then reads, as above.

SetControlPoints() finds all control points for the current beatmap.
ReadControlPoints() reads all found control points.
FetchControlPoints() finds then reads, as above.

SetObjects() finds all objects for the current HOM.
ReadObjects() reads all found objects.
FetchObjects() finds then reads, as above.

SetClipboard() finds all clipboard objects for the current composer.
ReadClipboard() reads all found objects.
FetchClipboard() finds then reads, as above.

SetSelected() finds all selected objects for the current composer.
ReadSelected() reads all found objects.
FetchSelected() finds then reads, as above.

SetHovered() finds the hovered object for the current composer.
ReadHovered() reads the object, returns whether an object is hovered.
FetchHovered() finds then reads, as above. returns whether an object is hovered.

SetSliderPlacement() finds the slider being placed for the current composer.
ReadSliderPlacement() reads the slider, returns whether a slider is being placed.
FetchSliderPlacement() finds then reads, as above. returns whether a slider is being placed.

FetchBookmarks() reads bookmarks for the current HOM into int array.
ComposeTool() tool (select, normal, slider, spinner, hold) for the current composer.
GridSize() the grid size for the current composer.
DistanceSpacing() the distance snap value for the current composer.
SnapPosition() float tuple of snap position for the current composer.
BeatDivisor() the beat snap divisor for the current editor.
EditorTime() the timeline position for the current editor.

FetchAll() FetchHOM, FetchBeatmap, FetchControlPoints, FetchObjects, FetchBookmarks.
```
## notes:
```
the Set and Read methods are not very useful, use fetch for everything unless you want to micro-optimize.
SetProcess has a match nth parameter in case you are running multiple osu instances and need to choose.
FetchAll is designed to collect all the (non-storyboard) volatile information for reconstructing the map.
information like metadata is not collected since it will always be the same as in the file.
the hovered object is the slider with its anchors visible or an object you are about to stack on.
slider X2 and Y2 are the coordinates of the other end. it may not be correct after you round the object.
inconsistent capitalization and naming is based on the corresponding variable names in osu.
```
