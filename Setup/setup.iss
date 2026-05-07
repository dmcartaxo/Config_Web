; ============================================================================
; Config Web  -  Inno Setup 6  -  Gera: Output\Config_Web_Setup_v1.0.0.exe
; ============================================================================

#define AppName        "Config Web"
#define AppVersion     "1.0.0"
#define AppPublisher   "dmcartaxo"
#define AppURL         "https://github.com/dmcartaxo/Config_Web"
#define AppExeName     "Config_Web.exe"
#define AppId          "{{A1B2C3D4-E5F6-7890-ABCD-EF1234567890}"
#define SrcBin         "..\Config_Web\bin\Release"
#define OutputDir      "..\Output"

[Setup]
AppId={#AppId}
AppName={#AppName}
AppVersion={#AppVersion}
AppVerName={#AppName} {#AppVersion}
AppPublisher={#AppPublisher}
AppPublisherURL={#AppURL}
AppSupportURL={#AppURL}/issues
AppUpdatesURL={#AppURL}/releases
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
DisableProgramGroupPage=yes
LicenseFile=..\LICENSE.txt
OutputDir={#OutputDir}
OutputBaseFilename=Config_Web_Setup_v{#AppVersion}
SetupIconFile=..\Config_Web\app.ico
Compression=lzma2/ultra64
SolidCompression=yes
LZMAUseSeparateProcess=yes
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=admin
PrivilegesRequiredOverridesAllowed=
SetupMutex=Config_Web_SetupMutex
WizardStyle=modern
ShowLanguageDialog=auto
VersionInfoVersion={#AppVersion}
VersionInfoCompany={#AppPublisher}
VersionInfoDescription={#AppName} Setup
VersionInfoProductName={#AppName}
VersionInfoProductVersion={#AppVersion}

[Languages]
Name: "portuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
Name: "english";    MessagesFile: "compiler:Default.isl"

[CustomMessages]
portuguese.NetFrameworkMissing=O .NET Framework 4.8 nao foi encontrado.%n%nDeseja abrir a pagina de download da Microsoft?
english.NetFrameworkMissing=.NET Framework 4.8 was not found.%n%nDo you want to open the Microsoft download page?

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#SrcBin}\Config_Web.exe";        DestDir: "{app}"; Flags: ignoreversion
Source: "{#SrcBin}\Config_Web.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\create_icon.ps1";              DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#AppName}";             Filename: "{app}\{#AppExeName}"; Comment: "Configurador de Web.Config para servicos IIS"
Name: "{group}\Desinstalar {#AppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#AppName}";       Filename: "{app}\{#AppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#AppExeName}"; Description: "Iniciar {#AppName} agora"; Flags: nowait postinstall skipifsilent runascurrentuser

[Registry]
Root: HKLM; Subkey: "SOFTWARE\{#AppPublisher}\{#AppName}"; ValueType: string; ValueName: "Version"; ValueData: "{#AppVersion}"; Flags: uninsdeletekey

[UninstallDelete]
Type: dirifempty; Name: "{app}"

[Code]
const
  NET48_RELEASE = 528040;

function IsNet48Installed(): Boolean;
var
  release: Cardinal;
  found: Boolean;
begin
  found := RegQueryDWordValue(HKEY_LOCAL_MACHINE,
    'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', release);
  Result := found and (release >= NET48_RELEASE);
end;

function InitializeSetup(): Boolean;
var
  errCode: Integer;
begin
  Result := True;
  if not IsNet48Installed() then
  begin
    if MsgBox(CustomMessage('NetFrameworkMissing'), mbError, MB_YESNO) = IDYES then
    begin
      ShellExec('open', 'https://dotnet.microsoft.com/download/dotnet-framework/net48', '', '', SW_SHOWNORMAL, ewNoWait, errCode);
    end;
    Result := False;
  end;
end;
