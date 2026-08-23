; ============================================================
;  GYM PRO  -  Inno Setup 6 Installer
;  Output : Output\GYMPRO-Setup-v1.0.exe
;  Embedded SQLite - NO SQL Server / LocalDB required.
; ============================================================

#define AppName      "GYM PRO"
#define AppVersion   "1.0.0"
#define AppPublisher "GYM PRO"
#define AppExeName   "GYM-Desktop-app.exe"
#define SourceDir    "bin\Release"

[Setup]
AppName={#AppName}
AppVersion={#AppVersion}
AppVerName={#AppName} {#AppVersion}
AppPublisher={#AppPublisher}
AppCopyright=Copyright (C) 2026 GYM PRO
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
OutputDir=Output
OutputBaseFilename=GYMPRO-Setup-v1.0
SetupIconFile=Resources\app.ico
Compression=lzma2/ultra
SolidCompression=yes
; App stores its database in %LOCALAPPDATA% (per-user) - admin NOT required.
PrivilegesRequired=lowest
MinVersion=6.1sp1
WizardStyle=modern
UninstallDisplayName={#AppName}
UninstallDisplayIcon={app}\{#AppExeName}
AppId={{52BEC77A-DF51-486D-A778-823CAFDB4CEE}

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop shortcut"; GroupDescription: "Additional icons:"; Flags: checkedonce

[Files]
Source: "{#SourceDir}\{#AppExeName}";        DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\{#AppExeName}.config"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

; ---- Embedded SQLite engine (managed + native, both architectures) ----
Source: "{#SourceDir}\System.Data.SQLite.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\x86\SQLite.Interop.dll"; DestDir: "{app}\x86"; Flags: ignoreversion
Source: "{#SourceDir}\x64\SQLite.Interop.dll"; DestDir: "{app}\x64"; Flags: ignoreversion

; ---- Third-party DLLs ----
Source: "{#SourceDir}\BCrypt.Net-Next.dll";                        DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\EPPlus.dll";                                 DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\Guna.UI2.dll";                               DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\PdfSharp.dll";                               DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\QRCoder.dll";                                DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Buffers.dll";                         DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Memory.dll";                          DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Numerics.Vectors.dll";               DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Runtime.CompilerServices.Unsafe.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\de\PdfSharp.resources.dll";                  DestDir: "{app}\de"; Flags: ignoreversion skipifsourcedoesntexist

[Icons]
Name: "{group}\{#AppName}";           Filename: "{app}\{#AppExeName}"; IconFilename: "{app}\{#AppExeName}"
Name: "{group}\Uninstall {#AppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#AppName}";     Filename: "{app}\{#AppExeName}"; IconFilename: "{app}\{#AppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#AppExeName}"; Description: "Launch {#AppName} now"; Flags: nowait postinstall skipifsilent

[Code]
// Only prerequisite is .NET Framework 4.8 (built into Windows 10 1903+ / Windows 11).
function IsDotNet48Installed(): Boolean;
var
  release: Cardinal;
begin
  Result := RegQueryDWordValue(HKLM,
    'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', release)
    and (release >= 528040);
end;

function InitializeSetup(): Boolean;
begin
  Result := True;
  if not IsDotNet48Installed() then
    Result := (MsgBox(
      'Microsoft .NET Framework 4.8 does not appear to be installed.' + #13#10 +
      '(It is built into Windows 10 and 11.)' + #13#10#13#10 +
      'Download it free from: https://aka.ms/dotnet48' + #13#10#13#10 +
      'Continue anyway?', mbConfirmation, MB_YESNO) = IDYES);
end;
