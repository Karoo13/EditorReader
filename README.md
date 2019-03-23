# EditorReader
reads data from the osu! editor for use in mapping tools.

## how to use
```
namespace Editor_Reader
compile as -platform:x86

SetProcess("osu!", 0) matches the 0th process named "osu!...".

FetchHOM() for the current process, will find the editor and get and read the editor's hit object manager.
  EditorTime() for the current editor, gets the timeline position.
  FetchObjects() for the current HOM, will get all hit objects.
  FetchBeatmap() for the current HOM, will get the beatmap properties.
    FetchControlPoints() for the current beatmap, will get all control (timing) points.

FetchAll() will do the above fetch operations. since some fetch operations
  depend on others being up to date, it is safer but slower to fetch all.

if it is unclear how to use the reader, there is an example script included for your reference.
```
## public classes:
```
EditorReader
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

SetHOM() finds the hit object manager for the current editor.
ReadHOM() reads objectRadius, stackOffset, and objects list for the current HOM.
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

FetchAll() FetchHOM, FetchBeatmap, FetchControlPoints, FetchObjects.

EditorTime() gets the timeline position for the current editor.
```
