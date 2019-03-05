@echo off
goto check_Permissions

:check_Permissions
    
    net session >nul 2>&1
    if %errorLevel% == 0 (
        echo off
    ) else (
        echo I know reading is hard but come on, it's a small text file. Go RTFM.
		echo If this was a 3ds you'd have bricked.
pause
exit
    )

@echo off
CLS

:start
cls
echo Welcome, this will install a tools, power menu, and or a settings menu into your context menu. 
echo Power menu and Settings only shows on desktop.
echo Batch file, and reg files made by pbanj.
echo VB Scripts by sevenforums.com.
echo Icons from google :p
echo Thanks to xGhostboyx for the settings menu icons.
echo 1. Install
echo 2. Uninstall
echo 3. Exit
set /P A=Choose 1, 2, or 3 then press enter. 
if %A%==1 goto inst
if %A%==2 goto unin
if %A%==3 exit
goto start

:inst
:start_inst
cls
echo Choose what to install
echo 1. Tool Menu
echo 2. Power 
echo 3. Power with sleep, hibernate, and switch users
echo 4. Tool and Power
echo 5. Tool and power with sleep, hibernate, and switch users
echo 6. Settings
echo 7. Start over
set /P A=Choose Option then press enter. 
if %A%==1 goto pos
if %A%==2 goto pow1
if %A%==3 goto pow2
if %A%==4 goto tp1
if %A%==5 goto tp2
if %A%==6 goto settings
if %A%==7 goto start
goto start_inst

:pos
:start_pos
cls
echo Choose position
echo 1. Normal
echo 2. Top
echo 3. bottom
set /P A=Choose position then press enter. 
if %A%==1 goto all
if %A%==2 goto tall
if %A%==3 goto ball
goto start_pos

:pow1
cd /d %~dp0
REGEDIT /s Files\Reg\Install_Po.reg
xcopy Files\Pow C:\Windows
echo Done installing. Have a fucked day.
pause
exit

:pow2
cd /d %~dp0
REGEDIT /s Files\Reg\Install_Epo.reg
xcopy Files\Epo C:\Windows
xcopy Files\Pow C:\Windows
echo Done installing. Have a fucked day.
pause
exit

:tp1
cd /d %~dp0
REGEDIT /s Files\Reg\Install_Po.reg
xcopy Files\Pow C:\Windows
goto pos

:tp2
cd /d %~dp0
REGEDIT /s Files\Reg\Install_Epo.reg
xcopy Files\Epo C:\Windows
xcopy Files\Pow C:\Windows
goto pos

:all
cd /d %~dp0
REGEDIT /s Files\Reg\Install_all.reg
xcopy Files\Too C:\Windows
goto extras

:extras
:start_extras
cls
echo Do you want Open bash here and or Settings?
echo 1. Both
echo 2. Bash
echo 3. Settings
echo 4. None
set /P A=Choose one then press enter. 
if %A%==1 goto aextras
if %A%==2 goto bashi
if %A%==3 goto settings
if %A%==4 goto done
goto start_extras

:aextras
cd /d %~dp0
REGEDIT /s Files\Reg\bash.reg
REGEDIT /s Files\Reg\settings.reg
xcopy Files\Sett C:\Windows
goto bicons

:bashi
cd /d %~dp0
REGEDIT /s Files\Reg\bash.reg
goto bicons

:settings
cd /d %~dp0
REGEDIT /s Files\Reg\settings.reg
xcopy Files\Sett C:\Windows
goto done
pause
exit

:tall
cd /d %~dp0
REGEDIT /s Files\Reg\Install_tall.reg
xcopy Files\Too C:\Windows
goto textras

:textras
:start_textras
cls
echo Do you want Open bash here and or Settings?
echo 1. Both
echo 2. Bash
echo 3. Settings
echo 4. None
set /P A=Choose one then press enter. 
if %A%==1 goto taextras
if %A%==2 goto tbashi
if %A%==3 goto settings
if %A%==4 goto done
goto start_textras

:taextras
cd /d %~dp0
REGEDIT /s Files\Reg\tbash.reg
REGEDIT /s Files\Reg\settings.reg
xcopy Files\Sett C:\Windows
goto bicons

:tbashi
cd /d %~dp0
REGEDIT /s Files\Reg\tbash.reg
goto bicons

:ball
cd /d %~dp0
REGEDIT /s Files\Reg\Install_ball.reg
xcopy Files\Too C:\Windows
goto bextras

:bextras
:start_bextras
cls
echo Do you want Open bash here and or Settings?
echo 1. Both
echo 2. Bash
echo 3. Settings
echo 4. None
set /P A=Choose one then press enter. 
if %A%==1 goto baextras
if %A%==2 goto bbashi
if %A%==3 goto settings
if %A%==4 goto done
goto start_bextras

:baextras
cd /d %~dp0
REGEDIT /s Files\Reg\bbash.reg
REGEDIT /s Files\Reg\settings.reg
xcopy Files\Sett C:\Windows
goto bicons

:bbashi
cd /d %~dp0
REGEDIT /s Files\Reg\bbash.reg
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
xcopy Files\Bash\Ubuntu C:\Windows
goto done

:de
cd /d %~dp0
xcopy Files\Bash\Debian C:\Windows
goto done

:ka
cd /d %~dp0
xcopy Files\Bash\Kali C:\Windows
goto done

:su
cd /d %~dp0
xcopy Files\Bash\Suse C:\Windows
goto done

:done
cls
echo Done installing. Have a fucked day.
pause
exit

:unin
cls
:start_unin
echo Uninstall
echo 1. Uninstall All
echo 2. Uninstall Tools
echo 3. Uninstall Power
echo 4. Uninstall Settings
set /P A=Choose what to uninstall then press enter. 
if %A%==1 goto uall
if %A%==2 goto utoo
if %A%==3 goto upow
if %A%==4 goto uset
goto start_unin

:uall
cd /d %~dp0
REGEDIT /s Files\Reg\Uninstall_all.reg
del C:\Windows\file.ico C:\Windows\Files_Extensions.vbs C:\Windows\Hidden_Files.vbs C:\Windows\tools.ico C:\Windows\lock.ico C:\Windows\log.ico C:\Windows\rstart.ico C:\Windows\shut.ico C:\Windows\hib.ico C:\Windows\sleep.ico C:\Windows\switch.ico C:\Windows\network.ico C:\Windows\settings.ico C:\Windows\system.ico C:\Windows\update.ico C:\Windows\bash.ico
echo Done Uninstalling. Have a fucked day.
pause
exit

:utoo
cd /d %~dp0
REGEDIT /s Files\Reg\Uninstall_Tool.reg
del C:\Windows\file.ico C:\Windows\Files_Extensions.vbs C:\Windows\Hidden_Files.vbs C:\Windows\tools.ico C:\Windows\bash.ico
echo Done Uninstalling. Have a fucked day.
pause
exit

:upow
cd /d %~dp0
REGEDIT /s Files\Reg\Uninstall_Po.reg
del C:\Windows\lock.ico C:\Windows\log.ico C:\Windows\rstart.ico C:\Windows\shut.ico C:\Windows\hib.ico C:\Windows\sleep.ico C:\Windows\switch.ico
echo Done Uninstalling. Have a fucked day.
pause
exit

:uset
cd /d %~dp0
REGEDIT /s Files\Reg\Uninstall_Settings.reg
del C:\Windows\network.ico C:\Windows\settings.ico C:\Windows\system.ico C:\Windows\update.ico
echo Done Uninstalling. Have a fucked day.
pause
exit
