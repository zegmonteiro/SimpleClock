# SimpleClock
This is a full-screen desktop clock with basic functions.

Bellow is the list of keys and its functionallities:


|Key|Function|
|:---:|---|
|ESC |Exits the program|
|+ |Increases the font size|
|- |Decreases the font size|
|0 (zero)|Resets the font size|
|1-9|Changes the color pattern|


You can configure the color patterns and default font-size in the `SimpleClock.exe.config` file, as shown bellow:

```
  <appSettings>
    <add key="FontSize" value="350"/>
    <add key="FontColor1" value="255,255,255"/>
    <add key="BackgroundColor1" value="0,0,0"/>
    <add key="FontColor2" value="0,255,0"/>
    <add key="BackgroundColor2" value="0,0,0"/>
    <add key="FontColor3" value="255,255,0"/> 
    <add key="BackgroundColor3" value="0,0,0"/>
    <add key="FontColor4" value="255,0,0"/>
    <add key="BackgroundColor4" value="0,0,0"/>
  </appSettings>
```

Each color pattern is formed by two keys: `FontColorN` and `BackgroundColorN`, where `N`is the number of the pattern. You can add up to 9 differents patterns. The color is defined with the RGB values separeted in commas.


Example images:

[![Image 1](https://github.com/zegmonteiro/SimpleClock/raw/master/SimpleClock/img/01.png)](#features)

[![Image 1](https://github.com/zegmonteiro/SimpleClock/raw/master/SimpleClock/img/02.png)](#features)

[![Image 1](https://github.com/zegmonteiro/SimpleClock/raw/master/SimpleClock/img/03.png)](#features)

[![Image 1](https://github.com/zegmonteiro/SimpleClock/raw/master/SimpleClock/img/04.png)](#features)
