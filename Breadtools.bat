@echo off
goto check_Permissions

:check_Permissions
    
    net session >nul 2>&1
    if %errorLevel% == 0 (
        echo off
    ) else (
        echo Im sorry %username%, but I cant let you do that.
		echo I know reading is hard but come on, it's a small text file. Go RTFM.
		echo If this was a 3ds you'd have bricked.
pause
exit
    )

@echo off

CLS
:start
REGEDIT /s Files\Uninstallers\upgrade.reg
cls
del C:\Windows\network.ico C:\Windows\settings.ico C:\Windows\system.ico C:\Windows\update.ico C:\Windows\lock.ico C:\Windows\log.ico C:\Windows\rstart.ico C:\Windows\shut.ico C:\Windows\hib.ico C:\Windows\sleep.ico C:\Windows\switch.ico C:\Windows\file.ico C:\Windows\Files_Extensions.vbs C:\Windows\Hidden_Files.vbs C:\Windows\tools.ico C:\Windows\bash.ico
cls
rmdir /s /Q C:\Breadtools\
cls
echo Welcome %username%, this will install the tools, settings menu, and a power menu.
echo 1. Install
echo 2. Uninstall
echo 3. Exit
set /P A=Choose 1, 2, or 3 then press enter. 
if %A%==1 goto pos
if %A%==2 goto unin
if %A%==3 exit
goto start

:pos
:start_pos
cls
@echo off
robocopy "%~dp0\Files\Breadtools" C:\Breadtools /E
cls
cscript "%~dp0\Files\Installers\ree.vbs"
cls
cd %systemroot%\system32
@echo off
cls
echo Choose position
echo 1. Normal
echo 2. Top
echo 3. bottom
set /P A=Choose position then press enter. 
if %A%==1 goto nall
if %A%==2 goto tall
if %A%==3 goto ball
goto start_pos

:nall
Reg.exe add "HKCR\Directory\Background\shell\Tools" /v "ExtendedSubCommandsKey" /t REG_SZ /d "\Directory\ContextMenus\Tools" /f
Reg.exe add "HKCR\Directory\Background\shell\Tools" /v "Icon" /t REG_SZ /d "C:\breadtools\icons\tools.ico" /f
Reg.exe add "HKCR\Directory\Background\shell\Settings" /v "ExtendedSubCommandsKey" /t REG_SZ /d "\Directory\ContextMenus\Settings" /f
Reg.exe add "HKCR\Directory\Background\shell\Settings" /v "Position" /t REG_SZ /d "Bottom" /f
Reg.exe add "HKCR\Directory\Background\shell\Settings" /v "icon" /t REG_SZ /d "C:\breadtools\icons\settings.ico" /f
goto rall 

:tall
Reg.exe add "HKCR\Directory\Background\shell\Tools" /v "ExtendedSubCommandsKey" /t REG_SZ /d "\Directory\ContextMenus\Tools" /f
Reg.exe add "HKCR\Directory\Background\shell\Tools" /v "Icon" /t REG_SZ /d "C:\breadtools\icons\tools.ico" /f
Reg.exe add "HKCR\Directory\Background\shell\Tools" /v "Position" /t REG_SZ /d "Top" /f
Reg.exe add "HKCR\Directory\Background\shell\Settings" /v "ExtendedSubCommandsKey" /t REG_SZ /d "\Directory\ContextMenus\Settings" /f
Reg.exe add "HKCR\Directory\Background\shell\Settings" /v "Position" /t REG_SZ /d "Bottom" /f
Reg.exe add "HKCR\Directory\Background\shell\Settings" /v "icon" /t REG_SZ /d "C:\breadtools\icons\settings.ico" /f
goto rall

:ball
Reg.exe add "HKCR\Directory\Background\shell\Tools" /v "ExtendedSubCommandsKey" /t REG_SZ /d "\Directory\ContextMenus\Tools" /f
Reg.exe add "HKCR\Directory\Background\shell\Tools" /v "Icon" /t REG_SZ /d "C:\breadtools\icons\tools.ico" /f
Reg.exe add "HKCR\Directory\Background\shell\Tools" /v "Position" /t REG_SZ /d "bottom" /f
Reg.exe add "HKCR\Directory\Background\shell\Settings" /v "ExtendedSubCommandsKey" /t REG_SZ /d "\Directory\ContextMenus\Settings" /f
Reg.exe add "HKCR\Directory\Background\shell\Settings" /v "Position" /t REG_SZ /d "Bottom" /f
Reg.exe add "HKCR\Directory\Background\shell\Settings" /v "icon" /t REG_SZ /d "C:\breadtools\icons\settings.ico" /f
goto rall

