# EditorReader
reads data from the osu! editor for use in mapping tools.

> available methods:

SetProcess("osu!", 0) matches the 0th process named "osu!...".
SetEditor() detects the active editor within the selected process. will throw an error if not editing standard.

SetHOM() finds the hit object manager for the current editor.
ReadHOM() reads objectRadius, stackOffset, current beatmap, and objects list for the current HOM.
ReadBeatmap() reads difficulty settings and filename for the current beatmap.

SetControlPoints() finds all control points for the current beatmap.
ReadControlPoints() reads all found control points.
ReReadControlPoints() finds then reads, as above.

SetObjects() finds all objects for the current HOM.
ReadObjects() reads all found objects.
ReReadObjects() finds then reads, as above.

ReadAll() SetHom, ReadHOM, ReadBeatmap, SetControlPoints, ReadControlPoints, SetObjects, ReadObjects.

EditorTime() gets the timeline position for the current editor.

> public classes:

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
  KiaiMode
  TimingChange
  ToString()

HitObject
  DeStack(stackOffset) move the object to its pre-stacking position, do this before saving to file.
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
  ToString()
