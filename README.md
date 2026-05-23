# InfiniteSouls - Revolution Idle MelonLoader Mod

A MelonLoader mod for Revolution Idle that adds souls using the game's built-in debug function.

## How it works

The mod calls the game's internal `DisplayDebug.AddSouls()` method which adds 1,000,000 souls per call. By calling it 500 times on load, you get 500 million souls. It only runs once and writes a flag file to prevent it running again on future launches.

## Requirements

- Revolution Idle (Steam)
- MelonLoader v0.7.2 or later
- .NET 6.0 SDK

## Installation

### Building from source

1. Clone the repo
2. Open a terminal in the project folder
3. Run:
```
dotnet build -c Release
```
4. Copy the output DLL to your Mods folder:
```
Copy-Item "bin\Release\net6.0\InfiniteSouls.dll" "C:\Program Files (x86)\Steam\steamapps\common\Revolution Idle\Mods\" -Force
```

### Using the pre-built DLL

1. Download `InfiniteSouls.dll` from Releases
2. Place it in `C:\Program Files (x86)\Steam\steamapps\common\Revolution Idle\Mods\`

## Usage

1. Launch Revolution Idle
2. Wait for the main scene to load
3. The mod will run automatically after 10 seconds
4. The GUI will refresh rapidly for a few seconds — this is normal
5. Once done, 500 million souls will be added to your account
6. Restart the game — everything will be back to normal

## Running again

To run the mod again, delete the flag file:
```
Remove-Item "C:\Users\<YourUsername>\InfiniteSouls\done.txt"
```

## Customising the soul amount

Open `InfiniteSouls.cs` and change the number of calls (default 500):
```csharp
for (int i = 0; i < 500; i++) // Change 500 to however many million souls you want
```

## Notes

- Each `AddSouls()` call adds exactly 1,000,000 souls
- The int32 limit is 2,147,483,647 so don't go above 2000 calls
- The GUI will refresh during the loop but returns to normal after
- Souls are saved to the server automatically

## Credits

Made by WzoUK