:rall
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\1file" /v "HasUAShield" /t REG_SZ /d "" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\1file" /v "icon" /t REG_SZ /d "C:\breadtools\icons\file.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\1file" /ve /t REG_SZ /d "File Extensions" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\1file\command" /ve /t REG_SZ /d "explorer /root,C:\breadtools\scripts\Files_Extensions.vbs" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\2hidden" /v "HasUAShield" /t REG_SZ /d "" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\2hidden" /ve /t REG_SZ /d "Hidden Files" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\2hidden" /v "icon" /t REG_SZ /d "C:\breadtools\icons\file.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\2hidden\command" /ve /t REG_SZ /d "explorer /root,C:\breadtools\scripts\Hidden_Files.vbs" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\3restart ex" /ve /t REG_SZ /d "Restart Explorer" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\3restart ex" /v "icon" /t REG_SZ /d "C:\Windows\explorer.exe" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\4sfc" /v "HasLUAShield" /t REG_SZ /d "" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\4sfc" /ve /t REG_SZ /d "Run SFC /Scannow" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\4sfc" /v "icon" /t REG_SZ /d "cmd.exe" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\4sfc\command" /ve /t REG_SZ /d "PowerShell -windowstyle hidden -command \"Start-Process cmd -ArgumentList '/s,/k, sfc.exe /scannow' -Verb runAs\"" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\5env" /v "icon" /t REG_SZ /d "sysdm.cpl,-1" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\5env" /v "HasLUAShield" /t REG_SZ /d "" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\5env" /ve /t REG_SZ /d "Env Variables" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\scripts\shell\5env\command" /ve /t REG_SZ /d "powershell.exe -windowstyle hidden -command \"Start-Process rundll32 -ArgumentList '/s,/c, sysdm.cpl,EditEnvironmentVariables' -Verb runAs\"" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\shell\1reg" /ve /t REG_SZ /d "Regedit" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\shell\1reg" /v "Icon" /t REG_SZ /d "C:\Windows\regedit.exe" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\shell\1reg\command" /ve /t REG_SZ /d "C:\Windows\regedit.exe /m" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\shell\2sterm" /ve /t REG_SZ /d "Windows Terminal" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\shell\2sterm" /v "ExtendedSubCommandsKey" /t REG_SZ /d "\Directory\ContextMenus\Tools\winterm" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\shell\2sterm" /v "Icon" /t REG_SZ /d "C:\breadtools\icons\terminal.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\shell\3scripts" /v "Icon" /t REG_SZ /d "C:\breadtools\icons\file.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\shell\3scripts" /ve /t REG_SZ /d "Scripts && Tools" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\shell\3scripts" /v "ExtendedSubCommandsKey" /t REG_SZ /d "\Directory\ContextMenus\Tools\scripts" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell" /ve /t REG_SZ /d "Powershell Here" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\1cmd" /v "Icon" /t REG_SZ /d "C:\Windows\System32\cmd.exe" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\1cmd" /ve /t REG_SZ /d "Open CMD Here" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\1cmd\command" /ve /t REG_SZ /d "\"C:\Users\%username%\AppData\Local\Microsoft\WindowsApps\wt.exe\" -p \"Command Prompt\" -d \"%%V.\"" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\2acmd" /v "HasLUAShield" /t REG_SZ /d "" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\2acmd" /v "Icon" /t REG_SZ /d "imageres.dll,-5324" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\2acmd" /ve /t REG_SZ /d "Admin CMD Here" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\2acmd\command" /ve /t REG_SZ /d "wscript.exe \"C:\breadtools\scripts/helper.vbs\" \"C:\Users\%username%\AppData\Local\Microsoft\WindowsApps\wt.exe\" \"%%V.\" \"Command Prompt\"" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\3opshell" /ve /t REG_SZ /d "Open Powershell Here" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\3opshell" /v "Icon" /t REG_SZ /d "imageres.dll,-5372" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\3opshell\command" /ve /t REG_SZ /d "\"C:\Users\%username%\AppData\Local\Microsoft\WindowsApps\wt.exe\" -d \"%%V\\.\"" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\4apshell" /ve /t REG_SZ /d "Admin Powershell Here" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\4apshell" /v "HasLUAShield" /t REG_SZ /d "" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\4apshell" /v "Icon" /t REG_SZ /d "imageres.dll,-5373" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\4apshell\command" /ve /t REG_SZ /d "wscript.exe \"C:\breadtools\scripts\helper.vbs\" \"C:\Users\%username%\AppData\Local\Microsoft\WindowsApps\wt.exe\" \"%%V.\" \"Windows PowerShell\"" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\5bash" /v "Icon" /t REG_SZ /d "C:\breadtools\icons\bash.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\5bash" /ve /t REG_SZ /d "Open Bash Here" /f
Reg.exe add "HKCR\Directory\ContextMenus\Tools\winterm\shell\5bash\command" /ve /t REG_SZ /d "\"C:\Users\%username%\AppData\Local\Microsoft\WindowsApps\wt.exe\" -p \"Ubuntu\" -d \"%%V.\"" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings" /v "icon" /t REG_SZ /d "SystemSettingsBroker.exe" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\1settings" /v "SettingsURI" /t REG_SZ /d "ms-settings:main" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\1settings" /ve /t REG_SZ /d "Settings" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\1settings" /v "icon" /t REG_SZ /d "C:\breadtools\icons\settings.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\1settings\command" /v "DelegateExecute" /t REG_SZ /d "{556FF0D6-A1EE-49E5-9FA4-90AE116AD744}" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\2network" /v "SettingsURI" /t REG_SZ /d "ms-settings:network" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\2network" /ve /t REG_SZ /d "Network && Internet" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\2network" /v "icon" /t REG_SZ /d "C:\breadtools\icons\network.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\2network\command" /v "DelegateExecute" /t REG_SZ /d "{556FF0D6-A1EE-49E5-9FA4-90AE116AD744}" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\3update" /v "SettingsURI" /t REG_SZ /d "ms-settings:windowsupdate" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\3update" /v "icon" /t REG_SZ /d "C:\breadtools\icons\update.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\3update" /ve /t REG_SZ /d "Update" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\3update\command" /v "DelegateExecute" /t REG_SZ /d "{556FF0D6-A1EE-49E5-9FA4-90AE116AD744}" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\4System" /v "SettingsURI" /t REG_SZ /d "ms-settings:about" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\4System" /v "icon" /t REG_SZ /d "C:\breadtools\icons\system.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\4System" /ve /t REG_SZ /d "System" /f
Reg.exe add "HKCR\Directory\ContextMenus\Settings\shell\4System\command" /v "DelegateExecute" /t REG_SZ /d "{556FF0D6-A1EE-49E5-9FA4-90AE116AD744}" /f
goto bicons

