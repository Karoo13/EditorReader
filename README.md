# EditorReader
reads data from the osu! editor for use in mapping tools.

## how to use
```
namespace Editor_Reader
compile as -platform:x86

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
SetProcess(n = 0) matches the nth process named "osu!..." with module "osu!.exe". will throw an error if not in osu.
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

FetchBookmarks() reads bookmarks for the current HOM into int array.
SnapPosition() float coordinates of snap position for the current composer.
EditorTime() gets the timeline position for the current editor.

FetchAll() FetchHOM, FetchBeatmap, FetchControlPoints, FetchObjects, FetchBookmarks.
```
