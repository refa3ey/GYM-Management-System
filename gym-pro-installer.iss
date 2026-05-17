; ============================================================
;  GYM PRO  —  Inno Setup 6 Installer Script
;  Output : Output\GYMPRO-Setup-v1.0.exe
;  Run    : Open this file in Inno Setup Compiler, press F9
; ============================================================

#define AppName      "GYM PRO"
#define AppVersion   "1.0.0"
#define AppPublisher "GYM PRO"
#define AppExeName   "GYM-Desktop-app.exe"
#define SourceDir    "bin\Release"

; ── [Setup] ─────────────────────────────────────────────────
[Setup]
; Basic identity
AppName={#AppName}
AppVersion={#AppVersion}
AppVerName={#AppName} {#AppVersion}
AppPublisher={#AppPublisher}
AppCopyright=Copyright (C) 2026 GYM PRO

; Where the app installs by default
; {autopf} resolves to "C:\Program Files" on 64-bit Windows
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}

; Installer output
OutputDir=Output
OutputBaseFilename=GYMPRO-Setup-v1.0

; Installer icon (shown in wizard title bar and taskbar)
SetupIconFile=Resources\app.ico

; Compression — lzma2 gives the smallest file
Compression=lzma2/ultra
SolidCompression=yes

; Require the installer itself to run as Administrator
; (needed to write to Program Files and create shortcuts)
PrivilegesRequired=admin

; Minimum OS — Windows 7 SP1
MinVersion=6.1sp1

; Wizard appearance (Inno Setup 6 modern style)
WizardStyle=modern
WizardResizable=no

; Show license page using our LICENSE.txt
LicenseFile=LICENSE.txt

; Show INSTALL.txt on the "Information" page before installation
InfoBeforeFile=INSTALL.txt

; Uninstaller settings
UninstallDisplayName={#AppName}
UninstallDisplayIcon={app}\{#AppExeName}
CreateUninstallRegKey=yes

; Add to Add/Remove Programs
AppId={{52BEC77A-DF51-486D-A778-823CAFDB4CEE}

; ── [Languages] ─────────────────────────────────────────────
[Languages]
; Default language: English
Name: "english"; MessagesFile: "compiler:Default.isl"

; ── [Tasks] ─────────────────────────────────────────────────
; Optional tasks the user can tick during install
[Tasks]
; Desktop shortcut (checked by default)
Name: "desktopicon"; Description: "Create a &desktop shortcut"; GroupDescription: "Additional icons:"; Flags: checkedonce

; ── [Files] ─────────────────────────────────────────────────
; All files that will be copied to {app} (the install folder)
[Files]

; ---- Main executable ----
Source: "{#SourceDir}\{#AppExeName}";        DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\{#AppExeName}.config"; DestDir: "{app}"; Flags: ignoreversion

; ---- Database (template — LocalDB attaches this on first run) ----
; GymDB_log.ldf is intentionally excluded: LocalDB creates a new log
; automatically when it first attaches GymDB.mdf.
Source: "{#SourceDir}\GymDB.mdf"; DestDir: "{app}"; Flags: ignoreversion

; ---- Third-party DLLs ----
Source: "{#SourceDir}\BCrypt.Net-Next.dll";                    DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\EPPlus.dll";                             DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\Guna.UI2.dll";                           DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\PdfSharp.dll";                           DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\QRCoder.dll";                            DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Buffers.dll";                     DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Memory.dll";                      DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Numerics.Vectors.dll";            DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourceDir}\System.Runtime.CompilerServices.Unsafe.dll"; DestDir: "{app}"; Flags: ignoreversion

; ---- PdfSharp localization subfolder ----
Source: "{#SourceDir}\de\PdfSharp.resources.dll"; DestDir: "{app}\de"; Flags: ignoreversion

; ── [Icons] ─────────────────────────────────────────────────
; Shortcuts created during install
[Icons]
; Start Menu entry
Name: "{group}\{#AppName}";          Filename: "{app}\{#AppExeName}"; IconFilename: "{app}\{#AppExeName}"
Name: "{group}\Uninstall {#AppName}"; Filename: "{uninstallexe}"

; Desktop shortcut (only if user ticked the task above)
Name: "{autodesktop}\{#AppName}";    Filename: "{app}\{#AppExeName}"; IconFilename: "{app}\{#AppExeName}"; Tasks: desktopicon

; ── [Run] ────────────────────────────────────────────────────
; Actions after installation completes
[Run]
; Offer to launch the app immediately after install
Filename: "{app}\{#AppExeName}"; \
    Description: "Launch {#AppName} now"; \
    Flags: nowait postinstall skipifsilent

; ── [UninstallRun] ───────────────────────────────────────────
; Detach and stop LocalDB before files are removed so the
; MDF is not locked during uninstall
[UninstallRun]
Filename: "SqlLocalDB.exe"; Parameters: "stop MSSQLLocalDB"; \
    Flags: runhidden skipifdoesntexist waituntilterminated
Filename: "SqlLocalDB.exe"; Parameters: "delete MSSQLLocalDB"; \
    Flags: runhidden skipifdoesntexist waituntilterminated

; ── [Code] ───────────────────────────────────────────────────
; Pascal script: check .NET 4.8 and LocalDB before install begins
[Code]

// Check if .NET Framework 4.8 is installed
function IsDotNet48Installed(): Boolean;
var
  key: String;
  release: Cardinal;
begin
  key := 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full';
  Result := RegQueryDWordValue(HKLM, key, 'Release', release) and (release >= 528040);
end;

// Check if any version of SQL Server LocalDB is installed
function IsLocalDBInstalled(): Boolean;
var
  names: TArrayOfString;
begin
  Result := RegGetSubkeyNames(
    HKLM,
    'SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions',
    names
  ) and (GetArrayLength(names) > 0);
end;

// Called before the wizard starts — show warnings for missing prerequisites
function InitializeSetup(): Boolean;
var
  msg: String;
begin
  Result := True;
  msg    := '';

  if not IsDotNet48Installed() then
    msg := msg + '• Microsoft .NET Framework 4.8 is NOT installed.' + #13#10 +
           '  Download it free from: https://aka.ms/dotnet48' + #13#10#13#10;

  if not IsLocalDBInstalled() then
    msg := msg + '• SQL Server LocalDB is NOT installed.' + #13#10 +
           '  Download it free from: https://aka.ms/sqllocaldb' + #13#10 +
           '  (Or install SQL Server Express which includes LocalDB)' + #13#10#13#10;

  if msg <> '' then
  begin
    msg := 'The following prerequisites are missing:' + #13#10#13#10 + msg +
           'GYM PRO will not run correctly without them.' + #13#10 +
           'Install the prerequisites first, then re-run this installer.' + #13#10#13#10 +
           'Continue anyway?';

    Result := (MsgBox(msg, mbConfirmation, MB_YESNO) = IDYES);
  end;
end;