:bicons
:start_bicons
cls
echo Which distro do you use for WSL?
echo 1. Ubuntu
echo 2. Debian
echo 3. Kali
echo 4. Suse
set /P A=Choose one then press enter. 
if %A%==1 goto ub
if %A%==2 goto de
if %A%==3 goto ka
if %A%==4 goto su
goto start_bicons

:ub
cd /d %~dp0
robocopy Files\Bash\Ubuntu C:\Breadtools\icons
goto powr

:de
cd /d %~dp0
robocopy Files\Bash\Debian C:\Breadtools\icons
goto powr

:ka
cd /d %~dp0
robocopy Files\Bash\Kali C:\Breadtools\icons
goto powr

:su
cd /d %~dp0
robocopy Files\Bash\Suse C:\Breadtools\icons
goto powr

:powr
cls
echo %username% would you like to install the power menu also?
echo 1. yes
echo 2. no
set /P A=Choose one then press enter.
if %A%==1 goto powri
if %A%==2 goto done
goto powr

:powri
cls
robocopy "%~dp0\Files\Power" C:\Breadtools\icons\power
Reg.exe add "HKCR\Directory\Background\shell\xPower" /v "Position" /t REG_SZ /d "Bottom" /f
Reg.exe add "HKCR\Directory\Background\shell\xPower" /ve /t REG_SZ /d "Power" /f
Reg.exe add "HKCR\Directory\Background\shell\xPower" /v "Icon" /t REG_SZ /d "C:\Breadtools\icons\power\shut.ico" /f
Reg.exe add "HKCR\Directory\Background\shell\xPower" /v "ExtendedSubCommandsKey" /t REG_SZ /d "\Directory\ContextMenus\Power" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power" /v "Icon" /t REG_SZ /d "C:\Breadtools\icons\power\power.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\1lock" /v "Icon" /t REG_SZ /d "C:\Breadtools\icons\power\lock.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\1lock" /ve /t REG_SZ /d "Lock" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\1lock\command" /ve /t REG_SZ /d "Rundll32 User32.dll,LockWorkStation" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\2log" /ve /t REG_SZ /d "Log Off" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\2log" /v "Icon" /t REG_SZ /d "C:\Breadtools\icons\power\logoff.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\2log\command" /ve /t REG_SZ /d "Shutdown -l" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\3hip" /ve /t REG_SZ /d "Hibernate" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\3hip" /v "Icon" /t REG_SZ /d "C:\Breadtools\icons\power\hibernate.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\3hip\command" /ve /t REG_SZ /d "Shutdown -h" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\4slp" /ve /t REG_SZ /d "Sleep" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\4slp" /v "Icon" /t REG_SZ /d "C:\Breadtools\icons\power\sleep.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\4slp\command" /ve /t REG_SZ /d "rundll32.exe powrprof.dll,SetSuspendState Sleep" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\5rstart" /ve /t REG_SZ /d "Restart" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\5rstart" /v "Icon" /t REG_SZ /d "C:\Breadtools\icons\power\restart.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\5rstart\command" /ve /t REG_SZ /d "Shutdown -r -f -t 00" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\6obo" /ve /t REG_SZ /d "Boot Options Menu" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\6obo" /v "Icon" /t REG_SZ /d "C:\Breadtools\icons\power\bootoptions.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\6obo\command" /ve /t REG_SZ /d "Shutdown -r -o -f -t 00" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\7shut" /ve /t REG_SZ /d "Shutdown" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\7shut" /v "Icon" /t REG_SZ /d "C:\Breadtools\icons\power\shutdown.ico" /f
Reg.exe add "HKCR\Directory\ContextMenus\Power\shell\7shut\command" /ve /t REG_SZ /d "Shutdown -s -f -t 00" /f
goto done

