#define NoteAppURL "https://github.com/Tyomios/NoteApp"
#define NoteAppExeName "NoteApp.exe"
#define NoteApp "NoteApp"
#define NoteAppVersion "1.0"

[Setup]
AppId = {{3D4BC5BD-F416-46CA-A74E-5307DC31C9F9}}
AppName = {#NoteApp}
AppVersion = {#NoteAppVersion}
AppPublisher = {#NoteAppURL}
AppSupportURL = {#NoteAppURL}
AppUpdatesURL = {#NoteAppURl}
DefaultDirName = {pf}\{#NoteApp}
DisableProgramGroupPage = yes
OutputBaseFilename = NoteAppSetup
Compression = lzma
SolidCompression = yes
SetupIconFile = "NoteAppLogo.ico"
OutputDir = "InstallScripts"


[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "description"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "..\bin\net5.0-windows\Release\NoteApp.dll; DestDir: "{app}"
Source: "..\bin\net5.0-windows\Release\Newtonsoft.Json.dll; DestDir: "{app}"
Source: "..\bin\net5.0-windows\Release\NoteApp.UI.exe; DestDir: "{app}"