# Solasta Custom Monsters

This Mod allows you to customize any vendor stock in Solasta: Crown of the Magister

# How to Compile

1. Install Visual Studio 2019
2. Edit SolastaCustomMonsters.csproj and fix your game folder on line 5
3. Use "InstallDebug" to have it installed directly to your Mods folder

# How to Install

1. Download and instal [Unity Mod Manager](https://www.nexusmods.com/site/mods/21)
2. Add below *GameInfo* XML tag, under *Config* tag, to $UNITY_MOD_MANAGER_HOME\UnityModManagerConfig.xml:
```
	<GameInfo Name="Solasta">
		<Folder>Solasta</Folder>
		<ModsDirectory>Mods</ModsDirectory>
		<ModInfo>Info.json</ModInfo>
		<GameExe>Solasta.exe</GameExe>
		<EntryPoint>[UnityEngine.UIModule.dll]UnityEngine.Canvas.cctor:Before</EntryPoint>
		<StartingPoint>[Assembly-CSharp.dll]RuntimeManager.LoadRuntime:After</StartingPoint>
		<MinimalManagerVersion>0.22.13</MinimalManagerVersion>
	</GameInfo>
```
3. Execute Unity Mod Manager, Select Solasta, and Install
4. Select Mods tab, drag and drop from releases

# How to Debug

1. Open Solasta game folder
	* Rename Solasta.exe to Solasta.exe.original
	* Rename UnityPlayer.dll to UnityPlayer.dll.original
	* Add below entries to *Solasta_Data\boot.config*:
```
wait-for-managed-debugger=1
player-connection-debug=1
```
2. Download and install [7zip](https://www.7-zip.org/a/7z1900-x64.exe)
3. Download [Unity Editor 2019.4.1](https://unity3d.com/get-unity/download/archive)
4. Open Downloads folder
	* Right-click UnitySetup64-2019.4.1f1.exe, 7Zip -> Extract Here
	* Navigate to Editor\Data\PlaybackEngines\windowsstandalonesupport\Variations\win64_development_mono
	* Copy *WindowsPlayer.exe* (and rename to *Solasta.exe*), *UnityPlayer.dll* and *WinPixEventRuntime.dll* to Solasta game folder

You can now attach the Unity Debugger from Visual Studio 2019, Debug -> Attach Unity Debug

# How to Customize

1. Open $SOLASTA_HOME/Mods/SolastaCustomMonsters/Monsters.json on a text editor
2. Add new vendors to the list
3. Add new items under vendors
4. (Optionally), set stock properties on items (i.e: faction, max amount, initial amount)

You can lookup all existing monsters and items names at https://github.com/spacehamster/SolastaDataminer/releases/tag/0.3.3

# Credits

* @Spacehamster for all coding/hacking support (my other car is a cdr. answer is certainly 42!).
* @susphiciousone for original idea.
