;FLAVOR:Marlin
;TIME:6723.69
;Filament used:10.7991m
;Layer height:0.2

M140 S60
M105
M190 S60
M104 S190
M82 ;absolute extrusion mode
M220 S100 ;Reset Feedrate
M221 S100 ;Reset Flowrate

G28 ;Home

G92 E0 ;Reset Extruder
G1 Z2.0 F3000 ;Move Z Axis up
G1 X-2.1 Y20 Z0.28 F5000.0 ;Move to start position
M109 S190.000000
G1 X-2.1 Y145.0 Z0.28 F1500.0 E15 ;Draw the first line
G1 X-2.4 Y145.0 Z0.28 F5000.0 ;Move to side a little
G1 X-2.4 Y20 Z0.28 F1500.0 E30 ;Draw the second line
G92 E0  ;Reset Extruder
G1 E-1.0000 F1800 ;Retract a bit
G1 Z2.0 F3000 ;Move Z Axis up
G1 E0.0000 F1800 

G1 X142.548 Y111.957 E3.56379
G1 X142.548 Y141.523 E4.67687
G1 X77.452 Y141.523 E7.12755
G1 X77.452 Y82.39 E9.35373
G0 F4800 X77.652 Y82.39
G0 X77.931 Y82.869
