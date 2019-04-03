# EditorReader
reads data from the osu! editor for use in mapping tools.

## how to use
```
namespace Editor_Reader
compile as -platform:x86

SetProcess("osu!", 0) matches the 0th process named "osu!...".

FetchHOM() for the current process, will find the editor and get the editor's hit object manager and composer.
  EditorTime() for the current editor, gets the timeline position.
  FetchObjects() for the current HOM, will get all hit objects.
  FetchClipboard() for the current composer, gets clipboard objects.
  FetchSelected() for the current composer, gets selected objects.
  FetchBeatmap() for the current HOM, will get the beatmap properties.
    FetchControlPoints() for the current beatmap, will get all control (timing) points.

FetchAll() will do the above fetch operations. since some fetch operations
  depend on others being up to date, it is safer but slower to fetch all.
  does not fetch clipboard or selected.

if it is unclear how to use the reader, there is an example script included for your reference.
```
## public classes:
```
EditorReader
  autoDeStack defaults to true, when reading an object, destack it.
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
  DeStack(stackOffset) move the object to its pre-stacking position, do this before saving to file.
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
SetProcess("osu!", 0) matches the 0th process named "osu!...". will throw an error if not in osu.

SetEditor() detects the active editor within the selected process. will throw an error if not in editor.
EditorExists() checks if the current editor is still loaded in memory.
EditorClosed() checks if the current editor (assuming it exists) has been closed.
EditorNeedsReload() checks if the current editor is closed or does not exist.

SetHOM() finds the hit object manager and composer for the current editor.
ReadHOM() reads objectRadius, stackOffset, and objects lists for the current HOM and composer.
FetchHOM() sets editor if needed, and then sets and reads HOM.

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

ReadHovered() reads the hovered object for the current composer, returns whether an object is hovered.
SnapPosition() float coordinates of snap position for the current composer.
EditorTime() gets the timeline position for the current editor.

FetchAll() FetchHOM, FetchBeatmap, FetchControlPoints, FetchObjects.
```
