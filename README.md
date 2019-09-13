# SM64 Fast3D Anti-Aliasing Reducer
 
This simple tool will overwrite the Fast3D 2.0D microcode within a SM64 ROM, and replace it with a slightly modified version that disables full anti-aliasing. It does this by blocking any attempt to write the `IM_RD` render mode flag into the RDP's othermode variable. This should improve performance on real N64 hardware by 3-4 fps (~10%).

![alt-text](https://i.imgur.com/5IiWuQr.png)

## How do I use the tool?

Just simply open up a Super Mario 64 ROM file, and then you can click the "Reduce the AA!" button if the ROM is compatible.

## What SM64 ROMs are supported?

Any SM64 ROM that uses the Fast3D 2.0D microcode is compatible. This includes the Japanese and North American versions of SM64 and any ROM hacks made with those versions.

## Benchmark

The beginning area of Jolly Roger Bay does lag a significant amount. Going down to a 22 fps minimum in my testing. Injecting the modified microcode makes a significant difference in the feel of the game, with the minimum increased to 25 fps.

My jolly roger bay benchmark starts at the beginning of the level and has Mario swim into the underwater cave. The framerate is bad in the beginning, but gets a lot better when you are deep underwater.

![alt-text](https://i.imgur.com/C0IV7yY.jpg)