:unin
cls
:start_unin
echo Uninstall
echo 1. Uninstall just tools?
echo 2. Uninstall just settings?
echo 3. Uninstall just power?
echo 4. Uninstall everything?
set /P A=Choose what to uninstall then press enter. 
if %A%==1 goto utol
if %A%==2 goto uset
if %a%==3 goto upow
if %A%==4 goto evthang
goto start_unin

:utol
cd /d %~dp0
REGEDIT /s Files\Uninstallers\tooluninstall.reg
del C:\Breadtools\icons\tools.ico C:\Breadtools\icons\terminal.ico C:\Breadtools\icons\file.ico C:\Breadtools\icons\bash.ico
echo Done Uninstalling. Have a fucked day %username%.
pause
exit

:uset
cd /d %~dp0
REGEDIT /s Files\Uninstallers\settinguninstall.reg
del C:\Breadtools\icons\settings.ico C:\Breadtools\icons\update.ico C:\Breadtools\icons\system.ico C:\Breadtools\icons\network.ico
echo Done Uninstalling. Have a fucked day %username%.
pause
exit

:upow
cd /d %~dp0
REGEDIT /s Files\Uninstallers\uninstallpow.reg
rmdir /s /Q C:\Breadtools\power
echo Done Uninstalling. Have a fucked day %username%.
pause
exit

:evthang
cd /d %~dp0
REGEDIT /s Files\Uninstallers\evthang.reg
rmdir /s /Q C:\Breadtools\
echo Done Uninstalling. Have a fucked day %username%.
pause
exit

:done
cls
echo Done installing. Have a fucked day %username%.
pause
exit