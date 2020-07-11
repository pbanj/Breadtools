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
echo Welcome, this will install the new tools menu with windows terminal into your context menu.  make sure you edited the registry files first.
echo Batch file, and reg files made by pbanj.
echo VB Scripts by sevenforums.com.
echo Icons from google :p
echo Thanks to xGhostboyx for the settings menu icons.
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
echo Choose position
echo 1. Normal
echo 2. Top
echo 3. bottom
set /P A=Choose position then press enter. 
if %A%==1 goto all
if %A%==2 goto tall
if %A%==3 goto ball
goto start_pos

:all
cd /d %~dp0
REGEDIT /s Files\install.reg
robocopy Files\breadtools C:\breadtools /E
goto bicons

:tall
cd /d %~dp0
REGEDIT /s Files\tinstall.reg
robocopy Files\breadtools C:\breadtools /E
goto bicons

:ball
cd /d %~dp0
cd /d %~dp0
REGEDIT /s Files\binstall.reg
robocopy Files\breadtools C:\breadtools /E
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
robocopy Files\Bash\Ubuntu C:\breadtools\icons
goto done

:de
cd /d %~dp0
robocopy Files\Bash\Debian C:\breadtools\icons
goto done

:ka
cd /d %~dp0
robocopy Files\Bash\Kali C:\breadtools\icons
goto done

:su
cd /d %~dp0
robocopy Files\Bash\Suse C:\breadtools\icons
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
echo 1. Uninstall
set /P A=Choose what to uninstall then press enter. 
if %A%==1 goto uall
goto start_unin

:uall
cd /d %~dp0
REGEDIT /s Files\uninstall.reg
rmdir /s C:\breadtools
echo Done Uninstalling. Have a fucked day.
pause
exit

