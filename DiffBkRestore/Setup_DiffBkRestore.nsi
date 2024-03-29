; example1.nsi
;
; This script is perhaps one of the simplest NSIs you can make. All of the
; optional settings are left to their default settings. The installer simply 
; prompts the user asking them where to install, and drops a copy of example1.nsi
; there. 

;--------------------------------

Unicode true

SetCompressor /SOLID lzma

!define APP "DiffBkRestore"

!system 'DefineAsmVer.exe "bin\Release\${APP}.exe" "!define VER ""[FVER]"" " > Appver.tmp'
!include "Appver.tmp"
!searchreplace APV ${VER} "." "_"

!define EXT1 ".DiffBkSet"

!system 'MySign "bin\Release\${APP}.exe" "x86\VFCopy.dll" "x64\VFCopy.dll"'
!finalize 'MySign "%1"'

; The name of the installer
Name "${APP} ${VER}"

; The file to write
OutFile "Setup_${APP}_${APV}.exe"

; The default installation directory
InstallDir "$PROGRAMFILES\${APP}"

; Registry key to check for directory (so if you install again, it will
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\${APP}" "Install_Dir"

; Request application privileges for Windows Vista
RequestExecutionLevel admin

XPStyle on

!include LogicLib.nsh
!include x64.nsh

;--------------------------------

; Pages

Page license
Page directory
Page components
Page instfiles

LicenseData CHANGES.rtf

;--------------------------------

!ifdef SHCNE_ASSOCCHANGED
!undef SHCNE_ASSOCCHANGED
!endif
!define SHCNE_ASSOCCHANGED 0x08000000

!ifdef SHCNF_FLUSH
!undef SHCNF_FLUSH
!endif
!define SHCNF_FLUSH        0x1000

!ifdef SHCNF_IDLIST
!undef SHCNF_IDLIST
!endif
!define SHCNF_IDLIST       0x0000

!macro UPDATEFILEASSOC
  IntOp $1 ${SHCNE_ASSOCCHANGED} | 0
  IntOp $0 ${SHCNF_IDLIST} | ${SHCNF_FLUSH}
; Using the system.dll plugin to call the SHChangeNotify Win32 API function so we
; can update the shell.
  System::Call "shell32::SHChangeNotify(i,i,i,i) (${SHCNE_ASSOCCHANGED}, $0, 0, 0)"
!macroend

;--------------------------------

; The stuff to install
Section "" ;No components page, name is not important

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR

  ; Put file there
  File /r /x "*.vshost.*" "bin\Release\*"
  
  ExecWait 'regsvr32.exe /s "$INSTDIR\x86\VFCopy.dll"' $0
  DetailPrint "結果: $0"

  ${If} ${RunningX64}
    ExecWait 'regsvr32.exe /s "$INSTDIR\x64\VFCopy.dll"' $0
    DetailPrint "結果: $0"
  ${EndIf}

  ; Write the installation path into the registry
  WriteRegStr HKLM "SOFTWARE\${APP}" "Install_Dir" "$INSTDIR"

  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP}" "DisplayName" "${APP}"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP}" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP}" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP}" "NoRepair" 1
  WriteUninstaller "uninstall.exe"

SectionEnd ; end the section

Section "関連付け"
  WriteRegStr HKCR "${EXT1}" "" "${APP}"

  WriteRegStr HKCR "${APP}" "" "DiffBk バックアップ セット"
  WriteRegStr HKCR "${APP}\DefaultIcon" "" '$INSTDIR\${APP}.exe'
  WriteRegStr HKCR "${APP}\shell\Open\command" "" '"$INSTDIR\${APP}.exe" "%1"'

  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\${EXT1}\OpenWithProgids" "${APP}" ""

  DetailPrint "関連付け更新中..."
  !insertmacro UPDATEFILEASSOC
SectionEnd

Section ""
  SetOutPath $INSTDIR
  Exec "$INSTDIR\${APP}.exe"
SectionEnd

Section ""
  IfErrors +2
    SetAutoClose true
SectionEnd

;--------------------------------

; Uninstaller

Section "Uninstall"
  ; Remove files and uninstaller
  ExecWait 'regsvr32.exe /s /u "$INSTDIR\x86\VFCopy.dll"' $0
  DetailPrint "結果: $0"
  
  ${If} ${RunningX64}
    ExecWait 'regsvr32.exe /s /u "$INSTDIR\x64\VFCopy.dll"' $0
    DetailPrint "結果: $0"
  ${EndIf}

!system "MakeDList outDeleter.nsh $INSTDIR bin\Release"
!include "outDeleter.nsh"

  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP}"
  DeleteRegKey HKLM "SOFTWARE\${APP}"

  ; Remove files and uninstaller
  Delete "$INSTDIR\uninstall.exe"

  ; Remove directories used
  RMDir "$INSTDIR"

SectionEnd
