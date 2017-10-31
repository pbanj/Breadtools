@echo off
goto check_Permissions

:check_Permissions
    
    net session >nul 2>&1
    if %errorLevel% == 0 (
        echo off
    ) else (
        echo I know reading is hard but come on, it's a small text file. Go RTFM.
		echo If this was a 3ds you would have bricked.
pause
exit
    )

@echo off
CLS

:start
cls
echo Welcome, this will install a tools and or power menu into your context menu. 
echo Power menu only shows on desktop.
echo Batch file, and reg files made by pbanj.
echo VB Scripts by sevenforums.com.
echo Icons from google :p
echo Thanks to TizzyT for answering my questions and
echo Steveo1978 for the idea of making the script.
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
echo 6. Start over
set /P A=Choose Option then press enter. 
if %A%==1 goto pos
if %A%==2 goto pow1
if %A%==3 goto pow2
if %A%==4 goto tp1
if %A%==5 goto tp2
if %A%==6 goto start
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
goto start_bash

:bash
:start_bash
cls
echo Do you want open bash here?
echo You must enable the linux subsystem for this to work.
echo See the readme for a link to enable lss.
echo 1. Yes
echo 2. No
set /P A=Choose yes or no then press enter. 
if %A%==1 goto bashi
if %A%==2 goto done
goto start_bash

:bashi
cd /d %~dp0
REGEDIT /s Files\Reg\bash.reg
echo Done installing. Have a fucked day.
pause
exit

:tall
cd /d %~dp0
REGEDIT /s Files\Reg\Install_tall.reg
xcopy Files\Too C:\Windows
goto tbash

:tbash
:start_tbash
cls
echo Do you want open bash here?
echo You must enable the linux subsystem for this to work.
echo See the readme for a link to enable lss.
echo 1. Yes
echo 2. No
set /P A=Choose yes or no then press enter. 
if %A%==1 goto tbashi
if %A%==2 goto done
goto start_tbash

:tashi
cd /d %~dp0
REGEDIT /s Files\Reg\tbash.reg
echo Done installing. Have a fucked day.
pause
exit

:ball
cd /d %~dp0
REGEDIT /s Files\Reg\Install_ball.reg
xcopy Files\Too C:\Windows
goto bbash

:bbash
:start_bbash
cls
echo Do you want open bash here?
echo You must enable the linux subsystem for this to work.
echo See the readme for a link to enable lss.
echo 1. Yes
echo 2. No
set /P A=Choose yes or no then press enter. 
if %A%==1 goto bbashi
if %A%==2 goto done
goto start_bbash

:bbashi
cd /d %~dp0
REGEDIT /s Files\Reg\bbash.reg
echo Done installing. Have a fucked day.
pause
exit

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
set /P A=Choose what to uninstall then press enter. 
if %A%==1 goto uall
if %A%==2 goto utoo
if %A%==3 goto upow
goto start_unin

:uall
cd /d %~dp0
REGEDIT /s Files\Reg\Uninstall_all.reg
del C:\Windows\file.ico C:\Windows\Files_Extensions.vbs C:\Windows\Hidden_Files.vbs C:\Windows\tools.ico C:\Windows\lock.ico C:\Windows\log.ico C:\Windows\rstart.ico C:\Windows\shut.ico C:\Windows\hib.ico C:\Windows\sleep.ico C:\Windows\switch.ico
echo Done Uninstalling. Have a fucked day.
pause
exit

:utoo
cd /d %~dp0
REGEDIT /s Files\Reg\Uninstall_Tool.reg
del C:\Windows\file.ico C:\Windows\Files_Extensions.vbs C:\Windows\Hidden_Files.vbs C:\Windows\tools.ico
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